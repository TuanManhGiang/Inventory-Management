using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory_0._2.Application.Common.Interfaces;
using Inventory_0._2.Application.ImportInvoices.Querries;

namespace Inventory_0._2.Application.ExportInvoices.Querries;
public record GetExportInvoice : IRequest<List<ExportInvoiceDto>>
{


}

public class GetExportInvoiceHandler : IRequestHandler<GetExportInvoice, List<ExportInvoiceDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetExportInvoiceHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<ExportInvoiceDto>> Handle(GetExportInvoice request, CancellationToken cancellationToken)
    {

        //List<ProductDto> listProduct = new List<ProductDto>();

        //listProduct = await _context.Products
        //    .Where(x => x.MaterialName == request.MaterialName)
        //    .OrderBy(x => x.MaterialName)
        //    .ProjectTo<ProductDto>(_mapper.ConfigurationProvider).ToListAsync();
        //return listProduct;

        var query = from export in _context.ExportInvoices

                    where export.Status == "Chưa nhập"
                    select new ExportInvoiceDto
                    {

                        ExportId = export.ExportId,
                        CreatedDate = export.CreatedDate,
                        ExportDate = export.ExportDate,
                        CreatedByEmployeeId = export.CreatedByEmployeeId,
                        ExportedByEmployeeId = export.ExportedByEmployeeId,
                        ExportTo = export.ExportTo,
                        Status =export.Status
                    };
        return await query.ToListAsync(cancellationToken);

    }
}

