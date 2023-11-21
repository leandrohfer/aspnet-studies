using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoInicialMVC.Models
{
    public class Aluno
    {
        [Key] // Mapeia que este campo é a chave da tabela
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")] // Valida se o campo é nulo
        [StringLength(30, MinimumLength = 2, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres")] // Valida a quantidade de caracteres do campo
        public string? Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DataType(DataType.DateTime, ErrorMessage = "O campo {0} está em formato incorreto")] // Valida se o campo está de acordo com o tipo de dado especificado
        [Display(Name = "Data de Nascimento")] // Forma de definir como o nome do campo será exibido
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(60, ErrorMessage = "O campo {0} precisa ter no máximo {1} caracteres")]
        // [EmailAddress(ErrorMessage = "O campo {0} está em formato inválido")] // Data Annotation para validar e-mail nativo do ASPNET
        [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage = "O campo {0} está em formato inválido")] // Expressão regular que valida e-mail
        public string? Email { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [Display(Name = "Confirme o e-mail")]
        [Compare("Email" , ErrorMessage = "Os e-mails informados não são idênticos")] // Valida se os valores deste campo são iguais aos valores do campo Email
        [NotMapped] // Informa que este campo não deve ser mapeado pelo banco de dados
        public string? EmailConfirmacao { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [Range(1, 5, ErrorMessage = "O campo {0} deve estar entre {1} e {2}")] // Valida se o campo está dentro de um determinado intervalo
        public int Avaliacao { get; set; }

        public bool Ativo { get; set; }
    }
}
