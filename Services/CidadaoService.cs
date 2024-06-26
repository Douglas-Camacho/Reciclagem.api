using Reciclagem.api.Models;
using Reciclagem.api.Data.Repository;
using Reciclagem.api.Data.Contexts;
using Microsoft.EntityFrameworkCore;


namespace Reciclagem.api.Services
{
    public class CidadaoService : ICidadaoService
    {
        private readonly ICidadaoRepository _repository;

        public CidadaoService(ICidadaoRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<CidadaoModel> ListarCidadaos() => _repository.GetAll();

        public IEnumerable<CidadaoModel> ListarCidadaos(int pagina, int tamanho = 10)
        {
           return _repository.GetAll(pagina, tamanho);
        }

        public IEnumerable<CidadaoModel> ListarCidadaosUltimaReferencia(int ultimoId, int tamanho = 10)
        {
            return _repository.GetAllReference(ultimoId, tamanho);
        }

        public void CriarCidadao(CidadaoModel cidadao) => _repository.Add(cidadao);
        public void AtualizarCidadao(CidadaoModel cidadao) => _repository.Update(cidadao);
        public void DeletarCidadao(int id)
        {
            var cidadao = _repository.GetById(id);
            if (cidadao != null)
            {
                _repository.Delete(cidadao);
            }
        }

        
        public CidadaoModel ObterCidadaoPorId(int id) => _repository.GetById(id);
    }
}
