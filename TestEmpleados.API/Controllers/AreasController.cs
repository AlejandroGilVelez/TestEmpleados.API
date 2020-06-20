using Framework.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestEmpleados.DataModel;

namespace TestEmpleados.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AreasController : ControllerBase
    {
        #region Atributos

        private readonly IAreaRepository areaRepository;

        #endregion

        #region Constructor
        
        public AreasController(IAreaRepository areaRepository)
        {
            this.areaRepository = areaRepository;
        }

        #endregion

        #region Acciones

        /// <summary>
        /// Método que retorna una lista de áreas.
        /// </summary>
        /// <returns></returns>
        [HttpGet("List")]
        public async Task<IActionResult> List()
        {
            var result = await areaRepository.GetAll();

            if (result == null)
            {
                return NotFound();
            }

            List<AreaDto> areaList = new List<AreaDto>();

            foreach (var item in result)
            {
                areaList.Add(new AreaDto
                {
                    Id = item.Id,
                    Nombre = item.Nombre,
                    Descripcion = item.Descripcion
                });
            }           

            return Ok(areaList);

        }

        #endregion
    }
}