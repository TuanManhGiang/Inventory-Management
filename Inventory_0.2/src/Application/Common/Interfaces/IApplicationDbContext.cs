using Inventory_0._2.Domain.Entities;
using warehouse_management.Domain.Entities;

namespace Inventory_0._2.Application.Common.Interfaces;
public interface IApplicationDbContext
{
    DbSet<Product> Products { get; }

    DbSet<ProductDetail> ProductsDetails { get; }

    DbSet<ImportInvoice> ImportInvoices { get; }

    DbSet<ImportInvoiceDetail> ImportInvoiceDetails { get; }

    DbSet<Supplier> Suppliers { get; }

    DbSet<TodoList> TodoLists { get; }

    DbSet<TodoItem> TodoItems { get; }

    DbSet<Warehouse> Warehouses { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
