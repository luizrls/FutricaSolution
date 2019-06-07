namespace FutricaApi.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Contexto : DbContext
    {
        public Contexto()
            : base("name=Contexto")
        {
        }

        public virtual DbSet<Conversa> Conversas { get; set; }
        public virtual DbSet<ConversasUsuario> ConversasUsuarios { get; set; }
        public virtual DbSet<MensagemTipos> MensagemTipos { get; set; }
        public virtual DbSet<Mensagen> Mensagens { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<UsuariosContato> UsuariosContatos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Conversa>()
                .Property(e => e.nome)
                .IsUnicode(false);

            modelBuilder.Entity<Conversa>()
                .HasMany(e => e.ConversasUsuarios)
                .WithRequired(e => e.Conversa)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Conversa>()
                .HasMany(e => e.Mensagens)
                .WithRequired(e => e.Conversa)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MensagemTipos>()
                .Property(e => e.nome)
                .IsUnicode(false);

            modelBuilder.Entity<MensagemTipos>()
                .HasMany(e => e.Mensagens)
                .WithRequired(e => e.MensagemTipos)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Mensagen>()
                .Property(e => e.usuarioNick)
                .IsUnicode(false);

            modelBuilder.Entity<Mensagen>()
                .Property(e => e.mensagem)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.senha)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.nick)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.ConversasUsuarios)
                .WithRequired(e => e.Usuario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.UsuariosContatos)
                .WithRequired(e => e.Usuario)
                .WillCascadeOnDelete(false);
        }
    }
}
