using Microsoft.AspNetCore.Mvc;

namespace foodbyte.Controllers;

public class UploadImgController : Controller
{
    /*
    readonly IPhotoService _iPhotoService;

    public UploadImgController(IPhotoService iPhotoService)
    {
        _iPhotoService = iPhotoService;
    }

    // GET
    public IActionResult ImgUpload()
    {
        return View();
    }

    [HttpPost]
    public async Task<ActionResult> ImgUpload(IFormFile file)
    {
        try
        {
            if (await _iPhotoService.UploadImg(file))
            {
                ViewBag.Message = "File Upload Successful";
            }
            else
            {
                ViewBag.Message = "File Upload Failed";
            }
        }
        catch (Exception ex)
        {
            //Log ex
            ViewBag.Message = "File Upload Failed";
        }
        return View();
    }
    */
}
