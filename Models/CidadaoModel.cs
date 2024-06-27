using System.ComponentModel.DataAnnotations;

namespace Reciclagem.api.Models
{
    public class CidadaoModel
    {
        [Key]
        public int CidadaoId { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public DateTime? DataNascimento { get; set; }

    }
}
