﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanchesWill.Models
{
    [Table("Categorias")]
    public class Categoria
    {
        [Key]
        public int CategoriaId { get; set; }

        [StringLength(100,ErrorMessage ="O tamanho máximo é 100")]
        [Required(ErrorMessage ="Informe o nome da Categoria")]
        [Display(Name ="Nome")]
        public string CategoriaNome { get; set; }

        [StringLength(200, ErrorMessage = "O tamanho máximo é 200")]
        [Required(ErrorMessage = "Informe a Descrição")]
        [Display(Name = "Nome")]
        public string Descricao { get; set; }

        public List<Lanche> Lanches { get; set; }   
    }
}
