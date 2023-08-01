using System;
using System.Collections.Generic;

namespace warehouse_management.Domain.Entities;

public partial class ImportInvoiceDetail
{
    public string ImportId { get; set; } = null!;

    public string ProductId { get; set; } = null!;

    public int? Quantity { get; set; }

    public int? ImportedQuantity { get; set; }

    public double? UnitPrice { get; set; }

    public virtual ImportInvoice Import { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
