using System.Globalization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OnlineApplicationSystem.Application.Common.Dtos;
using OnlineApplicationSystem.Application.Common.Interfaces;
using OnlineApplicationSystem.Infrastructure.Identity;
using Renci.SshNet;
using SixLabors.ImageSharp;
using Microsoft.Extensions.Logging;

using Renci.SshNet.Common;
using System.Diagnostics.CodeAnalysis;

namespace OnlineApplicationSystem.Infrastructure.Services;

public class DocumentUploadService : IDocumentUploadService
{
    private string _serverUrl = "https://photos.ttuportal.com/public/albums/thumbnails";
    private readonly IConfiguration _configuration;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IWebHostEnvironment _hostingEnvironment;
    private readonly IApplicantRepository _applicantRepository;
    private readonly ISftpClient _sftpClient;


    private readonly int port;
    private readonly string host = "";
    private readonly string username = "";
    private readonly string password = "";
    private readonly string fileLocation = "/var/www/html/documents/admissions/postgraduates";
    private readonly string basePath = "/var/www/html/documents/admissions/postgraduates";

    string IDocumentUploadService.UserId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public DocumentUploadService(IConfiguration configuration, IWebHostEnvironment hostingEnvironment, UserManager<ApplicationUser> userManager, IApplicantRepository applicantRepository)
    {
        _configuration = configuration;
        _hostingEnvironment = hostingEnvironment;
        _userManager = userManager;
        _applicantRepository = applicantRepository;
        this.password = _configuration["sftppassword"];
        this.username = _configuration["sftpusername"];
        this.host = _configuration["sftphost"];
        this.port = Convert.ToInt32(_configuration["sftpport"]);

    }
    private void EnsureConnected()
    {
        var _sftpClient = new SftpClient(this.host, this.port, this.username, this.password);
        if (!_sftpClient.IsConnected)
        {
            _sftpClient.Connect();
        }
    }

