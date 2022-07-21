using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorImagesController : ControllerBase
    {
        IColorImageService _colorImageService;

        public ColorImagesController(IColorImageService colorImageService)
        {
            _colorImageService = colorImageService;
        }


        [HttpPost("add")]

        public IActionResult Add([FromForm] IFormFile file, [FromForm] ColorImage colorImage)
        {
            var result = _colorImageService.Add(file, colorImage);
            if (result.Success )
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPost("update")]
       
        public IActionResult Update([FromForm] IFormFile file, [FromForm] ColorImage colorImage)
        {
            var result = _colorImageService.Update(file, colorImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]

        public IActionResult Delete(ColorImage colorImage)
        {
            var colorImageDelete = _colorImageService.GetByImageId(colorImage.Id).Data;
            var result = _colorImageService.Delete(colorImageDelete);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _colorImageService.GetAll();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyimageid")]
        public IActionResult GetByImageId(int imageId)
        {
            var result = _colorImageService.GetByImageId(imageId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpGet("getbycolorid")]
        public IActionResult GetByColorId(int colorId)
        {
            var result = _colorImageService.GetByColorId(colorId);
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);
        }
    }
}
