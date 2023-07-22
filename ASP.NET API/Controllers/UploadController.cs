using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_API.Controllers
{
    [ApiController]
    [Route("/api/upload")]
    public class UploadController : ControllerBase
    {

        [HttpPost]
        [Route("image")]
        public IActionResult Index(IFormFile image)
        {
            if (image == null)
            {
                return BadRequest("Vui lòng gửi file đính kèm");
            }
            var path = "wwwroot/uploads";
            var fileName = Guid.NewGuid().ToString() + Path.GetFileName(image.FileName);
            var upload = Path.Combine(Directory.GetCurrentDirectory(), path, fileName);
            image.CopyTo(new FileStream(upload, FileMode.Create));
            var rs = $"{Request.Scheme}://{Request.Host}/uploads/{fileName}";
            return Ok(rs);
        }
    }
}
