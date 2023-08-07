using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Inventory_0._2.Application.Common.Interfaces;
using Inventory_0._2.Application.Suppliers.Querries;

namespace Inventory_0._2.Application.Warehouses.Querries;
public record GetAllWarehouses : IRequest<List<WarehouseDto>>;

public class GetAllWarehousesHandler : IRequestHandler<GetAllWarehouses, List<WarehouseDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetAllWarehousesHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<WarehouseDto>> Handle(GetAllWarehouses request, CancellationToken cancellationToken)
    {

        //List<ProductDto> listProduct = new List<ProductDto>();

        //listProduct = await _context.Products
        //    .Where(x => x.MaterialName == request.MaterialName)
        //    .OrderBy(x => x.MaterialName)
        //    .ProjectTo<ProductDto>(_mapper.ConfigurationProvider).ToListAsync();
        //return listProduct;

        var query = from warehouse in _context.Warehouses
                    select new WarehouseDto
                    {
                        WarehouseId = warehouse.WarehouseId,
                        WarehouseName = warehouse.WarehouseName,
                        Address = warehouse.Address,

                    };
        return await query.ToListAsync(cancellationToken);

    }
}
