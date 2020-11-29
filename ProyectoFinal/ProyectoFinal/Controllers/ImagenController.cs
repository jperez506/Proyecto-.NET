using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Api.Domain;

namespace ProyectoFinal.Api.Controllers
{
    [ApiController]
    public class ImagenController : ControllerBase
    {
        private ImageHandler imagenHandler;
        public ImagenController()
        {
            imagenHandler = new ImageHandler();
        }

        [Route("api/imagen/{formato}")]
        [HttpGet]
        public IActionResult GetImagen(string formato) 
        {
            var imagenComoBytes = imagenHandler.GetImagen(formato);
            return File(imagenComoBytes, $"image/{formato}");
        }
    }
}
