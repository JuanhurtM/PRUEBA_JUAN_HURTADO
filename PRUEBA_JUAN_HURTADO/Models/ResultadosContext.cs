using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PRUEBA_JUAN_HURTADO.Models;

public partial class ResultadosContext : DbContext
{
    public ResultadosContext()
    {
    }

    public ResultadosContext(DbContextOptions<ResultadosContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Resultado> Resultados { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=T126963\\SQLEXPRESS;database=RESULTADOS;Trusted_Connection=true;Encrypt=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Resultado>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__RESULTAD__3214EC07C48F700D");

            entity.ToTable("RESULTADOS");

            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Pais)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
