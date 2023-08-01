using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_0._2.Application.Authorization.Queries
{
    public class UserPageDto
    {
        public int TotalUsers { get; set; }
        public  List<UserDto> Users { get; set; }
            = new List<UserDto>();
        
    }
}
