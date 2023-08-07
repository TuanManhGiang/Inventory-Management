using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory_0._2.Application.Common.Interfaces;
using Inventory_0._2.Application.Products.Queries;

namespace Inventory_0._2.Application.Suppliers.Querries;
public record GetAllSuppliers : IRequest<List<SupplierDto>>;

public class GetAllSuppliersHandler : IRequestHandler<GetAllSuppliers, List<SupplierDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetAllSuppliersHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<SupplierDto>> Handle(GetAllSuppliers request, CancellationToken cancellationToken)
    {

        //List<ProductDto> listProduct = new List<ProductDto>();

        //listProduct = await _context.Products
        //    .Where(x => x.MaterialName == request.MaterialName)
        //    .OrderBy(x => x.MaterialName)
        //    .ProjectTo<ProductDto>(_mapper.ConfigurationProvider).ToListAsync();
        //return listProduct;

        var query = from suplier in _context.Suppliers
                    select new SupplierDto
                    {
                        SupplierName = suplier.SupplierName,
                        Address = suplier.Address,
                        Phone = suplier.Phone,
                        Status = suplier.Status,

                    };
        return await query.ToListAsync(cancellationToken);

    }
}
