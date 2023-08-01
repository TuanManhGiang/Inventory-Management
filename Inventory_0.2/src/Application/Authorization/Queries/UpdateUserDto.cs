using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_0._2.Application.Authorization.Queries
{
    public class UpdateUserDto
    {
        public byte[] RowVersion { get; set; }

        public string Id { get; set; }

     
        public string FirstName { get; set; }

 
        public string LastName { get; set; }

        public string Email { get; set; }


        public string Role { get; set; }

 
        public bool Approved { get; set; }
    }
}
