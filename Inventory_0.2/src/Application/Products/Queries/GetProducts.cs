using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory_0._2.Application.Common.Interfaces;
using Inventory_0._2.Application.Common.Mappings;
using Inventory_0._2.Application.Common.Models;
using Inventory_0._2.Application.TodoItems.Queries.GetTodoItemsWithPagination;
using warehouse_management.Domain.Entities;

namespace Inventory_0._2.Application.Products.Queries;
public record GetProductsWithPaginationQuery : IRequest<List<ProductDto>>
{


 
    public string WarehouseId { get; init; }

}

public class GetProductsWithPaginationQueryHandler : IRequestHandler<GetProductsWithPaginationQuery, List<ProductDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetProductsWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<ProductDto>> Handle(GetProductsWithPaginationQuery request, CancellationToken cancellationToken)
    {

        //List<ProductDto> listProduct = new List<ProductDto>();

        //listProduct = await _context.Products
        //    .Where(x => x.MaterialName == request.MaterialName)
        //    .OrderBy(x => x.MaterialName)
        //    .ProjectTo<ProductDto>(_mapper.ConfigurationProvider).ToListAsync();
        //return listProduct;

        var query = from product in _context.Products
                    join productDetail in _context.ProductsDetails
                    on product.ProductId equals productDetail.ProductId 
                    where productDetail.WarehouseId == request.WarehouseId 
                    select new ProductDto
                    {
                        ProductId = productDetail.ProductId,
                        WareHouseId = productDetail.WarehouseId,
                        MaterialName = product.MaterialName,
                        Unit = product.Unit,
                        Type = product.Type,
                        Color = product.Color,
                        Size = product.Size,
                        ShelfId = productDetail.ShelfId,
                        CabinetId = productDetail.CabinetId,
                        QuantityOnHand = productDetail.QuantityOnHand
                    };
        return await query.ToListAsync(cancellationToken);

    }
}
