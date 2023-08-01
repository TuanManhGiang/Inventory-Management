using System;
using System.Collections.Generic;

namespace warehouse_management.Domain.Entities;

public partial class ImportInvoice
{
    public string ImportId { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public DateTime ImportDate { get; set; }

    public string CreatedByEmployeeId { get; set; }

    public string ImportedByEmployeeId { get; set; }

    public string WarehouseId { get; set; }

    public string SupplierId { get; set; }

    public string Status { get; set; }

    public virtual Employee CreatedByEmployee { get; set; }

    public virtual ICollection<ImportInvoiceDetail> ImportInvoiceDetails { get; } = new List<ImportInvoiceDetail>();

    public virtual Employee ImportedByEmployee { get; set; }

    public virtual Supplier Supplier { get; set; }

    public virtual Warehouse  Warehouse { get; set; }
}
