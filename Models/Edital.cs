using System;
using System.ComponentModel.DataAnnotations;

namespace at03.Models
{
    public class Edital
    {
        [ScaffoldColumn(false)]
        [Key]
        public int id {get;set;}

        [ScaffoldColumn(false)]
        public int usuario_id { get; set;}

        [Display(Name = "Nome do Órgão")]
        [Required]
        public string orgao { get; set; }

        [Display(Name = "Nome do Cargo")]
        [Required]
        public string cargo { get; set; }

        [Display(Name = "Nome da Banca")]
        [Required]
        public string banca { get; set; }

        [Display(Name = "Remuneração")]
        [Required]
        public double remuneracao { get; set; }

        [Display(Name = "Vagas")]
        [Required]
        public double vagas { get; set; }

        [Display(Name = "Link para o Edital")]
        [Required]
        [Url]
        public string link_edital {get; set;}
    }
}
