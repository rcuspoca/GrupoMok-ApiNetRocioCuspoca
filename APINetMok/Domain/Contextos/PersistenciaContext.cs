using APINetMok.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace APINetMok.Dominio.Contextos
{
    public class PersistenciaContext : DbContext
    {
        public PersistenciaContext(DbContextOptions<PersistenciaContext> options) : base(options) { }

        // Creación de Atributos
        public DbSet<TipoIdentificacionEntity> TipoIdentificacionEntity { get; set; }
        public DbSet<EstudianteEntity> EstudianteEntity { get; set; }
        public DbSet<LibroEntity> LibroEntity { get; set; }
        public DbSet<PrestamoEntity> PrestamoEntity { get; set; }

        // El método OnModelCreating() nos permite configurar el modelo utilizando ModelBuilder Fluent API.
        //Este es el método de configuración más poderoso y permite especificar la configuración sin modificar sus clases de entidad.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EstudianteEntity>().HasKey(x => new { x.IdEstudiante });
            modelBuilder.Entity<LibroEntity>().HasKey(x => new { x.IdLibro });
            modelBuilder.Entity<PrestamoEntity>().HasKey(x => new { x.IdPrestamo });
        }
    }
}
