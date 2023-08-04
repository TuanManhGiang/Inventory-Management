using Inventory_0._2.Application.Common.Models;
using Inventory_0._2.Application.Products.Commands;
using Inventory_0._2.Application.Products.Queries;
using Inventory_0._2.Application.TodoItems.Commands.DeleteTodoItem;
using Inventory_0._2.Application.TodoItems.Queries.GetTodoItemsWithPagination;

namespace Inventory_0._2.Web.Endpoints;

public class Products : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
         
            .MapGet(GetProductsWithPagination)
            .MapGet(GetProductsByID,"{id}")
            .MapGet(GetAllProducts)
            .MapPost(CreateProduct)
            .MapPut(UpdateProduct,"/{id}");

    }


    public async Task<List<ProductDto>> GetProductsWithPagination(ISender sender, [AsParameters] GetProductsWithPaginationQuery query)
    {
        return await sender.Send(query);
    }
    public async Task<List<ProductDto>> GetAllProducts(ISender sender,  GetAllProductsQuery query)
    {
        return await sender.Send(query);
    }
    public async Task<List<ProductDto>> GetProductsByID(ISender sender,string id)
    {
        return await sender.Send(new GetProductsByIdQuery(id));

    }
    public async Task<ProductDto> CreateProduct(ISender sender, AddProductCommand command)
    {
        return await sender.Send(command);
    }
    public async Task<IResult> UpdateProduct(ISender sender, string id, UpdateProductCommand command)
    {
        if (id != command.ProductId) return Results.BadRequest();
        await sender.Send(command);
        return Results.NoContent();
    }
}