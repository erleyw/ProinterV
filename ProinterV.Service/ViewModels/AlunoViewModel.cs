using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProinterV.Application.ViewModels
{
    public class AlunoViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O login é obrigatório")]
        [EmailAddress]
        [DisplayName("Login")]
        public string Login { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória")]
        [DisplayName("Senha")]
        public string Senha { get; set; }
    }
}
