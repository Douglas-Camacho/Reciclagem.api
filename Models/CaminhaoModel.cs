namespace Reciclagem.api.Models
{
    public class CaminhaoModel
    {
        public int CaminhaoId { get; set; }
        public string? Placa { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        
    }

    public class CapacidadeCaminhaoModel
    {
        public int CaminhaoId { get; set; }
        public string? Local { get; set; }
        public double? Capacidade { get; set; }
        public double? NivelAtual { get; set; }
    }
}
