using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BankingAPP_EF_Demo.Models.EF
{
    public partial class bankingMangementDBContext : DbContext
    {
        public bankingMangementDBContext()
        {
        }

        public bankingMangementDBContext(DbContextOptions<bankingMangementDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AccountsInfo> AccountsInfos { get; set; } = null!;
        public virtual DbSet<BranchInfo> BranchInfos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=WIN8\\NIKHILINSTANCE;database=bankingMangementDB;integrated security=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountsInfo>(entity =>
            {
                entity.HasKey(e => e.AccNo)
                    .HasName("PK__accounts__A4719705BF7A8DF9");

                entity.ToTable("accountsInfo");

                entity.Property(e => e.AccNo)
                    .ValueGeneratedNever()
                    .HasColumnName("accNo");

                entity.Property(e => e.AccBalance).HasColumnName("accBalance");

                entity.Property(e => e.AccBranch).HasColumnName("accBranch");

                entity.Property(e => e.AccName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("accName");

                entity.Property(e => e.AccType)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("accType");

                entity.HasOne(d => d.AccBranchNavigation)
                    .WithMany(p => p.AccountsInfos)
                    .HasForeignKey(d => d.AccBranch)
                    .HasConstraintName("fk_branchNo");
            });

            modelBuilder.Entity<BranchInfo>(entity =>
            {
                entity.HasKey(e => e.BranchNo)
                    .HasName("PK__branchIn__751EC4A007AADD63");

                entity.ToTable("branchInfo");

                entity.Property(e => e.BranchNo)
                    .ValueGeneratedNever()
                    .HasColumnName("branchNo");

                entity.Property(e => e.BranchCity)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("branchCity");

                entity.Property(e => e.BranchName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("branchName");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
