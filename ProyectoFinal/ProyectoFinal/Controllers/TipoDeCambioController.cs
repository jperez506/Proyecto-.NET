using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Api.Domain;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProyectoFinal.Api.Controllers
{
    public class TipoDeCambioController : ControllerBase
    {
        private readonly TipoDeCambioHandler tipoDeCambioHandler;
        public TipoDeCambioController() 
        {
            tipoDeCambioHandler = new TipoDeCambioHandler();
        }

        // GET: api/<TipoDeCambioController>
        [HttpGet]
        [Route("api/tipodecambio/{fecha}")]
        [Produces("application/json")]
        public IActionResult Get(string fecha)
        {
            return Ok(tipoDeCambioHandler.consigueTipoDeCambio(fecha));
        }

    }
}
