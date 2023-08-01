//using Inventory_0._2.Application.Authorization.Commands;
//using Inventory_0._2.Application.Authorization.Queries;
using Inventory_0._2.Application.Authorization.Commands;
using Inventory_0._2.Application.Authorization.Queries;
using Inventory_0._2.Application.Common.Models;
using Inventory_0._2.Application.TodoItems.Commands.CreateTodoItem;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Inventory_0._2.Web.Endpoints
{
    public class Authentication : EndpointGroupBase
    {
        public override void Map(WebApplication app)
        {
            app.MapGroup(this)


             .MapPost(Login, "/Login")
             .MapPost(CreateUser,"/Register" )
             .MapGet(GetAllUser, "/GetAllUsers")
             .MapGet("/Users/{id}", GetUserById)
             ;


        }
        public async Task<(bool, string UserId)> Login(ISender sender, LoginCommand command)
        {
            return await sender.Send(command);
        }
        public async Task<UserDto> GetUserById(ISender sender, string id)
        {
            GetUserByIdQuery query = new GetUserByIdQuery(id);
            var userDto = await sender.Send(query);

            if (userDto == null)
                return null; // Assume NotFoundException is a custom exception representing a 404 Not Found response.

            return userDto;
        }
        public async Task<UserPageDto> GetAllUser(ISender sender)
        {
            GetUsersQuery query = new GetUsersQuery();
            var userPageDto = await sender.Send(query);

            if (userPageDto == null)

                return null; // Assume NotFoundException is a custom exception representing a 404 Not Found response.

            return userPageDto;
        }
        public async Task<(Result, string UserId)> CreateUser(ISender sender, CreateUserCommand createUser)
        {
            return await sender.Send(createUser);
        }

    }


}


