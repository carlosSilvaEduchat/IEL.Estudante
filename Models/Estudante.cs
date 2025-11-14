using System;
using System.ComponentModel.DataAnnotations;

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
        [RegularExpression(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$",
            ErrorMessage = "O CPF deve estar no formato 000.000.000-00")]
        [Display(Name = "CPF")]
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