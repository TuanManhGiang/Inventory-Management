using Inventory_0._2.Application.Products.Commands;
using Inventory_0._2.Application.Products.Queries;
using Inventory_0._2.Application.Suppliers.Commands;
using Inventory_0._2.Application.Suppliers.Querries;

namespace Inventory_0._2.Web.Endpoints;

public class Suppliers : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)

            .MapGet(GetAllSuppliers)
            .MapGet(GetSuppliersByName, "{name}")
            .MapPost(CreateSuppliers);


    }


    public async Task<List<SupplierDto>> GetAllSuppliers(ISender sender, [AsParameters] GetAllSuppliers query)
    {
        return await sender.Send(query);
    }
    public async Task<List<SupplierDto>> GetSuppliersByName(ISender sender, string name)
    {
        return await sender.Send(new GetSuppliersByNameQuery(name));
    }
    public async Task<string> CreateSuppliers(ISender sender, AddSupplierCommand command)
    {
        return await sender.Send(command);
    }

}