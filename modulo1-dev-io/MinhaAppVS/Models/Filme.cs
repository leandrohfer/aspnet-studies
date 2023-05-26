using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinhaAppVS.Models
{
    public class Filme
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo título é obrigatório")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "O título precisa ter entre 3 e 60 caracteres")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "O campo data de lançamento é obrigatório")]
        [DataType(DataType.DateTime, ErrorMessage = "Data em formato incorreto")]
        [Display(Name = "Data de Lançamento")]
        public DateTime DataLancamento { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z\u00C0-\u00FF""'\w-]*$", ErrorMessage = "Gênero em formato inválido")]
        [StringLength(30, ErrorMessage = "Máximo de 30 caracteres"), Required(ErrorMessage = "O campo Gênero é obrigatório")]
        public string Genero { get; set; }

        [Range(1,1000, ErrorMessage = "O preço do filme deve ser de R$1 à R$1000")]
        [Required(ErrorMessage = "O campo Preço é obrigatório")]
        [Column(TypeName = "decimal(18,2)")]
        [Display(Name = "Preço")]
        public decimal Preco { get; set; }

        [Required(ErrorMessage = "O campo Avaliação é obrigatório")]
        [RegularExpression(@"^[0-5]*$", ErrorMessage = "O campo Avaliação só pode receber números")]
        [Display(Name = "Avaliação")]
        public int Avaliacao { get; set; }
    }
}
