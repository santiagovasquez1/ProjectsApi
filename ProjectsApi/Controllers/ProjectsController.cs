using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectsApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace ProjectsApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectsController :ControllerBase
    {
        [HttpGet("home")]
        public async Task<IActionResult> home()
        {
            return Ok("Hola mundo");
        }
        [HttpPost("create")]
        public async Task<IActionResult> create([FromBody] ProjectModel request)
        {
            return Ok(request);
        }

        [HttpPost("uploadImage/{id}")]
        public async Task<IActionResult> uploadImage()
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            this.createFolder("uploadsImages");

            try
            {
                HttpRequest request = HttpContext.Request;
                foreach(IFormFile file in request.Form.Files)
                {
                    string uploadPath = Path.Combine("uploadsImages", file.FileName);
                    using ( var fileStream =new FileStream(uploadPath,FileMode.Create))
                    {
                       await file.CopyToAsync(fileStream);
                    }
                }
                dict.Add("message", "Imagen guardada correctamente");
                return Ok(dict);
            }
            catch (Exception ex)
            {
                dict.Add("message", ex.Message);
                return BadRequest(dict);
            }
        }
        private void createFolder(string dirPath)
        {
            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }
        }
    }   
}
