using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Api.Domain;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProyectoFinal.Api.Controllers
{
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private PersonaHandler personaHandler;

        public PersonaController() 
        {
            personaHandler = new PersonaHandler();
        }

        [HttpGet]
        [Route("api/persona/mejoressalario/{provincia}")]
        public IActionResult GetMejoresSalarios(string provincia)
        {
            return Ok(personaHandler.getPersonasConMejorSalario(provincia));
        }

        [HttpGet]
        [Route("api/persona/cantidad/genero/{edadInicial}/{edadFinal}")]
        public IActionResult GetCantidadDeGentePorGenero(int edadInicial, int edadFinal)
        {
            var esMujer = true;
            var hombres = personaHandler.getPersonas(!esMujer, edadInicial, edadFinal).Count;
            var mujeres = personaHandler.getPersonas(esMujer, edadInicial, edadFinal).Count;
            return Ok($"Rango:[{edadInicial}-{edadFinal}]. Hombres: {hombres}. Mujeres: {mujeres}.");
        }

        [HttpGet]
        [Route("api/persona/{cantidad}")]
        public void llenarDB(int cantidad)
        {
            personaHandler.PopularLaDB(cantidad);
        }
    }
}
