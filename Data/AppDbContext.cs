using Microsoft.EntityFrameworkCore;
using SistemaArtigos.API.Models;
using SistemaArtigos.API.Models.Enums;

namespace SistemaArtigos.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
           protected override void OnModelCreating(ModelBuilder modelBuilder)
{


    
    modelBuilder.Entity<Usuario>()
        .Property(u => u.NivelDeAcesso)
        .HasConversion(
            v => v.ToString().ToLower(),
            v => (NivelDeAcesso)Enum.Parse(typeof(NivelDeAcesso), v, true))
        .HasColumnType("enum('admin','moderador','leitor')");

 
    modelBuilder.Entity<Artigo>()
        .Property(a => a.NivelArtigo)
        .HasConversion(
            v => v.ToString().ToLower(),
            v => (EnumNivelArtigo)Enum.Parse(typeof(EnumNivelArtigo), v, true))
        .HasColumnType("enum('iniciante','intermediario','avancado','comunidade')");

    base.OnModelCreating(modelBuilder);




    modelBuilder.Entity<Favorito>()
    .HasKey(f => new { f.IdUsuario, f.IdArtigo });


    modelBuilder.Entity<Avaliacao>()
    .HasKey(a => new {a.IdUsuario, a.IdArtigo});

    



   modelBuilder.Entity<Artigo>()
    .Property(a => a.Status)
    .HasConversion(
        v => v == EnumStatus.EmAnalise ? "em_analise" : "publicado",
        v => v == "em_analise" ? EnumStatus.EmAnalise : EnumStatus.Publicado)
    .HasColumnType("enum('publicado','em_analise')");



    modelBuilder.Entity<Comentario>()
    .HasOne(c => c.ComentarioPai)
    .WithMany(c => c.Respostas)
    .HasForeignKey(c => c.IdComentarioPai)
    .OnDelete(DeleteBehavior.Cascade);
}
             

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Artigo> Artigos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Favorito> Favoritos { get; set; }
        public DbSet<Avaliacao> Avaliacoes {get; set;}
        public DbSet<Comentario> Comentarios { get; set; }
        public DbSet<CategoriaDArtigo> CategoriasDArtigos { get; set; }
        public DbSet<RascunhoDArtigo> RascunhosDArtigos { get; set; }
        public DbSet<VersaoDArtigo> VersoesDArtigos { get; set; }
    }
}