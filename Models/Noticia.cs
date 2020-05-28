using System;
using System.ComponentModel.DataAnnotations;

namespace at03.Models
{
    public class Noticia
    {
        [ScaffoldColumn(false)]
        [Key]
        public int id {get;set;}

        [Display(Name = "Título")]
        [Required]
        public string titulo { get; set; }

        [Display(Name = "Texto")]
        [Required]
        [DataType(DataType.MultilineText)]
        public string texto { get; set; }

        [ScaffoldColumn(false)]
        public int usuario_id { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Autor")]
        public string autor { get; set; }

        [Display(Name = "Data")]
        [Required]
        [DataType(DataType.Date)]
        public DateTime data { get; set; }
    }
}
