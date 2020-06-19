using System.ComponentModel.DataAnnotations;

namespace Framework.Models
{
    public class SubArea : BaseModel
    {
        [Required]
        [MaxLength(300)]
        public string Nombres { get; set; }

        [Required]
        [MaxLength(300)]
        public string Descripcion { get; set; }

        public Area Area { get; set; }
    }
}
