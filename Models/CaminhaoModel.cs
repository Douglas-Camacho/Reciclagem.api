using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reciclagem.api.Models
{
    public class CaminhaoModel
    {
        [Key]

        public int CaminhaoId { get; set; }
        public string? Placa { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }

    }

    public class CapacidadeCaminhaoModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Vehicle")]
        public int CaminhaoId { get; set; }
        public string? Local { get; set; }
        public double? Capacidade { get; set; }
        public double? NivelAtual { get; set; }
    }
}
