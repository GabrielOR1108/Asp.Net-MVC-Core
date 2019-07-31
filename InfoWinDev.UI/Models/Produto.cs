using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InfoWinDev.UI.Models
{

    [Table(nameof (Produto))]
    public class Produto:Entity
    {
       

        [Column(TypeName ="varchar(100)")]
        [Required(ErrorMessage ="Campo Obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public int TipoProdutoId { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [Column(TypeName ="money")]
        public decimal Valor { get; set; }

        [ForeignKey(nameof(TipoProdutoId))]
        public TipoProduto Tipo { get; set; }

        [Column(TypeName = "varchar(300)")]
        [StringLength(300,ErrorMessage ="Limite de Caracteres excedido.")]
        public string Descricao { get; set; }
    }
}
