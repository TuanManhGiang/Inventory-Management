using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory_0._2.Application.Authorization.Queries;
using Inventory_0._2.Application.Common.Interfaces;
using Microsoft.AspNetCore.Identity;
using Inventory_0._2.Application.Common.Exceptions;
using Inventory_0._2.Application.Common.Models;

namespace Inventory_0._2.Application.Authorization.Commands;
public record CreateUserCommand : IRequest<(Result, string UserId)>
{
    public UserDto UserModel { get; }

    public CreateUserCommand(UserDto userModel)
    {
        UserModel = userModel;
    }
}
public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, (Result, string UserId)>
{
    private readonly IUserManagementService _umService;
    private readonly IMapper _mapper;

    public CreateUserCommandHandler(IUserManagementService umService, IMapper mapper)
    {
        _umService = umService;
        _mapper = mapper;
    }

    public async Task<(Result, string UserId)> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        UserDto userModel = request.UserModel;

 

        if (await _umService.IsEmailInUseAsync(userModel.Email))
        {
            throw new ValidationExistsException(userModel.Email);

        }

        return await _umService.CreateUserAsync(userModel.Email, userModel.Password);
 
    }
}

