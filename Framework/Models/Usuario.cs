using System.ComponentModel.DataAnnotations;

namespace Framework.Models
{
    public class Usuario : BaseModel
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
        
        [MaxLength(100)]
        public string Telefono { get; set; }

        [Required]
        public byte[] PasswordHash { get; set; }

        [Required]
        public byte[] PasswordSalt { get; set; }

        [Required]
        public bool Activo { get; set; }

    }
}
