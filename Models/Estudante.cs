using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using IEL.Estudantes.Validations;

namespace IEL.Estudantes.Models
{
    public class Estudante
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório")]
        [StringLength(100, ErrorMessage = "O Nome não pode ter mais que 100 caracteres")]
        [Display(Name = "Nome")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo CPF é obrigatório")]
        [Cpf(ErrorMessage = "CPF inválido")]
        [Display(Name = "CPF")]
        [Remote(action: "VerifyCpf", controller: "Estudantes", 
                AdditionalFields = nameof(Id),
                ErrorMessage = "Este CPF já está cadastrado")]
        public string CPF { get; set; } = string.Empty;

        [StringLength(200, ErrorMessage = "O Endereço não pode ter mais que 200 caracteres")]
        [Display(Name = "Endereço")]
        public string? Endereco { get; set; }

        [Display(Name = "Data de Conclusão")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DataConclusao { get; set; }
    }
}