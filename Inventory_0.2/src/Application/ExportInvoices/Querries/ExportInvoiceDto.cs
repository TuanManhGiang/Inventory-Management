using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_0._2.Application.ExportInvoices.Querries;
public class ExportInvoiceDto
{
    public string ExportId { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public DateTime ExportDate { get; set; }

    public string CreatedByEmployeeId { get; set; }

    public string ExportedByEmployeeId { get; set; }

    public string WarehouseId { get; set; }

    public string ExportTo { get; set; }

    public string Status { get; set; }
}