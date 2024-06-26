using Reciclagem.api.Models;

namespace Reciclagem.api.Services
{
    public interface ICidadaoService
    {
        IEnumerable<CidadaoModel> ListarCidadaos();
        CidadaoModel ObterCidadaoPorId(int id);
        void CriarCidadao(CidadaoModel cidadao);
        void AtualizarCidadao(CidadaoModel cidadao);
        void DeletarCidadao(int id);
    }
}
