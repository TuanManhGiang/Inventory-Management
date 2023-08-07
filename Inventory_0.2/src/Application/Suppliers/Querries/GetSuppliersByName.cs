using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory_0._2.Application.Common.Interfaces;
using Inventory_0._2.Application.Products.Queries;

namespace Inventory_0._2.Application.Suppliers.Querries;
public record GetSuppliersByNameQuery(string SupplierName) : IRequest<List<SupplierDto>>;


public class GetSuppliersByNameQueryHandler : IRequestHandler<GetSuppliersByNameQuery, List<SupplierDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetSuppliersByNameQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<SupplierDto>> Handle(GetSuppliersByNameQuery request, CancellationToken cancellationToken)
    {

        var query = from suplier in _context.Suppliers
                  
                    where suplier.SupplierName == request.SupplierName
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