using OnlineApplicationSystem.Application.Common.Dtos;
using OnlineApplicationSystem.Application.Common.Interfaces;
using Renci.SshNet;

namespace OnlineApplicationSystem.Infrastructure.Services;

public class PhotoUploadService : IPhotoUploadService
{
    string IPhotoUploadService.UserId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public async Task<UrlsDto> UploadAsync(ICollection<FileDto> files)
    {
        throw new NotImplementedException();
    }
    public Task<int> SendFileToServer(string host, int port, string username, string password, string uploadFile)
    {
        using var client = new SftpClient(host, port, username, password);
        client.Connect();
        if (client.IsConnected)
        {
            Console.WriteLine("I'm connected to the client");
            client.ChangeDirectory("/var/www/html/photos/public/albums/thumbnails");
            using (var fileStream = new FileStream(uploadFile, FileMode.Open))
            {
                client.BufferSize = 4 * 1024; // bypass Payload error large files
                client.UploadFile(fileStream, Path.GetFileName(uploadFile));
            }

            return Task.FromResult(1);
        }
        else
        {
            Console.WriteLine("I couldn't connect");
            return Task.FromResult(0);
        }
    }
}