using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Inventory_0._2.Application.Authorization.Queries;
using Inventory_0._2.Application.Common.Interfaces;
using Inventory_0._2.Application.Common.Models;
using Inventory_0._2.Infrastructure.Data;
using Inventory_0._2.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using static Inventory_0._2.Infrastructure.Services.RoleHelpers;


namespace Inventory_0._2.Infrastructure.Services;
public class UserManagementService : IUserManagementService
	{
		private readonly ApplicationDbContext _context;
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;

    public UserManagementService(ApplicationDbContext context, UserManager<ApplicationUser> userManager,
			RoleManager<IdentityRole> roleManager, IMapper mapper)
		{
			_context = context;
			_userManager = userManager;
			_roleManager = roleManager;
            _mapper = mapper;
		}

		public async Task<IdentityRole> GetRoleByNameAsync(string name)
		{
			return await _context.Roles.AsNoTracking().Where(role => role.Name == name)
				.FirstOrDefaultAsync();
		}

		public async Task<int> GetAllUsersCountAsync(string searchString)
		{
			var users = _userManager.Users.AsNoTracking();

			if (!string.IsNullOrEmpty(searchString))
				users = users.Where(user => (user.LastName.Contains(searchString)
					|| user.FirstName.Contains(searchString)
					|| user.Email.Contains(searchString)));

			return await users.CountAsync();
		}

    public Task<List<UserDto>> GetAllUsers()
    {
        var users = _userManager.Users.AsNoTracking();
        List<UserDto> userDto = new();

        foreach (ApplicationUser user in users)
        {
            userDto.Add(new UserDto(user.RowVersion, user.Id, user.FirstName,
                user.LastName, user.Email, user.Approved));
        }
        return Task.FromResult(userDto);
    }

    public Task<List<UserDto>> GetUsersAsync(int offset, int limit, string sortOrder, string searchString)
    {
        offset = offset < 0 ? 0 : offset;
        limit = limit < 0 ? 0 : limit;
        var users = _userManager.Users.AsNoTracking();
        List<UserDto> userDto = new();

        if (!string.IsNullOrEmpty(searchString))
            users = users.Where(user => (user.LastName.Contains(searchString)
                || user.FirstName.Contains(searchString)
                || user.Email.Contains(searchString)));

        switch (sortOrder)
        {
            case "Lname":
                users = users.OrderBy(u => u.LastName);
                break;
            case "Lname_desc":
                users = users.OrderByDescending(u => u.LastName);
                break;
            case "Fname":
                users = users.OrderBy(u => u.FirstName);
                break;
            case "Fname_desc":
                users = users.OrderByDescending(u => u.FirstName);
                break;
            case "Email":
                users = users.OrderBy(u => u.Email);
                break;
            case "Email_desc":
                users = users.OrderByDescending(u => u.Email);
                break;
            case "Approved":
                users = users.OrderBy(u => u.Approved);
                break;
            case "Approved_desc":
                users = users.OrderByDescending(u => u.Approved);
                break;
            default:
                users = users.OrderBy(u => u.LastName);
                break;
        }

        users = users.Skip(offset).Take(limit);
        foreach (ApplicationUser user in users)
        {
            userDto.Add(new UserDto(user.RowVersion, user.Id, user.FirstName,
                user.LastName, user.Email, user.Approved));
        }
        return Task.FromResult(userDto);
    }
    public async Task<string> GetUserRoleAsync(string userId, bool returnName)
		{
			ApplicationUser user = await _context.Users.AsNoTracking().Where(u => u.Id == userId).FirstOrDefaultAsync();
			var roles = await _userManager.GetRolesAsync(user);

			foreach (RolePair rolePair in RoleHelpers.Roles)
			{
				IdentityRole identityRole = await _context.Roles.AsNoTracking().Where(role => role.Name == rolePair.Name)
					.FirstOrDefaultAsync();
				if (identityRole !=null && roles.Contains(identityRole.Name))
					return returnName ? rolePair.Name : rolePair.Description;
			}
			return "";
		}
		public async Task<string> GetUserRoleAsync(string email)
		{
			ApplicationUser user = await _context.Users.AsNoTracking().Where(u => u.Email == email).FirstOrDefaultAsync();
			var roles = await _userManager.GetRolesAsync(user);

			foreach (RolePair rolePair in RoleHelpers.Roles)
			{
				IdentityRole identityRole = await _context.Roles.AsNoTracking().Where(role => role.Name == rolePair.Name).FirstOrDefaultAsync();
				if (roles.Contains(identityRole.Name))
					return rolePair.Name;
			}
			return "";
		}
		public async Task<UserDto> FindUserAsync(string userId)
		{
			var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == userId);

            return new UserDto(user.RowVersion, user.Id, user.FirstName,
            user.LastName, user.Email, user.Approved);

        }
        public async Task<(Result, string UserId)> CreateUserAsync(string userName, string password)
		    {
            // In case of racing conditions the error will be returned by the CreateAsync method
            // This extra check is made becuase CreateAsync produces errors for both email and username
            // (when only the email is exposed to the GUI)
            var user = new ApplicationUser
            {
                UserName = userName,
                Email = userName,
            };

            var result = await _userManager.CreateAsync(user, password);

            return (result.ToApplicationResult(), user.Id);
        }
		public async Task<IdentityResult> UpdateUserAsync(IApplicationUser user, string newUserRole, byte[] rowVersion)
		{
			var existingUser = await _userManager.FindByEmailAsync(user.Email);
			if (existingUser != null && existingUser.Id != user.Id)
				return IdentityResult.Failed(new IdentityError() { Description = "Email already in use!" });

			// _context.Entry(departmentToUpdate).Property("RowVersion").OriginalValue = rowVersion;
			_context.Entry(user).State = EntityState.Modified;
			_context.Entry(user).Property("RowVersion").OriginalValue = rowVersion;

			// var result = await _userManager.UpdateAsync(user);
			// var result = _context.Users.Update(user);

			await _context.SaveChangesAsync();

			string[] existingRoles = (await _userManager.GetRolesAsync((ApplicationUser)user)).ToArray();
			var result = await _userManager.RemoveFromRolesAsync((ApplicationUser)user, existingRoles);

			if (result.Succeeded)
				result = await _userManager.AddToRoleAsync((ApplicationUser)user, newUserRole);

			return result;
		}
		//public async Task<IdentityResult> DeleteUserAsync(string userId)
		//{
		//	IApplicationUser user = await _userManager.FindByIdAsync(userId);
		//	return await _userManager.DeleteAsync(user);
		//}
		public async Task<IdentityResult> ChangePasswordAsync(IApplicationUser user, string password)
		{
			var result = await _userManager.RemovePasswordAsync((ApplicationUser)user);
			if (result.Succeeded)
				result = await _userManager.AddPasswordAsync((ApplicationUser)user, password);

			return result;
		}
		public async Task<bool> IsEmailInUseAsync(string email, string excludeUserID)
		{
			ApplicationUser user = await _userManager.FindByEmailAsync(email);

			return user != null && user.Id != excludeUserID;
		}
		public async Task<bool> IsEmailInUseAsync(string email)
		{
			return await IsEmailInUseAsync(email, null);
		}


}


