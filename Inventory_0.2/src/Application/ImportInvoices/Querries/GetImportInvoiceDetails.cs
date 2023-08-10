using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory_0._2.Application.Common.Interfaces;
using warehouse_management.Domain.Entities;

namespace Inventory_0._2.Application.ImportInvoices.Querries;

public record GetImportInvoiceDetails( string ImportId) : IRequest<ImportDetailsDto>;

public class GetImportInvoiceDetailsHandler : IRequestHandler<GetImportInvoiceDetails, ImportDetailsDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetImportInvoiceDetailsHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ImportDetailsDto> Handle(GetImportInvoiceDetails request, CancellationToken cancellationToken)
    {

        //List<ProductDto> listProduct = new List<ProductDto>();

        //listProduct = await _context.Products
        //    .Where(x => x.MaterialName == request.MaterialName)
        //    .OrderBy(x => x.MaterialName)
        //    .ProjectTo<ProductDto>(_mapper.ConfigurationProvider).ToListAsync();
        //return listProduct;

        var query = from import in _context.ImportInvoices

                    where import.Status == "Chưa nhập" && import.ImportId == request.ImportId
                    select new ImportDetailsDto
                    {

                        ImportId = import.ImportId,
                        CreatedDate = import.CreatedDate,
                        ImportDate = import.ImportDate,
                        CreatedByEmployeeId = import.CreatedByEmployeeId,
                        ImportedByEmployeeId = import.ImportedByEmployeeId,
                        SupplierId = import.SupplierId,
                        Status = import.Status
                    };
        ImportDetailsDto listImport = await query.FirstOrDefaultAsync(cancellationToken);
        var queryDetails = from import in _context.ImportInvoiceDetails
                           where import.ImportId != request.ImportId
                           select new ImportDto
                           {
                               ProductId = import.ProductId,
                               Quantity = import.Quantity,
                               UnitPrice = import.UnitPrice,
                           };
        listImport.ImportDetailsDtos = await queryDetails.ToListAsync();
        return listImport;

    }
}
