using Inventory_0._2.Application.Suppliers.Querries;
using Inventory_0._2.Application.Warehouses.Querries;

namespace Inventory_0._2.Web.Endpoints;

public class Warehouses : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)

            .MapGet(GetAllWarehouses);
        // .MapGet(GetSuppliersByName, "{name}")
        //.MapPost(CreateSuppliers);


    }


    public async Task<List<WarehouseDto>> GetAllWarehouses(ISender sender, [AsParameters] GetAllWarehouses query)
    {
        return await sender.Send(query);
    }
}