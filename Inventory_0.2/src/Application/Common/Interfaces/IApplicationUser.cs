using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_0._2.Application.Common.Interfaces;
public interface IApplicationUser
{
    [MaxLength(100)]
    string FirstName { get; set; }
    [MaxLength(100)]
     string LastName { get; set; }
    bool ApplicationEditingAllowed { get; set; } 
     bool Approved { get; set; } 

    [Timestamp]
     byte[] RowVersion { get; set; }

    [NotMapped]
    string FullName
    {
        get
        {
            return FirstName + " " + LastName;
        }
    }

    string Email { get; }
    string Id { get; }
}
