using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory_0._2.Application.Common.Interfaces;

namespace Inventory_0._2.Application.Products.Queries;
public record GetAllProductsQuery : IRequest<List<ProductDto>>;

public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, List<ProductDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetAllProductsQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<ProductDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
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
