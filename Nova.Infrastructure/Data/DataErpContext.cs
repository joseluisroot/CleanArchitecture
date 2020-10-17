using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Nova.Infrastructure.Data
{
    public partial class DataErpContext : DbContext
    {
        public DataErpContext()
        {
        }

        public DataErpContext(DbContextOptions<DataErpContext> options)
            : base(options)
        {
        }

        public virtual DbSet<OrderType> OrderType { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<OrdersDetails> OrdersDetails { get; set; }
        public virtual DbSet<OrdersDetailsDynamic> OrdersDetailsDynamic { get; set; }
        public virtual DbSet<OrdersDetailsErp> OrdersDetailsErp { get; set; }
        public virtual DbSet<OrdersDetailsPoly> OrdersDetailsPoly { get; set; }
        public virtual DbSet<OrdersDynamic> OrdersDynamic { get; set; }
        public virtual DbSet<OrdersErp> OrdersErp { get; set; }
        public virtual DbSet<OrdersPoly> OrdersPoly { get; set; }
        public virtual DbSet<Sizes> Sizes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DEX-LREYES\\SQLEXPRESS;Database=DataErp;Integrated Security = true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderType>(entity =>
            {
                entity.HasKey(e => e.IdOrderType);

                entity.Property(e => e.IdOrderType).HasColumnName("idOrderType");

                entity.Property(e => e.TypeName)
                    .HasColumnName("typeName")
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasKey(e => e.IdOrder);

                entity.Property(e => e.EntryDate)
                    .HasColumnName("entry_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.EntryUser)
                    .HasColumnName("entry_user")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IdType)
                    .HasColumnName("idType");

                entity.Property(e => e.WorkOrder)
                    .HasColumnName("work_order")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTypeNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.IdType)
                    .HasConstraintName("FK_Orders_OrderType");
            });

            modelBuilder.Entity<OrdersDetails>(entity =>
            {
                entity.HasKey(e => e.IdOrderDatail);

                entity.Property(e => e.IdOrderDatail).HasColumnName("idOrderDatail");

                entity.Property(e => e.IdOrder).HasColumnName("idOrder");

                entity.Property(e => e.IdSize).HasColumnName("idSize");

                entity.HasOne(d => d.IdOrderNavigation)
                    .WithMany(p => p.OrdersDetails)
                    .HasForeignKey(d => d.IdOrder)
                    .HasConstraintName("FK_OrdersDetails_Orders");

                entity.HasOne(d => d.IdSizeNavigation)
                    .WithMany(p => p.OrdersDetails)
                    .HasForeignKey(d => d.IdSize)
                    .HasConstraintName("FK_OrdersDetails_Tallas");
            });

            modelBuilder.Entity<OrdersDetailsDynamic>(entity =>
            {
                entity.HasKey(e => e.IdOrderDatail);

                entity.Property(e => e.IdOrderDatail).HasColumnName("idOrderDatail");

                entity.Property(e => e.IdOrder).HasColumnName("idOrder");

                entity.Property(e => e.IdSize).HasColumnName("idSize");

                entity.Property(e => e.Qty).HasColumnName("qty");

                entity.HasOne(d => d.IdOrderNavigation)
                    .WithMany(p => p.OrdersDetailsDynamic)
                    .HasForeignKey(d => d.IdOrder)
                    .HasConstraintName("FK_OrdersDetailsDynamic_OrdersDynamic");
            });

            modelBuilder.Entity<OrdersDetailsErp>(entity =>
            {
                entity.HasKey(e => e.IdOrderDatail);

                entity.Property(e => e.IdOrderDatail).HasColumnName("idOrderDatail");

                entity.Property(e => e.IdOrder).HasColumnName("idOrder");

                entity.Property(e => e.IdSize).HasColumnName("idSize");

                entity.Property(e => e.Qty).HasColumnName("qty");

                entity.HasOne(d => d.IdOrderNavigation)
                    .WithMany(p => p.OrdersDetailsErp)
                    .HasForeignKey(d => d.IdOrder)
                    .HasConstraintName("FK_OrdersDetailsErp_OrdersErp");
            });

            modelBuilder.Entity<OrdersDetailsPoly>(entity =>
            {
                entity.HasKey(e => e.IdOrderDatail);

                entity.Property(e => e.IdOrderDatail)
                    .HasColumnName("idOrderDatail")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.IdOrder).HasColumnName("idOrder");

                entity.Property(e => e.IdSize).HasColumnName("idSize");

                entity.Property(e => e.Qty).HasColumnName("qty");

                entity.HasOne(d => d.IdOrderDatailNavigation)
                    .WithOne(p => p.OrdersDetailsPoly)
                    .HasForeignKey<OrdersDetailsPoly>(d => d.IdOrderDatail)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrdersDetailsPoly_OrdersPoly");
            });

            modelBuilder.Entity<OrdersDynamic>(entity =>
            {
                entity.HasKey(e => e.IdOrder);

                entity.Property(e => e.EntryDate)
                    .HasColumnName("entry_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.EntryUser)
                    .HasColumnName("entry_user")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.WorkOrder)
                    .HasColumnName("work_order")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<OrdersErp>(entity =>
            {
                entity.HasKey(e => e.IdOrder);

                entity.Property(e => e.EntryDate)
                    .HasColumnName("entry_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.EntryUser)
                    .HasColumnName("entry_user")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.WorkOrder)
                    .HasColumnName("work_order")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<OrdersPoly>(entity =>
            {
                entity.HasKey(e => e.IdOrder);

                entity.Property(e => e.EntryDate)
                    .HasColumnName("entry_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.EntryUser)
                    .HasColumnName("entry_user")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.WorkOrder)
                    .HasColumnName("work_order")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Sizes>(entity =>
            {
                entity.HasKey(e => e.IdSize)
                    .HasName("PK_Tallas");

                entity.Property(e => e.IdSize).HasColumnName("idSize");

                entity.Property(e => e.Number)
                    .HasColumnName("number")
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
