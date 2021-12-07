using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SpMadicalGrup.Domains;

#nullable disable

namespace SpMadicalGrup.Contexts
{
    public partial class SpMadicalContext : DbContext
    {
        public SpMadicalContext()
        {
        }

        public SpMadicalContext(DbContextOptions<SpMadicalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Clinica> Clinicas { get; set; }
        public virtual DbSet<Consultum> Consulta { get; set; }
        public virtual DbSet<Medico> Medicos { get; set; }
        public virtual DbSet<Paciente> Pacientes { get; set; }
        public virtual DbSet<Situacao> Situacaos { get; set; }
        public virtual DbSet<TipoMedico> TipoMedicos { get; set; }
        public virtual DbSet<TipoUsuario> TipoUsuarios { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                //optionsBuilder.UseSqlServer("Data Source=HALLISONSIARA\\SQLEXPRESS; initial catalog=SPMedicalGrup; user id=sa; pwd=senai@132;");
                optionsBuilder.UseSqlServer("Data Source=CYBERNOTE-02\\SQLEXPRESS; initial catalog=SPMedicalGroup_israel; user id=sa; pwd=Senai@132;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Clinica>(entity =>
            {
                entity.ToTable("Clinica");

                entity.Property(e => e.ClinicaId).HasColumnName("CLinicaID");

                entity.Property(e => e.Cnpj)
                    .IsRequired()
                    .HasMaxLength(14)
                    .IsUnicode(false)
                    .HasColumnName("CNPJ");

                entity.Property(e => e.Endereco)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.NomeFantasia)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RazaoSocial)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Consultum>(entity =>
            {
                entity.HasKey(e => e.ConsultaId)
                    .HasName("PK__Consulta__7D0B7DAC1716CF02");

                entity.Property(e => e.ConsultaId).HasColumnName("ConsultaID");

                entity.Property(e => e.DataConsulta).HasColumnType("datetime");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.MedicoId).HasColumnName("MedicoID");

                entity.Property(e => e.PacienteId).HasColumnName("PacienteID");

                entity.Property(e => e.SituacaoId)
                    .HasColumnName("SituacaoID")
                    .HasDefaultValueSql("((1))");

                entity.HasOne(d => d.Medico)
                    .WithMany(p => p.Consulta)
                    .HasForeignKey(d => d.MedicoId)
                    .HasConstraintName("FK__Consulta__Medico__5629CD9C");

                entity.HasOne(d => d.Paciente)
                    .WithMany(p => p.Consulta)
                    .HasForeignKey(d => d.PacienteId)
                    .HasConstraintName("FK__Consulta__Pacien__59063A47");

                entity.HasOne(d => d.Situacao)
                    .WithMany(p => p.Consulta)
                    .HasForeignKey(d => d.SituacaoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Consulta__Situac__571DF1D5");
            });

            modelBuilder.Entity<Medico>(entity =>
            {
                entity.ToTable("Medico");

                entity.Property(e => e.MedicoId).HasColumnName("MedicoID");

                entity.Property(e => e.ClinicaId).HasColumnName("ClinicaID");

                entity.Property(e => e.Crm)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.TipoMedicoId).HasColumnName("TipoMedicoID");

                entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");

                entity.HasOne(d => d.Clinica)
                    .WithMany(p => p.Medicos)
                    .HasForeignKey(d => d.ClinicaId)
                    .HasConstraintName("FK__Medico__ClinicaI__45F365D3");

                entity.HasOne(d => d.TipoMedico)
                    .WithMany(p => p.Medicos)
                    .HasForeignKey(d => d.TipoMedicoId)
                    .HasConstraintName("FK__Medico__TipoMedi__47DBAE45");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.Medicos)
                    .HasForeignKey(d => d.UsuarioId)
                    .HasConstraintName("FK__Medico__UsuarioI__46E78A0C");
            });

            modelBuilder.Entity<Paciente>(entity =>
            {
                entity.ToTable("Paciente");

                entity.HasIndex(e => e.Cpf, "UQ__Paciente__C1FF93093F9ED45F")
                    .IsUnique();

                entity.Property(e => e.PacienteId).HasColumnName("PacienteID");

                entity.Property(e => e.Cpf)
                    .IsRequired()
                    .HasMaxLength(14)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.DataNacimento).HasColumnType("date");

                entity.Property(e => e.Endereco)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Rg)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("RG");

                entity.Property(e => e.Telefone)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.Pacientes)
                    .HasForeignKey(d => d.UsuarioId)
                    .HasConstraintName("FK__Paciente__Usuari__4316F928");
            });

            modelBuilder.Entity<Situacao>(entity =>
            {
                entity.ToTable("Situacao");

                entity.Property(e => e.SituacaoId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("SituacaoID");

                entity.Property(e => e.NomeSituacao)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoMedico>(entity =>
            {
                entity.ToTable("TipoMedico");

                entity.Property(e => e.TipoMedicoId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("TipoMedicoID");

                entity.Property(e => e.NomeTipo)
                    .IsRequired()
                    .HasMaxLength(55)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                entity.ToTable("TipoUsuario");

                entity.Property(e => e.TipoUsuarioId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("TipoUsuarioID");

                entity.Property(e => e.NomeTipo)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("Usuario");

                entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TipoUsuarioId).HasColumnName("TipoUsuarioID");

                entity.HasOne(d => d.TipoUsuario)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.TipoUsuarioId)
                    .HasConstraintName("FK__Usuario__TipoUsu__3E52440B");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
