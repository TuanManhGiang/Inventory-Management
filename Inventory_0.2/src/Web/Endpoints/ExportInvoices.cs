using Inventory_0._2.Application.ExportInvoices.Commands;
using Inventory_0._2.Application.ExportInvoices.Querries;
using Inventory_0._2.Application.ImportInvoices.Commands;
using Inventory_0._2.Application.ImportInvoices.Querries;

namespace Inventory_0._2.Web.Endpoints;

public class ExportInvoices : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)

            .MapGet(GetExportInvoiceByWarehouse, "{warehouseId}")
            .MapGet(GetExportInvoice, "/all")
            .MapGet(GetExportInvoiceDetails, "/ExportDetails/{ExportId}")
            .MapPost(CreateExportInvoices);


    }


    public async Task<List<ExportInvoiceDto>> GetExportInvoice(ISender sender, [AsParameters] GetExportInvoice query)
    {
        return await sender.Send(query);
    }
    public async Task<ExportDetailsDto> GetExportInvoiceDetails(ISender sender, string ImportId)
    {
        return await sender.Send(new GetExportInvoiceDetails(ImportId));
    }

    public async Task<List<ExportInvoiceDto>> GetExportInvoiceByWarehouse(ISender sender, string warehouseId)
    {
        return await sender.Send(new GetExportInvoiceByWarehouse(warehouseId));
    }
    public async Task<string> CreateExportInvoices(ISender sender, CreateExportCommand command)
    {
        return await sender.Send(command);
    }

}
