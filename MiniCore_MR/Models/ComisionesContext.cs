using Microsoft.EntityFrameworkCore;

namespace MiniCore_MR.Models
{
    public class ComisionesContext : DbContext
    {
        public ComisionesContext(DbContextOptions<ComisionesContext> options)
            : base(options)
        {
        }

        public DbSet<Vendedor> Vendedores { get; set; }
        public DbSet<Venta> Ventas { get; set; }
        public DbSet<Regla> Reglas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vendedor>(entity =>
            {
                entity.ToTable("VENDEDOR");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .HasColumnName("id");

                entity.Property(e => e.Usuario)
                    .HasColumnName("usuario")
                    .HasMaxLength(100)
                    .IsRequired();
            });

            modelBuilder.Entity<Venta>(entity =>
            {
                entity.ToTable("VENTA");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .HasColumnName("id");

                entity.Property(e => e.FechaVenta)
                    .HasColumnName("fecha_venta")
                    .HasColumnType("date")
                    .IsRequired();

                entity.Property(e => e.VendedorId)
                    .HasColumnName("vendedor_id");

                entity.Property(e => e.Monto)
                    .HasColumnName("monto")
                    .HasColumnType("decimal(10,2)")
                    .IsRequired();

                entity.HasOne(v => v.Vendedor)
                    .WithMany(v => v.Ventas)
                    .HasForeignKey(v => v.VendedorId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Regla>(entity =>
            {
                entity.ToTable("REGLAS");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .HasColumnName("id");

                entity.Property(e => e.Porcentaje)
                    .HasColumnName("regla")
                    .HasColumnType("decimal(5,2)")
                    .IsRequired();

                entity.Property(e => e.ValorMinimo)
                    .HasColumnName("valor")
                    .HasColumnType("decimal(10,2)")
                    .IsRequired();
            });
        }
    }
}
