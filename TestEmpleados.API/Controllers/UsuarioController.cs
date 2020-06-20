using Framework.Dtos;
using Framework.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestEmpleados.API.Utilidades;
using TestEmpleados.DataModel;

namespace TestEmpleados.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        #region Atributos

        private readonly IUsuarioRepository ususarioRepository;


        #endregion

        #region Constructor

        public UsuarioController(IUsuarioRepository ususarioRepository)
        {
            this.ususarioRepository = ususarioRepository;
        }

        #endregion

        #region Acciones

        /// <summary>
        /// Método que retorna una lista de usuarios.
        /// </summary>
        /// <returns></returns>
        [HttpGet("List")]
        public async Task<IActionResult> List()
        {
            var result = await ususarioRepository.GetAll();

            if (result == null)
            {
                return NotFound();
            }

            List<UsuarioDto> usuarioList = new List<UsuarioDto>();

            foreach (var item in result)
            {
                usuarioList.Add(new UsuarioDto
                {
                    Id = item.Id,
                    NroIdentificacion = item.NroIdentificacion,
                    Nombres = item.Nombres,
                    Apellidos = item.Apellidos,
                    Email = item.Email,
                    Telefono = item.Telefono,
                    Activo = item.Activo
                });

            }

            return Ok(usuarioList);
            
        }

        /// <summary>
        /// Método que retorna un usuario
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("Get/{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await ususarioRepository.Find(x => x.Id == id);

            if (result == null)
            {
                return NotFound();
            }

            var usuario = new UsuarioDto
            {
                Id = result.Id,
                NroIdentificacion = result.NroIdentificacion,
                Nombres = result.Nombres,
                Apellidos = result.Apellidos,
                Email = result.Email,
                Telefono = result.Telefono,
                Activo = result.Activo
            };

            return Ok(usuario);
        }

        /// <summary>
        /// Método que elimina un usuario.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await ususarioRepository.Find(x => x.Id == id);

            if (result == null)
            {
                return NotFound();
            }

            await ususarioRepository.Delete(result);

            return Ok();

        }

        /// <summary>
        /// Método que crea un usuario.
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] UsuarioDto usuario)
        {
            var result = await ususarioRepository.Find(x => x.Email == usuario.Email);

            if (result != null)
            {
                return BadRequest("El email ya existe");
            }

            usuario.Password = usuario.NroIdentificacion.ToString();

            byte[] passwordHash, passwordSalt;

            SeguridadPassword.CreatePasswordHash(usuario.Password, out passwordHash, out passwordSalt);

            var nuevoUsuario = new Usuario
            {
                Id = Guid.NewGuid(),
                NroIdentificacion = usuario.NroIdentificacion,
                Nombres = usuario.Nombres,
                Apellidos = usuario.Apellidos,
                Email = usuario.Email,
                Telefono = usuario.Telefono,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Activo = usuario.Activo,
                FechaCreacion = DateTime.Now,
                FechaModificacion = DateTime.Now
            };

            await ususarioRepository.Add(nuevoUsuario);

            return Ok();

        }

        /// <summary>
        /// Método que edita un usuario
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UsuarioDto usuario)
        {
            var result = await ususarioRepository.Find(x => x.Id == usuario.Id);

            if (result == null)
            {
                return BadRequest("El usuario no existe");
            }

            result.NroIdentificacion = usuario.NroIdentificacion;
            result.Nombres = usuario.Nombres;
            result.Apellidos = usuario.Apellidos;
            result.Email = usuario.Email;
            result.Telefono = usuario.Telefono;
            result.FechaModificacion = DateTime.Now;
            result.Activo = usuario.Activo;

            await ususarioRepository.Edit(result);

            return Ok();
        }

        #endregion


    }
}