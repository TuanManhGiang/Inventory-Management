using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory_0._2.Application.TodoItems.Queries.GetTodoItemsWithPagination;
using Inventory_0._2.Domain.Entities;
using warehouse_management.Domain.Entities;

namespace Inventory_0._2.Application.Products.Queries;
public class ProductDto
{
    public string WareHouseId { get; set; }
    public string ProductId { get; set; }

    public string MaterialName { get; set; }

    public string Unit { get; set; }

    public string Type { get; set; }

    public string Color { get; set; }

    public string Size { get; set; }

    public string ShelfId { get; set; }

    public string CabinetId { get; set; }

    public int QuantityOnHand { get; set; }
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Product, ProductDto>();
            // Create a mapping from the anonymous type to ProductDto
        }
    }

}
