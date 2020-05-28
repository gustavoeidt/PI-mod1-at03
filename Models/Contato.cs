using System;
using System.ComponentModel.DataAnnotations;

namespace at03.Models
{
    public class Contato
    {
        [Display(Name = "Nome")]
        [Required]
        public string nome { get; set; }

        [Display(Name = "E-Mail")]
        [Required]
        public string email { get; set; }

        [Display(Name = "Assunto")]
        [Required]
        [DataType(DataType.MultilineText)]
        public string assunto { get; set; }
    }
}
