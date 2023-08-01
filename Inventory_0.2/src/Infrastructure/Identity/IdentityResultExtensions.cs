using Microsoft.AspNetCore.Identity;
using Inventory_0._2.Application.Common.Models;

namespace Inventory_0._2.Infrastructure.Identity;
public static class IdentityResultExtensions
{
    public static Result ToApplicationResult(this IdentityResult result)
    {
        return result.Succeeded
            ? Result.Success()
            : Result.Failure(result.Errors.Select(e => e.Description));
    }
}
