using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory_0._2.Application.Common.Exceptions;
using Inventory_0._2.Application.Common.Interfaces;
using Inventory_0._2.Application.Products.Queries;
using warehouse_management.Domain.Entities;

namespace Inventory_0._2.Application.Products.Commands;
public record AddProductCommand : IRequest<ProductDto>
{
    public string ProductId { get; set; }

    public string MaterialName { get; set; }
    public string Unit { get; set; }
    public string Type { get; set; }
    public string Color { get; set; }
    public string Size { get; set; }
    // Add any other properties needed for creating a product
}

public class AddProductCommandHandler : IRequestHandler<AddProductCommand, ProductDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public AddProductCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ProductDto> Handle(AddProductCommand request, CancellationToken cancellationToken)
    {

        // Map the command data to the Product entity
        var product = new Product
        {
            ProductId = request.ProductId,
            MaterialName = request.MaterialName,
            Unit = request.Unit,
            Type = request.Type,
            Color = request.Color,
            Size = request.Size,
            // Set other properties as needed
        };
        if(_context.Products.Find(product.ProductId)!=null) {
            throw new ValidationExistsException(product.ProductId);
            
        }
        // Add the product to the database
        _context.Products.Add(product);
        await _context.SaveChangesAsync(cancellationToken);

        // Map the added product back to the ProductDto
        var productDto = _mapper.Map<ProductDto>(product);

        return productDto;
    }
}
