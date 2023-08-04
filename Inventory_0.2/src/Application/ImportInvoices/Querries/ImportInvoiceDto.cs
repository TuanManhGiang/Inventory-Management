using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using warehouse_management.Domain.Entities;

namespace Inventory_0._2.Application.ImportInvoices.Querries;
public class ImportInvoiceDto
{
    public string ImportId { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public DateTime ImportDate { get; set; }

    public string CreatedByEmployeeId { get; set; }

    public string ImportedByEmployeeId { get; set; }

    public string WarehouseId { get; set; }

    public string SupplierId { get; set; }

    public string Status { get; set; }
}
