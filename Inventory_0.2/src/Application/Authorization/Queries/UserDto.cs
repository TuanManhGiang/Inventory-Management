using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_0._2.Application.Authorization.Queries
{
    public class UserDto
    {
        public UserDto(byte[] rowVersion, string id, string firstName, string lastName,
            string email, bool approved)
        {
            RowVersion = rowVersion;
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Approved = approved;
        }

        public UserDto()
        {
        }

        public byte[] RowVersion { get; set; }

        public string Id { get; set; }


        string FirstName { get; set; }
      
        string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

   
        public string ConfirmPassword { get; set; }

        public string Role { get; set; }

        public bool Approved { get; set; }

    }

}
