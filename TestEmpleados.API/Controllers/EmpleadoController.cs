using Framework.Dtos;
using Framework.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using TestEmpleados.DataModel;

namespace TestEmpleados.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        #region Atributos

        private readonly IEmpleadoRepository empleadoRepository;

        #endregion

        #region Constructor

        public EmpleadoController(IEmpleadoRepository empleadoRepository)
        {
            this.empleadoRepository = empleadoRepository;
        }

        #endregion

        #region Acciones

        /// <summary>
        /// Metodo que retorna una lista de empleados
        /// </summary>
        /// <returns></returns>
        [HttpGet("List")]
        public async Task<IActionResult> List()
        {
            var result = await empleadoRepository.GetAll(x => x.TipoIdentificacion, x => x.Area);

            if (result == null)
            {
                return NotFound();
            }

            List<EmpleadoDto> empleadoList = new List<EmpleadoDto>();

            Parallel.ForEach(result, item => 
            {
                empleadoList.Add(new EmpleadoDto
                {
                    Id = item.Id,
                    NroIdentificacion = item.NroIdentificacion,
                    Nombres = item.Nombres,
                    Apellidos = item.Apellidos,
                    Telefono = item.Telefono,
                    Email = item.Email,
                    TipoIdentificacion = item.TipoIdentificacion.Nombre,
                    TipoIdentificacionId = item.TipoIdentificacion.Id,
                    Area = item.Area.Nombre,
                    AreaId = item.Area.Id
                });
            });         

            return Ok(empleadoList);

        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] EmpleadoDto empleado)
        {
            var result = await empleadoRepository.Find(x => x.Email == empleado.Email);

            if (result != null)
            {
                return BadRequest("El email ya existe");
            }          


            var nuevoEmpleado = new Empleado
            {
                Id = Guid.NewGuid(),
                NroIdentificacion = empleado.NroIdentificacion,
                Nombres = empleado.Nombres,
                Apellidos = empleado.Apellidos,
                Email = empleado.Email,
                Telefono = empleado.Telefono,                
                FechaCreacion = DateTime.Now,
                FechaModificacion = DateTime.Now
            };

            await empleadoRepository.Add(nuevoEmpleado);

            return Ok();

        }

        #endregion
    }
}