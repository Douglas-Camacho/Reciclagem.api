using Reciclagem.api.Data.Repository;
using Reciclagem.api.Models;
using Reciclagem.api.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Reciclagem.api.Data.Repository
{
    public class CidadaoRepository : ICidadaoRepository
    {
        private readonly DatabaseContext _context;
        public CidadaoRepository(DatabaseContext context)
        {
            _context = context;
        }

        public IEnumerable<CidadaoModel> GetAll() => _context.Set<CidadaoModel>().ToList();

        public IEnumerable<CidadaoModel> GetAll(int page, int size)
        { 
            return _context.Set<CidadaoModel>()
                .Skip((page - 1) * page)
                .Take(size)
                .AsNoTracking()
                .ToList();
        }

        public IEnumerable<CidadaoModel> GetAllReference(int lastReference, int size)
        {
            var cidadaos = _context.Set<CidadaoModel>()
                .Where(c => c.CidadaoId > lastReference)
                .OrderBy(c => c.CidadaoId)
                .Take(size)
                .AsNoTracking()
                .ToList();
            return cidadaos;
        }

        public CidadaoModel GetById(int id) => _context.Set<CidadaoModel>().Find(id);

        public void Add(CidadaoModel cidadao)
        {
            _context.Set<CidadaoModel>().Add(cidadao);
            _context.SaveChanges();
        }

        public void Update(CidadaoModel cidadao)
        {
            _context.Set<CidadaoModel>().Update(cidadao);
            _context.SaveChanges();
        }

        public void Delete(CidadaoModel cidadao)
        {
            _context.Set<CidadaoModel>().Remove(cidadao);
            _context.SaveChanges();
        }
    }
}
