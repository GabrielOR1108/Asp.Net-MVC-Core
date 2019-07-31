using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InfoWinDev.UI.Models
{
    [Table("Usuário")]
    public class Usuario:Entity
    {
        [Column(TypeName = "varchar(100)")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Nome { get; set; }
        [Column(TypeName = "varchar(100)")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Email { get; set; }
        [Column(TypeName = "varchar(100)")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Senha { get; set; }

    }
}
