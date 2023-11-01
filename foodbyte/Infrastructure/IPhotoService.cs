using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;

namespace foodbyte.Infrastructure;


public interface IPhotoService
{ 
    Task<bool> UploadImg(IFormFile file);

}