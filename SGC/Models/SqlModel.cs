namespace SGC.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SQLModel : DbContext
    {
        public SQLModel()
            : base("name=SQLModel")
        {
        }

        public virtual DbSet<T_Documentos> T_Documentos { get; set; }
        public virtual DbSet<T_Tipo_Documento> T_Tipo_Documento { get; set; }
        public virtual DbSet<T_Area> T_Area { get; set; }
        public virtual DbSet<T_Departamento> T_Departamento { get; set; }
        public virtual DbSet<T_Movimientos> T_Movimientos { get; set; }
        public virtual DbSet<T_Status> T_Status { get; set; }
        public virtual DbSet<T_Comunicados> T_Comunicados { get; set; }
        public virtual DbSet<T_Interfaz> T_Interfaz { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<T_Documentos>()
                .Property(e => e.Codificacion)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_Documentos>()
                .Property(e => e.PriCodAdi)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_Documentos>()
                .Property(e => e.SegCodAdi)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_Tipo_Documento>()
                .HasMany(e => e.T_Documentos)
                .WithRequired(e => e.T_Tipo_Documento)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<T_Area>()
                .Property(e => e.Clave_Area)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_Area>()
                .HasMany(e => e.T_Documentos)
                .WithRequired(e => e.T_Area)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<T_Departamento>()
                .Property(e => e.Clave_Depart)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_Departamento>()
                .HasMany(e => e.T_Documentos)
                .WithRequired(e => e.T_Departamento)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<T_Movimientos>()
                .Property(e => e.Codificacion)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_Movimientos>()
                .Property(e => e.CodAdicional)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_Status>()
                .HasMany(e => e.T_Documentos)
                .WithRequired(e => e.T_Status)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<T_Interfaz>()
                .Property(e => e.title)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_Interfaz>()
                .Property(e => e.Navegacion)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_Interfaz>()
                .Property(e => e.NavHover)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_Interfaz>()
                .Property(e => e.NavFont)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_Interfaz>()
                .Property(e => e.NavFontHover)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_Interfaz>()
                .Property(e => e.Piramide)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_Interfaz>()
                .Property(e => e.PirFont)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_Interfaz>()
                .Property(e => e.PirHover)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_Interfaz>()
                .Property(e => e.PirFontHover)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}
