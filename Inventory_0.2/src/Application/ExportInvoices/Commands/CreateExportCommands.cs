using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory_0._2.Application.Common.Interfaces;
using Inventory_0._2.Application.ExportInvoices.Querries;
using Inventory_0._2.Application.ImportInvoices.Querries;
using warehouse_management.Domain.Entities;

namespace Inventory_0._2.Application.ExportInvoices.Commands;
public record CreateExportCommand : IRequest<string>
{

    public DateTime ExportDate { get; set; }
    public string CreatedByEmployeeId { get; set; }

    public string WarehouseId { get; set; }

    public string ExportTo { get; set; }

    public List<ExportDto> ExportDetailsDtos { get; set; }


    // Add any other properties needed for creating a product
}

public class CreateExportCommandHandler : IRequestHandler<CreateExportCommand, string>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly IDateTime _dateTime;

    public CreateExportCommandHandler(IApplicationDbContext context, IMapper mapper, IDateTime dateTime)
    {
        _context = context;
        _mapper = mapper;
        _dateTime = dateTime;
    }

    public async Task<string> Handle(CreateExportCommand request, CancellationToken cancellationToken)
    {

        // Map the command data to the Product entity
        var entity = new ExportInvoice
        {
            ExportId = request.WarehouseId + request.CreatedByEmployeeId + _dateTime.Now.GetHashCode(),
            CreatedDate = _dateTime.Now,
            ExportDate = request.ExportDate,
            CreatedByEmployeeId = request.CreatedByEmployeeId,
            WarehouseId = request.WarehouseId,
            ExportTo = request.ExportTo,
            Status = "Chưa nhập"

        };


        try { _context.ExportInvoices.Add(entity); }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString());
        }
        foreach (ExportDto exportDetailsDto in request.ExportDetailsDtos)
        {

            var exportdetails = new ExportInvoiceDetail
            {
                ExportId = entity.ExportId,
                ProductId = exportDetailsDto.ProductId,
                Quantity = exportDetailsDto.Quantity,
                UnitPrice = exportDetailsDto.UnitPrice,

            };
            try { _context.ExportInvoiceDetails.Add(exportdetails); }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());

            }

        }

        //entity.AddDomainEvent(new TodoItemCreatedEvent(entity));
        await _context.SaveChangesAsync(cancellationToken);

        return entity.ExportId;

    }
}

