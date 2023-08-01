using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Inventory_0._2;
using Inventory_0._2.Application.Authorization.Queries;
using Inventory_0._2.Application.Common.Models;
//using Inventory_0._2.Application.Authorization.Queries;


namespace Inventory_0._2.Application.Common.Interfaces;
public interface IUserManagementService
{
    Task<IdentityRole> GetRoleByNameAsync(string name);
    Task<int> GetAllUsersCountAsync(string searchString);
    Task<List<UserDto>> GetAllUsers();
    //Task<PaginatedList<ApplicationUser>> GetAllUsersPaginatedAsync(int pageIndex, int pageSize, string searchString, string sortOrder);
    Task<List<UserDto>> GetUsersAsync(int offset, int limit, string sortOrder, string searchString);
    Task<string> GetUserRoleAsync(string userId, bool returnName);
    Task<string> GetUserRoleAsync(string email);
    Task<UserDto> FindUserAsync(string userId);
    Task<(Result, string UserId)> CreateUserAsync(string userName, string password);
    Task<IdentityResult> UpdateUserAsync(IApplicationUser user, string newUserRole, byte[] rowVersion);
   // Task<IdentityResult> DeleteUserAsync(string userId);
    Task<IdentityResult> ChangePasswordAsync(IApplicationUser user, string password);
    Task<bool> IsEmailInUseAsync(string email, string excludeUserID);
    Task<bool> IsEmailInUseAsync(string email);
    //Task<IApplicationUser> GetUserAsync(ClaimsPrincipal claimsPrincipal);
}