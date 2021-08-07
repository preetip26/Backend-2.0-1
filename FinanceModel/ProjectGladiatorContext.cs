﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ngToASP.FinanceModel
{
    public partial class ProjectGladiatorContext : DbContext
    {
        public ProjectGladiatorContext()
        {
        }

        public ProjectGladiatorContext(DbContextOptions<ProjectGladiatorContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AdminControl> AdminControls { get; set; }
        public virtual DbSet<Consumer> Consumers { get; set; }
        public virtual DbSet<Emicard> Emicards { get; set; }
        public virtual DbSet<LoginTable> LoginTables { get; set; }
        public virtual DbSet<ProdCounter> ProdCounters { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<PurchaseRecord> PurchaseRecords { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=ProjectGladiator;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AdminControl>(entity =>
            {
                entity.HasKey(e => e.Aid)
                    .HasName("PK__AdminCon__DE508E2EFD2F189E");

                entity.ToTable("AdminControl");

                entity.HasIndex(e => e.APassword, "UQ__AdminCon__1D0BB23427F56577")
                    .IsUnique();

                entity.HasIndex(e => e.UserName, "UQ__AdminCon__66DCF95CF715B62D")
                    .IsUnique();

                entity.HasIndex(e => e.UserId, "UQ__AdminCon__CB9A1CFEAFA29F7C")
                    .IsUnique();

                entity.Property(e => e.Aid).HasColumnName("aid");

                entity.Property(e => e.AName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("aName");

                entity.Property(e => e.APassword)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("aPassword");

                entity.Property(e => e.UserId)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("userId")
                    .HasComputedColumnSql("('AID'+right(CONVERT([varchar](8),[aid]),(8)))", false);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("userName");
            });

            modelBuilder.Entity<Consumer>(entity =>
            {
                entity.HasKey(e => e.Cid)
                    .HasName("PK__Consumer__D837D05F5B9753E0");

                entity.ToTable("Consumer");

                entity.HasIndex(e => e.UserName, "UQ__Consumer__66DCF95C23D10B64")
                    .IsUnique();

                entity.HasIndex(e => e.EmailId, "UQ__Consumer__87355E73C8F16852")
                    .IsUnique();

                entity.HasIndex(e => e.AccNo, "UQ__Consumer__A4719704D8450B67")
                    .IsUnique();

                entity.HasIndex(e => e.UserId, "UQ__Consumer__CB9A1CFEAFBF93DE")
                    .IsUnique();

                entity.HasIndex(e => e.CPassword, "UQ__Consumer__E577FBA1EA417125")
                    .IsUnique();

                entity.Property(e => e.Cid).HasColumnName("cid");

                entity.Property(e => e.AccNo)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("accNo");

                entity.Property(e => e.BankName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("bankName");

                entity.Property(e => e.CAddress)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("cAddress");

                entity.Property(e => e.CName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("cName");

                entity.Property(e => e.CPassword)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("cPassword");

                entity.Property(e => e.CardType).HasColumnName("cardType");

                entity.Property(e => e.Dob)
                    .HasColumnType("date")
                    .HasColumnName("DOB");

                entity.Property(e => e.EmailId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("emailId");

                entity.Property(e => e.IfscCode)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("ifscCode");

                entity.Property(e => e.IsVerfied)
                    .HasColumnName("isVerfied")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("phoneNumber");

                entity.Property(e => e.UserId)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("userId")
                    .HasComputedColumnSql("('UID'+right(CONVERT([varchar](8),[cid]),(8)))", false);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("userName");
            });

            modelBuilder.Entity<Emicard>(entity =>
            {
                entity.HasKey(e => e.Eid)
                    .HasName("PK__EMICard__D9509F6DE77CF27F");

                entity.ToTable("EMICard");

                entity.HasIndex(e => e.CardNo, "UQ__EMICard__4D66913AADD91040")
                    .IsUnique();

                entity.Property(e => e.Eid).HasColumnName("eid");

                entity.Property(e => e.AccBalance)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("accBalance");

                entity.Property(e => e.CardNo)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("cardNo")
                    .HasComputedColumnSql("('CDN'+right(CONVERT([varchar](8),[eid]),(8)))", false);

                entity.Property(e => e.TotalCredit)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("totalCredit");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.Property(e => e.ValidityPeriod)
                    .HasColumnType("date")
                    .HasColumnName("validityPeriod");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Emicards)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("fk_userId");
            });

            modelBuilder.Entity<LoginTable>(entity =>
            {
                entity.HasKey(e => e.UserName)
                    .HasName("PK__LoginTab__66DCF95D52F9C772");

                entity.ToTable("LoginTable");

                entity.Property(e => e.UserName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("userName");

                entity.Property(e => e.UPassword)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("uPassword");
            });

            modelBuilder.Entity<ProdCounter>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("prodCounter");

                entity.Property(e => e.ColA).HasColumnName("colA");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Pid)
                    .HasName("PK__Product__DD37D91A038865D5");

                entity.ToTable("Product");

                entity.HasIndex(e => e.ProductId, "UQ__Product__2D10D16B32C48045")
                    .IsUnique();

                entity.Property(e => e.Pid).HasColumnName("pid");

                entity.Property(e => e.Img)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("img");

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("price");

                entity.Property(e => e.ProdDetails)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("prodDetails");

                entity.Property(e => e.ProductId)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("productId")
                    .HasComputedColumnSql("('PRN'+right(CONVERT([varchar](8),[pid]),(8)))", false);

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("productName");
            });

            modelBuilder.Entity<PurchaseRecord>(entity =>
            {
                entity.HasKey(e => e.Prid)
                    .HasName("PK__Purchase__46638AED1FB70F0D");

                entity.ToTable("PurchaseRecord");

                entity.HasIndex(e => e.OrderId, "UQ__Purchase__0809335C09FD6093")
                    .IsUnique();

                entity.Property(e => e.Prid).HasColumnName("prid");

                entity.Property(e => e.CardNo).HasColumnName("cardNo");

                entity.Property(e => e.Dop)
                    .HasColumnType("date")
                    .HasColumnName("DOP");

                entity.Property(e => e.OrderId)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("orderId")
                    .HasComputedColumnSql("('ODR'+right(CONVERT([varchar](8),[prid]),(8)))", false);

                entity.Property(e => e.ProductBalance)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("productBalance");

                entity.Property(e => e.ProductId).HasColumnName("productId");

                entity.Property(e => e.TotalMonthsSelected).HasColumnName("totalMonthsSelected");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.HasOne(d => d.CardNoNavigation)
                    .WithMany(p => p.PurchaseRecords)
                    .HasForeignKey(d => d.CardNo)
                    .HasConstraintName("fk_cdn");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.PurchaseRecords)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("fk_pid");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.PurchaseRecords)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("fk_uid");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
