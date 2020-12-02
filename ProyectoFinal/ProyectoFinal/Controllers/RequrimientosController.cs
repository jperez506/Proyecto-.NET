using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Api.Domain;
using System;

namespace ProyectoFinal.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequrimientosController : ControllerBase
    {
        //llamar a los handlers que son los que tienen la logica de cada requerimiento
        private ImageHandler imagenHandler;
        private PersonaHandler personaHandler;
        private TipoDeCambioHandler tipoDeCambioHandler;

        public RequrimientosController()
        {
            imagenHandler = new ImageHandler();
            personaHandler = new PersonaHandler();
            tipoDeCambioHandler = new TipoDeCambioHandler();
        }

        //metodo para obtener jpg o png
        [Route("api/imagen/{formato}")]
        [HttpGet]
        public IActionResult GetImagen(string formato)
        {
            var imagenComoBytes = imagenHandler.GetImagen(formato);
            return File(imagenComoBytes, $"image/{formato}");
        }

        //metodo para obtener 100 mejores salarios pir provincia
        [HttpGet]
        [Route("api/persona/mejoressalario/{provincia}")]
        public IActionResult GetMejoresSalarios(string provincia)
        {
            return Ok(personaHandler.getPersonasConMejorSalario(provincia));
        }
        
        //meetodo para obtener cantidad de genero dentro de un rango
        [HttpGet]
        [Route("api/persona/cantidad/genero/{edadInicial}/{edadFinal}")]
        public IActionResult GetCantidadDeGentePorGenero(int edadInicial, int edadFinal)
        {
            var esMujer = true;
            var hombres = personaHandler.getPersonas(!esMujer, edadInicial, edadFinal).Count;
            var mujeres = personaHandler.getPersonas(esMujer, edadInicial, edadFinal).Count;
            return Ok($"Rango:[{edadInicial}-{edadFinal}]. Hombres: {hombres}. Mujeres: {mujeres}.");
        }

        //tipo de cambio extraido del api del bccr
        [HttpGet]
        [Route("api/tipodecambio/{fecha}")]
        [Produces("application/json")]
        public IActionResult Get(string fecha)
        {
            return Ok(tipoDeCambioHandler.consigueTipoDeCambio(fecha));
        }
        
        //numero random del 1 al 3, que representa estado finaciero
        [HttpGet]
        public IActionResult GetNumeroRandom()
        {
            return Ok("Estado financiero: " +personaHandler.getNumeroRandom());

        }


    }
}