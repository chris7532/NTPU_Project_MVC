using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using NTPU_Project_MVC.Models;

namespace NTPU_Project_MVC.DataAccess.Data;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<FireWall> FireWalls { get; set; }

    public virtual DbSet<Top20table> Top20tables { get; set; }

    public virtual DbSet<Imap4> Imap4s { get; set; }

    public virtual DbSet<Pop3> Pop3s { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }

    /*
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<FireWall>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("all");

            entity.Property(e => e.Dst)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("dst");
            entity.Property(e => e.Fw)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("fw");
            entity.Property(e => e.FwAction)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("fw_action");
            entity.Property(e => e.TypeId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("id");
            entity.Property(e => e.Msg)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("msg");
            entity.Property(e => e.Pri)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("pri");
            entity.Property(e => e.Proto)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("proto");
            entity.Property(e => e.Src)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("src");
            entity.Property(e => e.Time)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("time");
        });

        modelBuilder.Entity<Top20table>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("top20table");

            entity.Property(e => e.Cnt).HasColumnName("CNT");
            entity.Property(e => e.Dst)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("dst");
            entity.Property(e => e.Hour).HasColumnName("HOUR");
            entity.Property(e => e.Rank).HasColumnName("rank");
            entity.Property(e => e.Src)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("src");
            entity.Property(e => e.日期)
                .HasMaxLength(10)
                .IsUnicode(false);
        });


        

        OnModelCreatingPartial(modelBuilder);
    }*/
    /*Scaffold-Command:
     Scaffold-DbContext -Connection "Data Source=DESKTOP-HDAU9RG\SQLEXPRESS;Initial Catalog=NTPU_Project;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False" Microsoft.EntityFrameworkCore.SqlServer -OutputDir ../NTPU_Project_MVC.Models -Force -Context ApplicationDbContext -Tables dbo.[all],dbo.[top20],dbo.[imap4],dbo.[pop3] -NoOnConfiguring
     */
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<FireWall>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("all");

            entity.Property(e => e.Dst)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("dst");
            entity.Property(e => e.Fw)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("fw");
            entity.Property(e => e.FwAction)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("fw_action");
            entity.Property(e => e.TypeId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("id");
            entity.Property(e => e.Msg)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("msg");
            entity.Property(e => e.Pri)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("pri");
            entity.Property(e => e.Proto)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("proto");
            entity.Property(e => e.Src)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("src");
            entity.Property(e => e.Time)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("time");
        });

        modelBuilder.Entity<Top20table>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("top20table");

            entity.Property(e => e.Cnt).HasColumnName("CNT");
            entity.Property(e => e.Dst)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("dst");
            entity.Property(e => e.Hour).HasColumnName("HOUR");
            entity.Property(e => e.Rank).HasColumnName("rank");
            entity.Property(e => e.Src)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("src");
            entity.Property(e => e.Date)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Imap4>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("imap4");

            entity.Property(e => e.Hash)
                .HasMaxLength(50)
                .HasColumnName("HASH");
            entity.Property(e => e.Ip)
                .HasMaxLength(50)
                .HasColumnName("IP");
            entity.Property(e => e.Country).HasMaxLength(50);
            entity.Property(e => e.Date).HasColumnType("date");
            entity.Property(e => e.Time).HasMaxLength(50);
        });

        modelBuilder.Entity<Pop3>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("pop3");

            entity.Property(e => e.Hash)
                .HasMaxLength(50)
                .HasColumnName("HASH");
            entity.Property(e => e.Ip)
                .HasMaxLength(50)
                .HasColumnName("IP");
            entity.Property(e => e.Country).HasMaxLength(50);
            entity.Property(e => e.Date).HasColumnType("date");
            entity.Property(e => e.Time).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
