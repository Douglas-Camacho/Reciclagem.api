using Reciclagem.api.Models;

namespace Reciclagem.api.Data.Repository
{
    public interface ICidadaoRepository
    {
        IEnumerable<CidadaoModel> GetAll();
        IEnumerable<CidadaoModel> GetAll(int page, int size);
        IEnumerable<CidadaoModel> GetAllReference(int lastReference, int size);
        CidadaoModel GetById(int id);
        void Add(CidadaoModel cidadao);
        void Update(CidadaoModel cidadao);
        void Delete(CidadaoModel cidadao);
    }
}
