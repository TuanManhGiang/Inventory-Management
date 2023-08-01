using Inventory_0._2.Application.Common.Interfaces;
using Inventory_0._2.Application.TodoItems.Commands.CreateTodoItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_0._2.Application.Authorization.Commands
{
    public record LoginCommand : IRequest<(bool, string UserId)>
    {

     
        public required string  UserName { get; set; }
        public required string Password { get; set; }

    }
    public class LoginCommandHandler : IRequestHandler<LoginCommand, (bool, string UserId)>
    {
        private readonly IIdentityService _identityService;

        public LoginCommandHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        public async Task<(bool, string UserId)> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            return await _identityService.LoginAsync(request.UserName, request.Password);

        }
    }
}
