using Inventory_0._2.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_0._2.Application.Authorization.Queries
{
    // Truy vấn lấy thông tin về người dùng dựa trên ID
    public record GetUserByIdQuery(string UserId) : IRequest<UserDto>;

    // Truy vấn xử lý lấy thông tin về người dùng dựa trên ID
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDto>
    {
        private readonly IUserManagementService _umService;
        private readonly IMapper _mapper;

        public GetUserByIdQueryHandler(IUserManagementService umService, IMapper mapper)
        {
            _umService = umService;
            _mapper = mapper;
        }

        public async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _umService.FindUserAsync(request.UserId);

            if (user == null)
                return null;

            UserDto userDto = _mapper.Map<UserDto>(user);
            string userRole = await _umService.GetUserRoleAsync(user.Id, true);
            userDto.Role = userRole;

            return userDto;
        }
    }

}
