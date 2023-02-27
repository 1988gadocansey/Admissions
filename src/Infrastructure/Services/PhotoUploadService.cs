using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OnlineApplicationSystem.Application.Common.Dtos;
using OnlineApplicationSystem.Application.Common.Interfaces;
using OnlineApplicationSystem.Infrastructure.Identity;
using Renci.SshNet;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace OnlineApplicationSystem.Infrastructure.Services;

public class PhotoUploadService : IPhotoUploadService
{
    private string serverUrl = "https://photos.ttuportal.com/public/albums/thumbnails";
    private readonly IConfiguration _configuration;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IWebHostEnvironment _hostingEnvironment;
    private readonly IApplicantRepository _applicantRepository;
    public PhotoUploadService(IConfiguration configuration, IWebHostEnvironment hostingEnvironment, UserManager<ApplicationUser> userManager, IApplicantRepository applicantRepository)
    {
        _configuration = configuration;
        _hostingEnvironment = hostingEnvironment;
        _userManager = userManager;
        _applicantRepository = applicantRepository;
    }



    string IPhotoUploadService.UserId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public async Task<UrlsDto> UploadAsync(ICollection<FileDto> files)
    {
        if (files == null || files.Count == 0)
        {
            return null;
        }

        //var containerClient = _blobServiceClient.GetBlobContainerClient("publicuploads");


        var urls = new List<string>();


        /* foreach (var file in files)
        {
            var blobClient = containerClient.GetBlobClient(file.GetPathWithFileName());

            await blobClient.UploadAsync(file.Content, new BlobHttpHeaders { ContentType = file.ContentType });

            urls.Add(blobClient.Uri.ToString());
        } */

        return new UrlsDto(urls);
    }
    public async Task<int> SendFileToServer(string applicant, IEnumerable<FileDto> files, CancellationToken cancellationToken)
    {

        var userdetails = await _userManager.Users.Select(b =>
         new UserDto()
         {
             Id = b.Id,
             UserName = b.UserName,
             FormCompleted = b.FormCompleted,
             Finalized = b.Finalized,
             SoldBy = b.SoldBy,
             Started = b.Started,
             Year = b.Year,
             PictureUploaded = b.PictureUploaded,
             FormNo = b.FormNo,
             FullName = b.FullName,
             ResultUploaded = b.ResultUploaded,
             Admitted = b.Admitted,
             LastLogin = b.LastLogin,
             Type = b.Type
         }).FirstOrDefaultAsync(a => a.Id == applicant, cancellationToken: cancellationToken);

        var applicationNo = userdetails?.FormNo;
        foreach (var formFile in files)
        {
            var fileName = formFile.Name;
            var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "pictures");
            var extension = Path.GetExtension(fileName).ToLower();
            var pictureToSave = applicationNo + extension;
            var fileLocation = Path.Combine(uploads, pictureToSave);
            var port = Convert.ToInt32(_configuration["sftpport"]);
            var host = _configuration["sftphost"];
            var username = _configuration["sftpusername"];
            var password = _configuration["sftppassword"];
            var image = Image.Load(formFile.Content);
            image.Mutate(img => img.AutoOrient());
            image.Mutate(x => x.Resize(413, 413));
            try
            {
                image.Save(fileLocation);
            }
            catch (Exception exp)
            {
                System.Console.WriteLine("Exception generated when uploading file - " + exp.Message);
            }

            using var client = new SftpClient(host, port, username, password);
            client.Connect();
            if (client.IsConnected)
            {
                Console.WriteLine("I'm connected to the client");
                client.ChangeDirectory("/var/www/html/photos/public/albums/thumbnails");
                await using (var fileStream = new FileStream(fileLocation, FileMode.Open))
                {
                    client.BufferSize = 4 * 1024; // bypass Payload error large files
                    client.UploadFile(fileStream, Path.GetFileName(fileLocation));
                }
                return await Task.FromResult(1);
            }
            var fileInfo = new FileInfo(fileLocation);
            fileInfo.Delete();
        }
        Console.WriteLine("I couldn't connect");
        return await Task.FromResult(0);

    }
}