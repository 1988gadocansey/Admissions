using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineApplicationSystem.Application.Common.Dtos;
using OnlineApplicationSystem.Application.PictureUpload.Commands.UploadPicture;
using OnlineApplicationSystem.WebUI.Controllers;

namespace WebUI.Controllers;

[Authorize]
public class PictureUploadController : ApiControllerBase
{
    [HttpPost]
    /*  public async Task<ActionResult<UserDto>> UploadPassportPicture([FromForm] IFormFile file)
     {
         using (var stream = new MemoryStream())
         {
             await file.CopyToAsync(stream);
             var fileContents = stream.ToArray();

             var result = await Mediator.Send(new UploadPictureRequest(fileContents));

             return Ok(result);
         }
     } */
    //[HttpPost("Images")]
    public async Task<IActionResult> UploadImages(IList<IFormFile> formFiles)
    {
        var uploadImagesCommand = new UploadPictureRequest();

        foreach (var formFile in formFiles)
        {
            var file = new FileDto
            {
                Content = formFile.OpenReadStream(),
                Name = formFile.FileName,
                UserId = null,
                ContentType = formFile.ContentType,
            };
            uploadImagesCommand.Files.Add(file);
        }

        var response = await Mediator.Send(uploadImagesCommand);

        return Ok(response);
    }
}