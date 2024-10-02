using System.ComponentModel.DataAnnotations;

namespace Crud.Models
{
    public class Pessoa
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O Nome é obrigatório")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "A Idade é obrigatória")]
        [Range(0, 150, ErrorMessage = "A Idade deve estar entre 0 e 150")]
        public int Idade { get; set; }

        [Required(ErrorMessage = "O Email é obrigatório")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        public string Email { get; set; } = string.Empty;
    }
}
