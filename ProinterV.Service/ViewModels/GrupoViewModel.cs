using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProinterV.Application.ViewModels
{
    public class GrupoViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O líder do grupo é obrigatório")]
        [DisplayName("Líder do Grupo")]
        public Guid IdAlunoLider { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        [DisplayName("Nome")]
        public string Nome { get; set; }

        [DisplayName("Descrição")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O prazo é obrigatório")]
        [DisplayName("Prazo")]
        public DateTime Prazo { get; set; }

        [DisplayName("Material de Apoio")]
        public string MaterialApoio { get; set; }

    }
}
