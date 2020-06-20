using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Framework.Models
{
    public class TipoIdentificacion : BaseModel
    {
        [Required]
        [MaxLength(10)]
        public string Nombre { get; set; }

        [Required]
        [MaxLength(150)]
        public string Descripcion { get; set; }

        public List<Empleado> Empleado { get; set; }

    }
}
