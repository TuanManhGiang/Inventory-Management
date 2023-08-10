using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_0._2.Application.ImportInvoices.Querries;
public class ImportDto
{

    public string ProductId { get; set; } 

    public int? Quantity { get; set; }

    public double? UnitPrice { get; set; }
}