    public bool IsExist(string basePath, string fileName)
    {
        if (String.IsNullOrWhiteSpace(fileName))
        {
            throw new ArgumentNullException(nameof(fileName));
        }
        if (String.IsNullOrWhiteSpace(basePath))
        {
            throw new ArgumentNullException(nameof(basePath));
        }
        EnsureConnected();
        var filePath = GetFileFullPath(basePath, fileName);
        return _sftpClient.Exists(filePath);

    }
    private string GetFileFullPath([NotNull] string basePath, [NotNull] string fileName)
    {
        var tempFileName = fileName.Replace(@"\", "/").Trim('/');
        var filePath = Path.Combine(basePath, tempFileName).Replace(@"\", "/");
        return (filePath);
    }
    private void CreateDirectoryRecursively(string path)
    {
        var current = "";

        if (path[0] == '/')
        {
            path = path.Substring(1);
        }

        var isFirst = true;

        while (!string.IsNullOrEmpty(path))
        {
            var p = path.IndexOf('/');
            if (isFirst)
            {
                isFirst = false;
            }
            else
            {
                current += '/';
            }

            if (p >= 0)
            {
                current += path.Substring(0, p);
                path = path.Substring(p + 1);
            }
            else
            {
                current += path;
                path = "";
            }

            try
            {
                var attributes = _sftpClient.GetAttributes(current);
                if (!attributes.IsDirectory)
                {
                    throw new Exception("not directory");
                }
            }
            catch (SftpPathNotFoundException)
            {
                _sftpClient.CreateDirectory(current);
            }
        }
    }

    public async Task<int> UploadFiles(long applicant, IEnumerable<FileDto> files, CancellationToken cancellationToken)
    {

        var userdetails = await _applicantRepository.GetApplicantByApplicationNumber(applicant, cancellationToken: cancellationToken);

        var applicationNo = userdetails?.ApplicationNumber;
        foreach (var formFile in files)
        {
            var fileName = formFile.Name;
            var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "pictures");
            var extension = Path.GetExtension(fileName).ToLower();
            var pictureToSave = applicationNo + extension;
            var fileLocation = Path.Combine(uploads, pictureToSave);
            var image = await Image.LoadAsync(formFile.Content, cancellationToken);
            // image.Mutate(img => img.AutoOrient());
            // image.Mutate(x => x.Resize(413, 531));
            try
            {
                image.Save(fileLocation);
            }
            catch (Exception exp)
            {
                System.Console.WriteLine("Exception generated when uploading file - " + exp.Message);

                return await Task.FromResult(0);
            }

            using var client = new SftpClient(this.host, this.port, this.username, this.password);
            client.Connect();
            if (client.IsConnected)
            {
                Console.WriteLine("I'm connected to the client");
                client.ChangeDirectory("/var/www/html/documents/admissions/postgraduates");
                await using (var fileStream = new FileStream(fileLocation, FileMode.Open))
                {
                    client.BufferSize = 4 * 1024; // bypass Payload error large files
                    client.UploadFile(fileStream, Path.GetFileName(fileLocation));
                }
            }
            var fileInfo = new FileInfo(fileLocation);
            fileInfo.Delete();
            return await Task.FromResult(1);
        }
        // now lets create an issue for picture upload
        Console.WriteLine("I couldn't connect");
        return await Task.FromResult(0);

    }
    public async Task<bool> DeleteFile(long applicant, string file, CancellationToken cancellationToken)
    {

        using var client = new SftpClient(host, port, username, password);
        client.Connect();
        if (client.IsConnected)
        {
            Console.WriteLine("I'm connected to the client");
            client.ChangeDirectory("/var/www/html/documents/admissions/postgraduates");
            await using (var fileStream = new FileStream(fileLocation, FileMode.Open))
            {
                // Delete file in folder.
                client.DeleteFile(fileLocation);
            }
            return await Task.FromResult(true);
        }
        else
        {
            Console.WriteLine("I couldn't connect");
            return await Task.FromResult(false);
        }
    }

    public Task<byte[]?> DownloadFiles(long applicant, string basePath, string fileName, CancellationToken cancellationToken)
    {
        if (String.IsNullOrWhiteSpace(fileName))
        {
            throw new ArgumentNullException(nameof(fileName));
        }
        if (String.IsNullOrWhiteSpace(basePath))
        {
            throw new ArgumentNullException(nameof(basePath));
        }
        using var _sftpClient = new SftpClient(host, port, username, password);
        _sftpClient.Connect();
        var filePath = GetFileFullPath(basePath, fileName);

        if (!_sftpClient.Exists(filePath))
        {
            Console.Write($"File \"{filePath}\" not found on SFTP server");
            return null;
        }

        using (var file = _sftpClient.Open(filePath, FileMode.Open))
        {
            using (var ms = new MemoryStream())
            {
                file.CopyTo(ms);
                return Task.FromResult(ms.ToArray());
            }
        }
        ;
    }
    public Task UploadFileToServerAsync(Stream stream, string basePath, string fileName, bool overwrite = false)
    {
        var port = Convert.ToInt32(_configuration["sftpport"]);
        var host = _configuration["sftphost"];
        var username = _configuration["sftpusername"];
        var password = _configuration["sftppassword"];
        if (String.IsNullOrWhiteSpace(fileName))
        {
            throw new ArgumentNullException(nameof(fileName));
        }
        if (String.IsNullOrWhiteSpace(basePath))
        {
            throw new ArgumentNullException(nameof(basePath));
        }

        if (stream == null)
        {
            throw new ArgumentNullException(fileName);
        }
        if (stream.Length == 0)
        {
            throw new ArgumentException("Stream is empty");
        }
        using var _sftpClient = new SftpClient(host, port, username, password);
        _sftpClient.Connect();

        EnsureConnected();

        var filePath = GetFileFullPath(basePath, fileName);

        if (_sftpClient.Exists(filePath))
        {
            // Check file size.
            var attributes = _sftpClient.GetAttributes(filePath);
            if (attributes.Size == stream.Length)
            {
                // Size is equal. Assume that files are equal. No need to upload.
                Console.WriteLine(String.Format("file exist", fileName));
                return Task.CompletedTask;
            }

            if (overwrite)
            {
                // can overwrite, so delete file
                Console.WriteLine(String.Format(

                                        fileName,
                                        attributes.Size,
                                        stream.Length));
                _sftpClient.DeleteFile(filePath);
            }
            else
            {
                // can't overwrite, it's error
                throw new SshException(
                    String.Format(

                        fileName,
                        attributes.Size,
                        stream.Length));
            }
        }

        var sftpDirectory = Path.GetDirectoryName(filePath)
                            ?.Replace(@"\", "/") // windows-linux compatibility
                            ?? throw new InvalidOperationException("File path can't be mull");

        if (!_sftpClient.Exists(sftpDirectory))
        {
            CreateDirectoryRecursively(sftpDirectory);
        }

        //TODO #3 check it, I think we don't need it here
        // we need to set position to start because temp stream can be used in another places
        stream.Position = 0;

        return Task.Factory.FromAsync(
            _sftpClient.BeginUploadFile(
                stream,
                filePath,
                false,
                null,
                null),
            _sftpClient.EndUploadFile);
        ;
    }
    public Task<bool> Sftp(string server, int port, bool passive, string username, string password, string filename, int counter, byte[] contents, out string error, bool rename)
    {
        bool failed = false;
        error = "";
        try
        {
            int i = 0;
            filename = filename.Replace("{C}", counter.ToString(CultureInfo.InvariantCulture));
            if (rename)
                filename += ".tmp";

            while (filename.IndexOf("{", StringComparison.Ordinal) != -1 && i < 20)
            {
                filename = String.Format(CultureInfo.InvariantCulture, filename, DateTime.UtcNow);
                i++;
            }

            var methods = new List<AuthenticationMethod> { new PasswordAuthenticationMethod(username, password) };

            var con = new ConnectionInfo(server, port, username, methods.ToArray());
            using (var client = new SftpClient(con))
            {
                client.Connect();

                var filepath = filename.Trim('/').Split('/');
                var path = "";
                for (var iDir = 0; iDir < filepath.Length - 1; iDir++)
                {
                    path += filepath[iDir] + "/";
                    try
                    {
                        client.CreateDirectory(path);
                    }
                    catch
                    {
                        //directory exists
                    }
                }
                if (path != "")
                {
                    client.ChangeDirectory(path);
                }

                filename = filepath[filepath.Length - 1];

                using (Stream stream = new MemoryStream(contents))
                {
                    client.UploadFile(stream, filename);
                    if (rename)
                    {
                        try
                        {
                            //delete target file?
                            client.DeleteFile(filename.Substring(0, filename.Length - 4));
                        }
                        catch (Exception)
                        {
                        }
                        client.RenameFile(filename, filename.Substring(0, filename.Length - 4));
                    }
                }

                client.Disconnect();
            }

            Console.Write("SFTP'd " + filename + " to " + server + " port " + port, "SFTP");
        }
        catch (Exception ex)
        {
            error = ex.Message;
            failed = true;
        }
        return Task.FromResult(!failed);
    }


}