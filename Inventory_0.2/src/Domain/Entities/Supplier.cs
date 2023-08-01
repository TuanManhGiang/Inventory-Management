using System;
using System.Collections.Generic;

namespace warehouse_management.Domain.Entities;

public partial class Supplier
{
    public string SupplierId { get; set; } = null!;

    public string SupplierName { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Status { get; set; } = null!;

    public virtual ICollection<ImportInvoice> ImportInvoices { get; } = new List<ImportInvoice>();
}
