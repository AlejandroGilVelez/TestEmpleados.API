using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Framework.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestEmpleados.DataModel;

namespace TestEmpleados.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SubAreasController : ControllerBase
    {
        #region Atributos

        private readonly ISubAreaRepository subAreaRepository;

        #endregion

        #region Constructor

        public SubAreasController(ISubAreaRepository subAreaRepository)
        {
            this.subAreaRepository = subAreaRepository;
        }

        #endregion

        #region Acciones

        [HttpGet("Get/{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var subAreas = await subAreaRepository.FindAll(x => x.AreaId == id);

            if (subAreas == null)
            {
                return NotFound();
            }

            List<SubAreaDto> suAreaList = new List<SubAreaDto>();

            foreach (var item in subAreas)
            {
                suAreaList.Add(new SubAreaDto
                {
                    Id = item.Id,
                    Nombre = item.Nombres,
                    Descripcion = item.Descripcion
                });
            }

            return Ok(suAreaList);
        }

        #endregion
    }
}