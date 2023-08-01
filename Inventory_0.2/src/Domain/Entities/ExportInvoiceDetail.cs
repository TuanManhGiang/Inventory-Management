using System;
using System.Collections.Generic;

namespace warehouse_management.Domain.Entities;

public partial class ExportInvoiceDetail
{
    public string ExportId { get; set; } = null!;

    public string ProductId { get; set; } = null!;

    public int? Quantity { get; set; }

    public int? ExportedQuantity { get; set; }

    public double? UnitPrice { get; set; }

    public virtual ExportInvoice Export { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
