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

        /// <summary>
        /// Método que retorna un empleado
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("Get/{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var empleado = await empleadoRepository.Find(x => x.Id == id, x => x.TipoIdentificacion, x => x.Area);

            if (empleado == null)
            {
                return NotFound();
            }

            var result = new EmpleadoDto
            {
                Id = empleado.Id,
                NroIdentificacion = empleado.NroIdentificacion,
                Nombres = empleado.Nombres,
                Apellidos = empleado.Apellidos,
                Email = empleado.Email,
                Telefono = empleado.Telefono,
                TipoIdentificacion = empleado.TipoIdentificacion.Nombre,
                TipoIdentificacionId = empleado.TipoIdentificacion.Id,
                Area = empleado.Area.Nombre,
                AreaId = empleado.Area.Id
            };

            return Ok(result);
        }

        /// <summary>
        /// Método que elimina un empleado.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await empleadoRepository.Find(x => x.Id == id);

            if (result == null)
            {
                return NotFound();
            }

            await empleadoRepository.Delete(result);

            return Ok();

        }

        /// <summary>
        /// Método que crea un empleado
        /// </summary>
        /// <param name="empleado"></param>
        /// <returns></returns>
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
                TipoIdentificacionId = empleado.TipoIdentificacionId,
                AreaId = empleado.AreaId,
                FechaModificacion = DateTime.Now
            };            

            await empleadoRepository.Add(nuevoEmpleado);

            return Ok();

        }

        /// <summary>
        /// Método que edita un empleado
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] EmpleadoDto empleado)
        {
            var result = await empleadoRepository.Find(x => x.Id == empleado.Id);

            if (result == null)
            {
                return BadRequest("El usuario no existe");
            }

            result.NroIdentificacion = empleado.NroIdentificacion;
            result.Nombres = empleado.Nombres;
            result.Apellidos = empleado.Apellidos;
            result.Email = empleado.Email;
            result.Telefono = empleado.Telefono;
            result.TipoIdentificacionId = empleado.TipoIdentificacionId;
            result.AreaId = empleado.AreaId;            
            result.FechaModificacion = DateTime.Now;            

            await empleadoRepository.Edit(result);

            return Ok();
        }

        #endregion
    }
}