using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BlazorCRUD.Model;
using BlazorCRUD.UI.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlazorCRUD.UI.Controllers
{
    [Route("api/[controller]")]
    public class EmpleadoController : Controller
    {
        private readonly EmpleadoService _empleadoService;

        public EmpleadoController(EmpleadoService empleadoService)
        {
            _empleadoService = empleadoService;
        }

        // GET: api/<controller>
        [HttpGet]
        public ActionResult<List<Empleados>> GetAllEmpleados() =>
               _empleadoService.GetAllEmpleados();


        [HttpGet("{id:length(24)}", Name = "jasiel")]
        public ActionResult<Empleados> GetEmpleadosDetails(string id)
        {
            var empleado = _empleadoService.GetEmpleadosDetails(id);

            if (empleado == null)
            {
                return NotFound();
            }

            return empleado;
        }

        [HttpPost]
        public ActionResult<Empleados> InsertarEmpleado(Empleados empleado)
        {
            _empleadoService.InsertEmpleado(empleado);

            return CreatedAtRoute("pepe", new { id = empleado.Id.ToString() }, empleado);
        }


        [HttpPut("{id:length(24)}")]
        public IActionResult UpdateEmpleado(string id, Empleados empleadox)
        {
            var book = _empleadoService.GetEmpleadosDetails(id);

            if (book == null)
            {
                return NotFound();
            }

            _empleadoService.UpdateEmpleado(id, empleadox);

            return NoContent();
        }


        [HttpDelete("{id:length(24)}")]
        public IActionResult DeleteEmpleado(string id)
        {
            var empleado = _empleadoService.GetEmpleadosDetails(id);

            if (empleado == null)
            {
                return NotFound();
            }

            _empleadoService.DeleteEmpleado(empleado.Id);

            return NoContent();
        }
    }
}
