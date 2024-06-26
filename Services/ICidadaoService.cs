using Reciclagem.api.Models;

namespace Reciclagem.api.Services
{
    public interface ICidadaoService
    {
        IEnumerable<CidadaoModel> ListarCidadaos();
        IEnumerable<CidadaoModel> ListarCidadaos(int pagina, int tamanho = 10);
        IEnumerable<CidadaoModel> ListarCidadaosUltimaReferencia(int ultimoId, int tamanho = 10);
        CidadaoModel ObterCidadaoPorId(int id);
        void CriarCidadao(CidadaoModel cidadao);
        void AtualizarCidadao(CidadaoModel cidadao);
        void DeletarCidadao(int id);
    }
}
