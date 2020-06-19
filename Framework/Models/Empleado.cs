using System.ComponentModel.DataAnnotations;

namespace Framework.Models
{
    public class Empleado : BaseModel
    {
        [Required]
        public long NroIdentificacion { get; set; }

        [Required]
        [MaxLength(150)]
        public string Nombres { get; set; }

        [Required]
        [MaxLength(150)]
        public string Apellidos { get; set; }

        [Required]
        [MaxLength(200)]
        public string Email { get; set; }

        public TipoIdentificacion TipoIdentificacion { get; set; }

        public Area Area { get; set; }
    }
}
