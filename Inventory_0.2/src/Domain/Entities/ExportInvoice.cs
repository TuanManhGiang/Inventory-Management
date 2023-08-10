using System;
using System.Collections.Generic;

namespace warehouse_management.Domain.Entities;

public partial class ExportInvoice
{
    public string ExportId { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public DateTime ExportDate { get; set; }

    public string WarehouseId { get; set; }

    public string CreatedByEmployeeId { get; set; }

    public string ExportedByEmployeeId { get; set; }

    public string ExportTo { get; set; }

    public string Status { get; set; }  

    public virtual Employee CreatedByEmployee { get; set; }

    public virtual ICollection<ExportInvoiceDetail> ExportInvoiceDetails { get; } = new List<ExportInvoiceDetail>();

    public virtual Employee ExportedByEmployee { get; set; }

    public virtual Warehouse Warehouse { get; set; }
}
