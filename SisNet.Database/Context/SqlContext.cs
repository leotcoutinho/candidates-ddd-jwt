using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SisNet.Database.Mappings;
using SisNet.Domain.Models;

namespace SisNet.Database.Context
{
    public class SqlContext : DbContext
    {
        #region "***instanciando o banco"

        // construtor foi comentado para o uso do OnConfiguring para configurar o EF para o migrations
        // public SqlContext(DbContextOptions<SqlContext> options) : base(options) { } 


        // Posso usar o OnConfiguring para instanciar o banco com a string isolada no arquivo json,
        // nesse caso não necessita usar o contrutor porque ele necessita criar uma factory

        // >> essa classe é apenas para uso do Migration(code-first)

        //public class SqlContextFactory : IDesignTimeDbContextFactory<SqlContext>
        //{
        //    public SqlContext CreateDbContext(string[] args)
        //    {
        //        var configurationBuilder = new ConfigurationBuilder();
        //        var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
        //        configurationBuilder.AddJsonFile(path, false);

        //        var root = configurationBuilder.Build();
        //        var connectionString = root.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value;

        //        //instanciar a classe DataContext
        //        var builder = new DbContextOptionsBuilder<SqlContext>();

        //        builder.UseSqlServer(connectionString);

        //        return new SqlContext(builder.Options);
        //    }
        //}


        #endregion

        public SqlContext(DbContextOptions<SqlContext> options) : base(options) { }

        public DbSet<Vaga> Vaga { get; set; }
        public DbSet<Candidato> Candidato { get; set; }
        public DbSet<CandidatoVaga> CandidatoVaga { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // mappings ORM
            modelBuilder.ApplyConfiguration(new VagaMap());
            modelBuilder.ApplyConfiguration(new CandidatoMap());
            modelBuilder.ApplyConfiguration(new CandidatoVagaMap());

            // adicionando índices
            modelBuilder.Entity<Vaga>(entity =>
            {
                entity.HasIndex(x => x.Codigo).IsUnique();
            });

            modelBuilder.Entity<Candidato>(entity =>
            {
                entity.HasIndex(x => x.Cpf).IsUnique();
            });

            modelBuilder.Entity<CandidatoVaga>(entity =>
            {
                entity.HasIndex(x => x.CandidatoId).IsUnique();
                entity.HasIndex(x => x.VagaId).IsUnique();
            });           
        }

        // configurando o banco com a connection string isolada para o migrations(code-first)
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            // configurando a string de conexão isolada
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();

                var connectionString = configuration.GetConnectionString("DefaultConnection");

                optionsBuilder.UseSqlServer(connectionString);
            }
        }      
                
    }

}

