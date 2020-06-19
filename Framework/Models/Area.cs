using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Framework.Models
{
    public class Area : BaseModel
    {
        [Required]
        [MaxLength(300)]
        public string Nombre { get; set; }

        [Required]
        [MaxLength(300)]
        public string Descripcion { get; set; }

        public List<SubArea> SubArea { get; set; }
    }
}
