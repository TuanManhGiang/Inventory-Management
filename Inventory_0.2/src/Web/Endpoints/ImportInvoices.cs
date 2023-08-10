using Inventory_0._2.Application.ImportInvoices.Commands;
using Inventory_0._2.Application.ImportInvoices.Querries;
using Inventory_0._2.Application.Suppliers.Commands;
using Inventory_0._2.Application.Suppliers.Querries;

namespace Inventory_0._2.Web.Endpoints;

public class ImportInvoices : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)

            .MapGet(GetImportInvoiceByWarehouse, "{warehouseId}")
            .MapGet(GetImportInvoice,"/all")
            .MapGet(GetImportInvoiceDetails, "/importDetails/{ImportId}")
            .MapPost(CreateImportInvoices);


    }


    public async Task<List<ImportInvoiceDto>> GetImportInvoice(ISender sender, [AsParameters] GetImportInvoice query)
    {
        return await sender.Send(query);
    }
    public async Task<ImportDetailsDto> GetImportInvoiceDetails(ISender sender, string ImportId)
    {
        return await sender.Send(new GetImportInvoiceDetails(ImportId));
    }

    public async Task<List<ImportInvoiceDto>> GetImportInvoiceByWarehouse(ISender sender, string warehouseId)
    {
        return await sender.Send(new GetImportInvoiceByWarehouse(warehouseId));
    }
    public async Task<string> CreateImportInvoices(ISender sender, CreateImportCommand command)
    {
        return await sender.Send(command);
    }

}
