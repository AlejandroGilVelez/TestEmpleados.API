using Framework.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Dtos
{
    public class EmpleadoDto
    {
        public Guid Id { get; set; }

        public long NroIdentificacion { get; set; }

        public string Nombres { get; set; }

        public string Apellidos { get; set; }

        public string Email { get; set; }

        public string Telefono { get; set; }

        public string TipoIdentificacion { get; set; }
        public Guid TipoIdentificacionId { get; set; }

        public string Area { get; set; }
        public Guid AreaId { get; set; }
    }
}
