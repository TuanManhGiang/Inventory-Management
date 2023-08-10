using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_0._2.Application.ExportInvoices.Querries;

public class ExportDetailsDto
{

    public string ImportId { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public DateTime ImportDate { get; set; }

    public string CreatedByEmployeeId { get; set; }

    public string ImportedByEmployeeId { get; set; }

    public string WarehouseId { get; set; }

    public string ExportTo { get; set; }

    public string Status { get; set; }
    public List<ExportDto> ExportDetailsDtos { get; set; }
}

