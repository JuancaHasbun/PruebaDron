using Drones.Datos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Drones.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DronesController : Controller
    {
        Dato datos = new Dato();

        [HttpPost]
        public IActionResult guardarDron(string num, string modelo, int peso, int capbat, string estado)
        {
            string guardado = datos.crearDron(num, modelo, peso, capbat, estado);

            return Content(guardado, "application/json");
        }
        [HttpPost]
        public IActionResult cargaDron(string numDeSerie, string medicamento)
        {
            string carga = datos.cargarDron(numDeSerie, medicamento);

            return Content(carga, "application/json");
        }
        [HttpGet]
        public IActionResult dronParaCarga(string num, string modelo, int peso, int capbat, string estado)
        {
            string paraCarga = datos.DronParaCarga();

            return Content(paraCarga, "application/json");
        }
        [HttpGet]
        public IActionResult comprobarBateria(string numDeSerie)
        {
            string bateria = datos.comprobarBateria(numDeSerie);

            return Content(bateria, "application/json");
        }
         [HttpGet]
        public IActionResult comprobarPeso(string numDeSerie)
        {
            string peso = datos.comprobarPeso(numDeSerie);

            return Content(peso, "application/json");
        }


    }
}
