using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProinterV.Application.ViewModels
{
    public class ArquivoTarefaViewModel
    {
        [Required(ErrorMessage = "O Código da tarefa é obrigatória")]
        [DisplayName("Id da Tarefa")]
        public Guid IdTarefa { get; set; }

        [DisplayName("Aluno")]
        public Guid? IdAluno { get; set; }

        [Required(ErrorMessage = "O nome do arquivo é obrigatório")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("Nome")]
        public string Nome { get; set; }

        [DisplayName("Público")]
        public bool Publico { get; set; }

        [Required(ErrorMessage = "O arquivo é obrigatório")]
        [DisplayName("Arquivo")]
        public string Arquivo { get; set; }
    }
}
