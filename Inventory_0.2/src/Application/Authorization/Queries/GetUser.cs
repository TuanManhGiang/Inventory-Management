using Inventory_0._2.Application.Common.Interfaces;
using Inventory_0._2.Application.TodoLists.Queries.GetTodos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_0._2.Application.Authorization.Queries
{
   // Truy vấn lấy thông tin về người dùng theo các thông số truy vấn
public record GetUsersQuery() : IRequest<UserPageDto>;

// Truy vấn xử lý lấy thông tin về người dùng
public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, UserPageDto>
{
    private readonly IUserManagementService _umService;
    private readonly IMapper _mapper;

    public GetUsersQueryHandler(IUserManagementService umService, IMapper mapper)
    {
        _umService = umService;
        _mapper = mapper;
    }

    public async Task<UserPageDto> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
            UserPageDto userPageDto = new UserPageDto();

            List<UserDto> users = await _umService.GetAllUsers();
            userPageDto.TotalUsers = users.Count;

        foreach (UserDto user in users)
        {
            UserDto userDto = _mapper.Map<UserDto>(user);
            string userRole = await _umService.GetUserRoleAsync(user.Id, true);
                userDto.Role = userRole;
                userPageDto.Users.Add(userDto);
        }

        return userPageDto;
    }
}


}
