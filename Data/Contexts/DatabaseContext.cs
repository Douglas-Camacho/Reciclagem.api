using Reciclagem.api.Models;
using Microsoft.EntityFrameworkCore;

namespace Reciclagem.api.Data.Contexts
{
    public class DatabaseContext : DbContext
    {
        public virtual DbSet<CidadaoModel> Cidadaos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CidadaoModel>(entity =>
            {
                entity.ToTable("Cidadao");
                entity.HasKey(e => e.CidadaoId);
                entity.Property(e => e.Nome).IsRequired();
                entity.Property(e => e.Email).IsRequired();
                entity.Property(e => e.DataNascimento).HasColumnType("date");
            });
        }

        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }
        protected DatabaseContext()
        {
        }
    }
}
