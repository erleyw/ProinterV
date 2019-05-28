using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProinterV.Application.ViewModels
{
    public class TarefaViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O Código do Grupo é obrigatório")]
        [DisplayName("Id do Grupo")]
        public Guid IdGrupo { get; set; }

        [Required(ErrorMessage = "O Aluno Responsável é obrigatório")]
        [DisplayName("Aluno Responsável")]
        public Guid IdAluno { get; set; }

        [Required(ErrorMessage = "O nome da tarefa é obrigatória")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("Nome")]
        public string Nome { get; set; }

        [DisplayName("Descrição")]
        public string Descricao { get; set; }
    }
}
