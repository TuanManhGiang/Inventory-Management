using System;
using System.Collections.Generic;

namespace warehouse_management.Domain.Entities;

public partial class Product
{
    public string ProductId { get; set; } = null!;

    public string MaterialName { get; set; }

    public string Unit { get; set; }

    public string Type { get; set; }

    public string Color { get; set; }

    public string Size { get; set; }

    public virtual ICollection<ExportInvoiceDetail> ExportInvoiceDetails { get; } = new List<ExportInvoiceDetail>();

    public virtual ICollection<ImportInvoiceDetail> ImportInvoiceDetails { get; } = new List<ImportInvoiceDetail>();

    public virtual ICollection<ProductDetail> ProductDetails { get; } = new List<ProductDetail>();
}
