using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using ProinterV.Domain.Models;
using ProinterV.Infra.Data.Mappings;

namespace ProinterV.Infra.Data.Context
{
    public partial class DbProinterContext : DbContext
    {
        private readonly IHostingEnvironment _env;

        public DbProinterContext(IHostingEnvironment env)
        {
            _env = env;
        }

        public virtual DbSet<Aluno> Aluno { get; set; }
        public virtual DbSet<AlunoGrupo> AlunoGrupo { get; set; }
        public virtual DbSet<ArquivoTarefa> ArquivoTarefa { get; set; }
        public virtual DbSet<GrupoTrabalho> GrupoTrabalho { get; set; }
        public virtual DbSet<Tarefa> Tarefa { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // pega as configurações do arquivo appsettings.json
            var config = new ConfigurationBuilder()
                .SetBasePath(_env.ContentRootPath)
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AlunoMap());
            modelBuilder.ApplyConfiguration(new AlunoGrupoMap());
            modelBuilder.ApplyConfiguration(new ArquivoTarefaMap());
            modelBuilder.ApplyConfiguration(new GrupoTrabalhoMap());
            modelBuilder.ApplyConfiguration(new TarefaMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
