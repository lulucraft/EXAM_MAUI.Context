using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EXAM_MAUI.Context.Models;

public partial class ArkoneLajContext : DbContext
{
    public ArkoneLajContext()
    {
    }

    public ArkoneLajContext(DbContextOptions<ArkoneLajContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ConfirmationPresence> ConfirmationPresences { get; set; }

    public virtual DbSet<Evenement> Evenements { get; set; }

    public virtual DbSet<Invite> Invites { get; set; }

    public virtual DbSet<SousEvenement> SousEvenements { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=192.168.29.13;User ID=sa;Password=erty64%;Database=ArkoneLAJ;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ConfirmationPresence>(entity =>
        {
            entity.HasKey(e => e.IdConfirmation).HasName("PK__Confirma__EB602E5DD66B6CD6");

            entity.ToTable("ConfirmationPresence");

            entity.HasOne(d => d.IdEvenementNavigation).WithMany(p => p.ConfirmationPresences)
                .HasForeignKey(d => d.IdEvenement)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Confirmat__IdEve__29572725");

            entity.HasOne(d => d.IdInviteNavigation).WithMany(p => p.ConfirmationPresences)
                .HasForeignKey(d => d.IdInvite)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Confirmat__IdInv__2A4B4B5E");
        });

        modelBuilder.Entity<Evenement>(entity =>
        {
            entity.HasKey(e => e.IdEvenement).HasName("PK__Evenemen__300AD07EF07A3234");

            entity.ToTable("Evenement");

            entity.HasIndex(e => e.Nom, "UK_Nom_Evenement").IsUnique();

            entity.Property(e => e.CoordonneesGps)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("CoordonneesGPS");
            entity.Property(e => e.LieuEvenement)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Nom)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasMany(d => d.IdInvites).WithMany(p => p.IdEvenements)
                .UsingEntity<Dictionary<string, object>>(
                    "EvenementInvite",
                    r => r.HasOne<Invite>().WithMany()
                        .HasForeignKey("IdInvite")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Evenement__IdInv__30F848ED"),
                    l => l.HasOne<Evenement>().WithMany()
                        .HasForeignKey("IdEvenement")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Evenement__IdEve__300424B4"),
                    j =>
                    {
                        j.HasKey("IdEvenement", "IdInvite").HasName("PK__Evenemen__C221DCEA9527F3A2");
                        j.ToTable("Evenement_Invite");
                    });
        });

        modelBuilder.Entity<Invite>(entity =>
        {
            entity.HasKey(e => e.IdInvite).HasName("PK__Invite__22B0C94EEF8111A2");

            entity.ToTable("Invite");

            entity.HasIndex(e => e.CodeInvite, "UQ__Invite__9ACA0BCB65310D05").IsUnique();

            entity.Property(e => e.CodeInvite)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.EmailInvite)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.NomInvite)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.PrenomInvite)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TelephoneInvite)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<SousEvenement>(entity =>
        {
            entity.HasKey(e => e.IdSousEvenement).HasName("PK__SousEven__5FD54D8710970F35");

            entity.ToTable("SousEvenement");

            entity.Property(e => e.NomSousEvenement)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.IdEvenementNavigation).WithMany(p => p.SousEvenements)
                .HasForeignKey(d => d.IdEvenement)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SousEvene__IdEve__2D27B809");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
