using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanchesWill.Models
{
    public class Pedido
    {
        public int PedidoId { get; set; }

        [Required(ErrorMessage = "Informe o nome")]
        [StringLength(50)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe o sobrenome")]
        [StringLength(50)]
        public string Sobrenome { get; set; }

        [Required(ErrorMessage = "Informe o Endereço 1")]
        [StringLength(100)]
        public string Endereco1 { get; set; }

        [Required(ErrorMessage = "Informe o Endereço 2")]
        [StringLength(100)]
        public string Endereco2 { get; set; }

        [Required(ErrorMessage = "Informe o CEP")]
        [Display(Name = "CEP")]
        [StringLength(10, MinimumLength = 8)]
        public string CEP { get; set; }

        [StringLength(10)]
        public string Estado { get; set; }

        [StringLength(50)]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Informe seu Telefone")]
        [StringLength(25)]
        [DataType(DataType.PhoneNumber)]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Informe seu Email")]
        [StringLength(50)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [ScaffoldColumn(false)]
        [Column(TypeName = "decimal(18,2)")]
        [Display(Name = "Total do Pedido")]
        public decimal PedidoTotal { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Itens no Pedido")]
        public int TotalItensPedidos { get; set; }

        [Display(Name = "Data do Pedido")]
        [DataType(DataType.Text)]
        [DisplayFormat(DataFormatString = "{0: dd/MM/yyyy hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime PedidoEnviado { get; set; }

        [Display(Name = "Data Envio Pedido")]
        [DataType(DataType.Text)]
        [DisplayFormat(DataFormatString = "{0: dd/MM/yyyy hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime? PedidoEntregueEm { get; set; }

        public List<PedidoDetalhe> PedidoItens { get; set; }


    }
}
