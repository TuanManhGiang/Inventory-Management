using System;
using System.Collections.Generic;

namespace warehouse_management.Domain.Entities;

public partial class Department
{
    public string DepartmentId { get; set; } = null!;

    public string  DepartmentName { get; set; }

    public virtual ICollection<Employee> Employees { get; } = new List<Employee>();
}
