using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Models
{
    public class Filme
    {
        [Required (ErrorMessage = "O Campo Titulo é obrigatório")]
        [StringLength(200, ErrorMessage = "Length 200")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "O Campo Diretor é obrigatório")]
        [StringLength(100,ErrorMessage = "Length 100")]
        public string Diretor { get; set; }

        [StringLength(50, ErrorMessage = "Length 50")]
        public string Genero { get; set; }


        [Required(ErrorMessage = "O Campo Duracao é obrigatório")]
        [Range(1,600, ErrorMessage ="Fora do Range Permitido")]
        public int Duracao { get; set; }

    }
}
