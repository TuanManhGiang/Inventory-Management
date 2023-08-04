using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory_0._2.Application.Common.Interfaces;
using Inventory_0._2.Application.TodoItems.Queries.GetTodoItemsWithPagination;

namespace Inventory_0._2.Application.Products.Queries;
public record GetProductsByIdQuery(string ProductId) : IRequest<List<ProductDto>>;


public class GetProductsByIdQueryHandler : IRequestHandler<GetProductsByIdQuery, List<ProductDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetProductsByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<ProductDto>> Handle(GetProductsByIdQuery request, CancellationToken cancellationToken)
    {

        var query = from product in _context.Products join productDetail in _context.ProductsDetails
             on product.ProductId equals productDetail.ProductId
                    where product.ProductId == request.ProductId
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
