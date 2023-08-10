using System.Reflection;
using System.Reflection.Emit;
using Inventory_0._2.Application.Common.Interfaces;
using Inventory_0._2.Domain.Entities;
using Inventory_0._2.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using warehouse_management.Domain.Entities;

namespace Inventory_0._2.Infrastructure.Data;
public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { 
    }
    public DbSet<Product> Products => Set<Product>();
    public DbSet<TodoList> TodoLists => Set<TodoList>();

    public DbSet<TodoItem> TodoItems => Set<TodoItem>();

    public DbSet<ProductDetail> ProductsDetails => Set<ProductDetail>();

    public DbSet<ImportInvoice> ImportInvoices => Set<ImportInvoice>();

    public DbSet<ImportInvoiceDetail> ImportInvoiceDetails => Set<ImportInvoiceDetail>();

    public DbSet<Supplier> Suppliers => Set<Supplier>();

    public DbSet<Warehouse> Warehouses => Set< Warehouse>();

    public DbSet<ExportInvoice> ExportInvoices => Set<ExportInvoice>();

    public DbSet<ExportInvoiceDetail> ExportInvoiceDetails => Set<ExportInvoiceDetail>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DepartmentId).HasName("PK__Departme__B2079BCD0EA330E9");

            entity.ToTable("Department");

            entity.HasIndex(e => e.DepartmentName, "UQ__Departme__D949CC34117F9D94").IsUnique();

            entity.Property(e => e.DepartmentId)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("DepartmentID");
            entity.Property(e => e.DepartmentName).HasMaxLength(100);
        });

        

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK__Employee__7AD04FF1173876EA");

            entity.ToTable("Employee");

            entity.Property(e => e.EmployeeId)
                .HasMaxLength(4)
                .IsFixedLength()
                .HasColumnName("EmployeeID");
            entity.Property(e => e.Address).HasMaxLength(100);
            entity.Property(e => e.Birthdate).HasColumnType("datetime");
            entity.Property(e => e.DepartmentId)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("DepartmentID");
            entity.Property(e => e.FirstName).HasMaxLength(40);
            entity.Property(e => e.LastName).HasMaxLength(10);

            entity.HasOne(d => d.Department).WithMany(p => p.Employees)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("FK__Employee__Depart__52593CB8");
        });

        modelBuilder.Entity<ExportInvoice>(entity =>
        {
            entity.HasKey(e => e.ExportId).HasName("PK__ExportIn__E5C997A41B0907CE");

            entity.ToTable("ExportInvoice");

            entity.Property(e => e.ExportId)
                .HasMaxLength(8)
                .IsFixedLength()
                .HasColumnName("ExportID");
            entity.Property(e => e.CreatedByEmployeeId)
                .HasMaxLength(4)
                .IsFixedLength()
                .HasColumnName("CreatedByEmployeeID");
            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.ExportTo)
                .HasMaxLength(4)
                .IsFixedLength();
            entity.Property(e => e.ExportedByEmployeeId)
                .HasMaxLength(4)
                .IsFixedLength()
                .HasColumnName("ExportedByEmployeeID");
            entity.Property(e => e.WarehouseId)
                .HasMaxLength(4)
                .IsFixedLength()
                .HasColumnName("WarehouseID");

            entity.HasOne(d => d.CreatedByEmployee).WithMany(p => p.ExportInvoiceCreatedByEmployees)
                .HasForeignKey(d => d.CreatedByEmployeeId)
                .HasConstraintName("FK__ExportInv__Creat__534D60F1");

            entity.HasOne(d => d.ExportedByEmployee).WithMany(p => p.ExportInvoiceExportedByEmployees)
                .HasForeignKey(d => d.ExportedByEmployeeId)
                .HasConstraintName("FK__ExportInv__Expor__5441852A");

            entity.HasOne(d => d.Warehouse).WithMany(p => p.ExportInvoices)
                .HasForeignKey(d => d.WarehouseId)
                .HasConstraintName("FK__ExportInv__Wareh__5535A963");
        });

        modelBuilder.Entity<ExportInvoiceDetail>(entity =>
        {
            entity.HasKey(e => new { e.ExportId, e.ProductId }).HasName("PK__ExportIn__2E895BCA1ED998B2");

            entity.ToTable("ExportInvoiceDetail");

            entity.Property(e => e.ExportId)
                .HasMaxLength(8)
                .IsFixedLength()
                .HasColumnName("ExportID");
            entity.Property(e => e.ProductId)
                .HasMaxLength(4)
                .IsFixedLength()
                .HasColumnName("ProductID");

            entity.HasOne(d => d.Export).WithMany(p => p.ExportInvoiceDetails)
                .HasForeignKey(d => d.ExportId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ExportInv__Expor__5629CD9C");

            entity.HasOne(d => d.Product).WithMany(p => p.ExportInvoiceDetails)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ExportInv__Produ__571DF1D5");
        });

        modelBuilder.Entity<ImportInvoice>(entity =>
        {
            entity.HasKey(e => e.ImportId).HasName("PK__ImportIn__8697678A24927208");

            entity.ToTable("ImportInvoice");

            entity.Property(e => e.ImportId)
                .HasMaxLength(8)
                .IsFixedLength()
                .HasColumnName("ImportID");
            entity.Property(e => e.CreatedByEmployeeId)
                .HasMaxLength(4)
                .IsFixedLength()
                .HasColumnName("CreatedByEmployeeID");
            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.ImportedByEmployeeId)
                .HasMaxLength(4)
                .IsFixedLength()
                .HasColumnName("ImportedByEmployeeID");
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.SupplierId)
                .HasMaxLength(4)
                .IsFixedLength()
                .HasColumnName("SupplierID");
            entity.Property(e => e.WarehouseId)
                .HasMaxLength(4)
                .IsFixedLength()
                .HasColumnName("WarehouseID");

            entity.HasOne(d => d.CreatedByEmployee).WithMany(p => p.ImportInvoiceCreatedByEmployees)
                .HasForeignKey(d => d.CreatedByEmployeeId)
                .HasConstraintName("FK__ImportInv__Creat__276EDEB3");

            entity.HasOne(d => d.ImportedByEmployee).WithMany(p => p.ImportInvoiceImportedByEmployees)
                .HasForeignKey(d => d.ImportedByEmployeeId)
                .HasConstraintName("FK__ImportInv__Impor__286302EC");

            entity.HasOne(d => d.Supplier).WithMany(p => p.ImportInvoices)
                .HasForeignKey(d => d.SupplierId)
                .HasConstraintName("FK_ImportInvoice_Supplier");

            entity.HasOne(d => d.Warehouse).WithMany(p => p.ImportInvoices)
                .HasForeignKey(d => d.WarehouseId)
                .HasConstraintName("FK__ImportInv__Wareh__29572725");
        });

        modelBuilder.Entity<ImportInvoiceDetail>(entity =>
        {
            entity.HasKey(e => new { e.ImportId, e.ProductId }).HasName("PK__ImportIn__4DD7ABE424927208");

            entity.ToTable("ImportInvoiceDetail");

            entity.Property(e => e.ImportId)
                .HasMaxLength(8)
                .IsFixedLength()
                .HasColumnName("ImportID");
            entity.Property(e => e.ProductId)
                .HasMaxLength(4)
                .IsFixedLength()
                .HasColumnName("ProductID");

            entity.HasOne(d => d.Import).WithMany(p => p.ImportInvoiceDetails)
                .HasForeignKey(d => d.ImportId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ImportInv__Impor__2E1BDC42");

            entity.HasOne(d => d.Product).WithMany(p => p.ImportInvoiceDetails)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ImportInv__Produ__5CD6CB2B");
        });

      

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Product__B40CC6ED2C3393D0");

            entity.ToTable("Product");

            entity.HasIndex(e => e.MaterialName, "UQ__Product__9C87053C2F10007B").IsUnique();

            entity.Property(e => e.ProductId)
                .HasMaxLength(4)
                .IsFixedLength()
                .HasColumnName("ProductID");
            entity.Property(e => e.MaterialName).HasMaxLength(30);
            entity.Property(e => e.Unit).HasMaxLength(15);
        });

        modelBuilder.Entity<ProductDetail>(entity =>
        {
            entity.HasKey(e => new { e.WarehouseId, e.ProductId }).HasName("PK__ProductD__ED4863B732E0915F");

            entity.ToTable("ProductDetail");

            entity.HasIndex(e => e.CabinetId, "UQ__ProductD__9C173EB238996AB5").IsUnique();

            entity.HasIndex(e => e.ShelfId, "UQ__ProductD__DBD04F2635BCFE0A").IsUnique();

            entity.Property(e => e.WarehouseId)
                .HasMaxLength(4)
                .IsFixedLength()
                .HasColumnName("WarehouseID");
            entity.Property(e => e.ProductId)
                .HasMaxLength(4)
                .IsFixedLength()
                .HasColumnName("ProductID");
            entity.Property(e => e.CabinetId)
                .HasMaxLength(8)
                .IsFixedLength()
                .HasColumnName("CabinetID");
            entity.Property(e => e.ShelfId)
                .HasMaxLength(8)
                .IsFixedLength()
                .HasColumnName("ShelfID");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductDetails)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ProductDe__Produ__5DCAEF64");

            entity.HasOne(d => d.Warehouse).WithMany(p => p.ProductDetails)
                .HasForeignKey(d => d.WarehouseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ProductDe__Wareh__5EBF139D");
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.ToTable("Supplier");

            entity.Property(e => e.SupplierId)
                .HasMaxLength(4)
                .IsFixedLength()
                .HasColumnName("SupplierID");
            entity.Property(e => e.Address)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(e => e.Phone)
                .IsRequired()
                .HasMaxLength(12)
                .IsFixedLength();
            entity.Property(e => e.Status)
                .IsRequired()
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.SupplierName)
                .IsRequired()
                .HasMaxLength(100)
                .IsFixedLength();
        });

        modelBuilder.Entity<TodoItem>(entity =>
        {
            entity.HasIndex(e => e.ListId, "IX_TodoItems_ListId");

            entity.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(200);

            entity.HasOne(d => d.List).WithMany(p => p.Items).HasForeignKey(d => d.ListId);
        });

        modelBuilder.Entity<TodoList>(entity =>
        {
            
            entity.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(200);
        });



      
        modelBuilder.Entity<Warehouse>(entity =>
        {
            entity.HasKey(e => e.WarehouseId).HasName("PK__Warehous__2608AFD94222D4EF");

            entity.ToTable("Warehouse");

            entity.HasIndex(e => e.WarehouseName, "UQ__Warehous__180C89D944FF419A").IsUnique();

            entity.Property(e => e.WarehouseId)
                .HasMaxLength(4)
                .IsFixedLength()
                .HasColumnName("WarehouseID");
            entity.Property(e => e.Address).HasMaxLength(100);
            entity.Property(e => e.WarehouseName).HasMaxLength(30);
        });

        base.OnModelCreating(modelBuilder);
    }
}
