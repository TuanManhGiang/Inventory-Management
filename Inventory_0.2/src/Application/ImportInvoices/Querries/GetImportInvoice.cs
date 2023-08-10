using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory_0._2.Application.Common.Interfaces;

namespace Inventory_0._2.Application.ImportInvoices.Querries;
public record GetImportInvoice : IRequest<List<ImportInvoiceDto>>
{
 

}

public class GetImportInvoiceHandler : IRequestHandler<GetImportInvoice, List<ImportInvoiceDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetImportInvoiceHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<ImportInvoiceDto>> Handle(GetImportInvoice request, CancellationToken cancellationToken)
    {

        //List<ProductDto> listProduct = new List<ProductDto>();

        //listProduct = await _context.Products
        //    .Where(x => x.MaterialName == request.MaterialName)
        //    .OrderBy(x => x.MaterialName)
        //    .ProjectTo<ProductDto>(_mapper.ConfigurationProvider).ToListAsync();
        //return listProduct;

        var query = from import in _context.ImportInvoices

                    where import.Status == "Chưa nhập"
                    select new ImportInvoiceDto
                    {

                        ImportId = import.ImportId,
                        CreatedDate = import.CreatedDate,
                        ImportDate = import.ImportDate,
                        CreatedByEmployeeId = import.CreatedByEmployeeId,
                        ImportedByEmployeeId = import.ImportedByEmployeeId,
                        SupplierId = import.SupplierId,
                        Status = import.Status
                    };
        return await query.ToListAsync(cancellationToken);

    }
}
