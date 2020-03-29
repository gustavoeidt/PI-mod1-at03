using System;
using System.ComponentModel.DataAnnotations;

namespace at03.Models
{
    public class Noticia
    {
        [Display(Name = "Título")]
        [Required]
        public string titulo { get; set; }

        [Display(Name = "Texto")]
        [Required]
        [DataType(DataType.MultilineText)]
        public string texto { get; set; }

        [Display(Name = "Autor")]
        [Required]
        public string autor { get; set; }

        [Display(Name = "Data")]
        [Required]
        [DataType(DataType.Date)]
        public DateTime data { get; set; }
    }
}
