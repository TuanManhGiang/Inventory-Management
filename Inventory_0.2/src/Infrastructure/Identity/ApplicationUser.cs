using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Inventory_0._2.Application.Common.Interfaces;

namespace Inventory_0._2.Infrastructure.Identity;
public class ApplicationUser : IdentityUser
{
    [MaxLength(100)]
    public string FirstName { get; set; }
    [MaxLength(100)]
    public string LastName { get; set; }
    public bool ApplicationEditingAllowed { get; set; } = true;
    public bool Approved { get; set; } = false;

    [Timestamp]
    public byte[] RowVersion { get; set; }

    [NotMapped]
    public string FullName
    {
        get
        {
            return FirstName + " " + LastName;
        }
    }
}

