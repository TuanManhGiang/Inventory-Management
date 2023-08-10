using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory_0._2.Application.Common.Interfaces;
using Inventory_0._2.Application.ImportInvoices.Querries;

namespace Inventory_0._2.Application.ExportInvoices.Querries;
public record GetExportInvoiceDetails(string ExportId) : IRequest<ExportDetailsDto>;

public class GetExportInvoiceDetailsHandler : IRequestHandler<GetExportInvoiceDetails, ExportDetailsDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetExportInvoiceDetailsHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ExportDetailsDto> Handle(GetExportInvoiceDetails request, CancellationToken cancellationToken)
    {

        //List<ProductDto> listProduct = new List<ProductDto>();

        //listProduct = await _context.Products
        //    .Where(x => x.MaterialName == request.MaterialName)
        //    .OrderBy(x => x.MaterialName)
        //    .ProjectTo<ProductDto>(_mapper.ConfigurationProvider).ToListAsync();
        //return listProduct;

        var query = from export in _context.ExportInvoices

                    where export.Status == "Chưa nhập" && export.ExportId == request.ExportId
                    select new ExportDetailsDto
                    {

                        ImportId = export.ExportId,
                        CreatedDate = export.CreatedDate,
                        ImportDate = export.ExportDate,
                        CreatedByEmployeeId = export.CreatedByEmployeeId,
                        ImportedByEmployeeId = export.ExportedByEmployeeId,
                        ExportTo = export.ExportTo,
                        Status = export.Status
                    };
        ExportDetailsDto listExport = await query.FirstOrDefaultAsync(cancellationToken);
        var queryDetails = from export in _context.ExportInvoiceDetails
                           where export.ExportId != request.ExportId
                           select new ExportDto
                           {
                               ProductId = export.ProductId,
                               Quantity = export.Quantity,
                               UnitPrice = export.UnitPrice,
                           };
        listExport.ExportDetailsDtos = await queryDetails.ToListAsync();
        return listExport;

    }
}