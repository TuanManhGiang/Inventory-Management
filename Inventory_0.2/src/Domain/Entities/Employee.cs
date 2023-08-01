using System;
using System.Collections.Generic;

namespace warehouse_management.Domain.Entities;

public partial class Employee
{
    public string EmployeeId { get; set; } = null!;

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Address { get; set; }

    public DateTime Birthdate { get; set; }

    public string DepartmentId { get; set; }

    public virtual Department Department { get; set; }

    public virtual ICollection<ExportInvoice> ExportInvoiceCreatedByEmployees { get; } = new List<ExportInvoice>();

    public virtual ICollection<ExportInvoice> ExportInvoiceExportedByEmployees { get; } = new List<ExportInvoice>();

    public virtual ICollection<ImportInvoice> ImportInvoiceCreatedByEmployees { get; } = new List<ImportInvoice>();

    public virtual ICollection<ImportInvoice> ImportInvoiceImportedByEmployees { get; } = new List<ImportInvoice>();
}
