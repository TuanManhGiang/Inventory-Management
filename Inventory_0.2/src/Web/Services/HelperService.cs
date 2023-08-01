﻿
using Inventory_0._2.Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_0._2.Web.Services
{
	public class HelperService : IHelperService
	{
		public HelperService()
		{
		}

		public async Task<PropertyValues> RetrieveEntity(DbUpdateConcurrencyException ex)
		{
			var entry = ex.Entries.Single();
			var clientUser = (ApplicationUser)entry.Entity;
			return await entry.GetDatabaseValuesAsync();
		}
	}
}
