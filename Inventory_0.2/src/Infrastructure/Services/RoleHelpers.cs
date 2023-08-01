using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory_0._2.Infrastructure.Services;

	public static class RoleHelpers
	{
		public struct RolePair
		{
			public string Name { get; set; }
			public string Description { get; set; }
		};

		public static List<RolePair> Roles = new List<RolePair>()
		{
			new RolePair { Name = "administrator", Description = "Administrator"},
			new RolePair { Name = "supervisor", Description = "Supervisor" },
			new RolePair { Name = "user", Description =  "User"},
		};
	}

