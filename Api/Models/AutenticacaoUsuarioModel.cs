using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class AutenticacaoUsuarioModel
    {
        [Required]
        public string Nome { get; set; }

        [Required]
        public string Senha { get; set; }
    }
}