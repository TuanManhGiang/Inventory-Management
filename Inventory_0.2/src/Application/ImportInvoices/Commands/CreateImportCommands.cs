using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory_0._2.Application.Common.Exceptions;
using Inventory_0._2.Application.Common.Interfaces;
using Inventory_0._2.Application.ImportInvoices.Querries;
using Inventory_0._2.Application.Products.Queries;
using Inventory_0._2.Domain.Entities;
using Inventory_0._2.Domain.Events;
using warehouse_management.Domain.Entities;

namespace Inventory_0._2.Application.ImportInvoices.Commands;
public record CreateImportCommand : IRequest<string>
{

    public DateTime ImportDate { get; set; }
    public string CreatedByEmployeeId { get; set; }

    public string WarehouseId { get; set; }

    public string SupplierId { get; set; }

    public List<ImportDto> ImportDetailsDtos { get; set; }


    // Add any other properties needed for creating a product
}

public class CreateImportCommandHandler : IRequestHandler<CreateImportCommand, string>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly IDateTime _dateTime;

    public CreateImportCommandHandler(IApplicationDbContext context, IMapper mapper, IDateTime dateTime)
    {
        _context = context;
        _mapper = mapper;
        _dateTime = dateTime;
    }

    public async Task<string> Handle(CreateImportCommand request, CancellationToken cancellationToken)
    {

        // Map the command data to the Product entity
        var entity = new ImportInvoice
        {
            ImportId = request.WarehouseId+ request.CreatedByEmployeeId+ _dateTime.Now.GetHashCode(),
            CreatedDate= _dateTime.Now,
            ImportDate = request.ImportDate,
            CreatedByEmployeeId = request.CreatedByEmployeeId,
            WarehouseId = request.WarehouseId,
            SupplierId = request.SupplierId,
            Status = "Chưa nhập"
        };

        
        try { _context.ImportInvoices.Add(entity); }
        catch (Exception ex) {
        throw new Exception(ex.ToString());
        }
        foreach(ImportDto importDetailsDto in request.ImportDetailsDtos) {

            var importdetails = new ImportInvoiceDetail
            {
                ImportId = entity.ImportId,
                ProductId = importDetailsDto.ProductId,
                Quantity = importDetailsDto.Quantity,
                UnitPrice = importDetailsDto.UnitPrice,

            };
            try { _context.ImportInvoiceDetails.Add(importdetails); }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
                
            }
           
        }

        //entity.AddDomainEvent(new TodoItemCreatedEvent(entity));
        await _context.SaveChangesAsync(cancellationToken);

        return entity.ImportId;

    }
}
