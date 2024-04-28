using Microsoft.EntityFrameworkCore; // para usar el dbcontext
using ApiRestASPNETCore.Models;

namespace ApiRestASPNETCore.Data
{
    public class Conexiones : DbContext
    {
        public Conexiones(DbContextOptions<Conexiones> options) : base(options)
        {
        }

        public DbSet<Vestimenta> Vestimentas { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Vestimenta>(tb =>
            {
                tb.HasKey(col => col.IdVestimenta); // es la primary key

                tb.Property(col => col.IdVestimenta)
                .UseIdentityColumn() // autoincrementable
                .ValueGeneratedOnAdd();

                tb.Property(col => col.Nombre).HasMaxLength(50).IsRequired(); 
                tb.Property(col => col.Precio).IsRequired();
                tb.Property(col => col.EnvioGratis).IsRequired();

            });

            modelBuilder.Entity<Vestimenta>().ToTable("Vestimenta");

        }
    }
}
