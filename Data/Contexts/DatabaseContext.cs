using Reciclagem.api.Models;
using Microsoft.EntityFrameworkCore;

namespace Reciclagem.api.Data.Contexts
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<UserModel> UserModel { get; set; }
        public DbSet<CidadaoModel> CidadaoModel { get; set; }
        public DbSet<CapacidadeCaminhaoModel> CapacidadeCaminhaoModel { get; set; }
        public DbSet<CaminhaoModel> CaminhaoModel { get; set; }
    }
}