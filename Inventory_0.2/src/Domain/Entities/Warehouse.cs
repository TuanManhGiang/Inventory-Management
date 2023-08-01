using System;
using System.Collections.Generic;

namespace warehouse_management.Domain.Entities;

public partial class Warehouse
{
    public string WarehouseId { get; set; } = null!;

    public string WarehouseName { get; set; }

    public string Address { get; set; }

    public virtual ICollection<ExportInvoice> ExportInvoices { get; } = new List<ExportInvoice>();

    public virtual ICollection<ImportInvoice> ImportInvoices { get; } = new List<ImportInvoice>();

    public virtual ICollection<ProductDetail> ProductDetails { get; } = new List<ProductDetail>();
}
