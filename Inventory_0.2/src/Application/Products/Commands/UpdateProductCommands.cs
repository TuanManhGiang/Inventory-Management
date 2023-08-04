using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory_0._2.Application.Common.Interfaces;
using Inventory_0._2.Application.Products.Queries;

namespace Inventory_0._2.Application.Products.Commands;
public record UpdateProductCommand : IRequest
{
    public string ProductId { get; set; }
    public string MaterialName { get; set; }
    public string Type { get; set; }
    public string Color { get; set; }
    public string Size { get; set; }
    // Add any other properties needed for updating a product
}
public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public UpdateProductCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _context.Products.FindAsync(new object[] { request.ProductId }, cancellationToken);

  
        Guard.Against.NotFound(request.ProductId, product);
        // Update the product properties based on the command data
        product.MaterialName = request.MaterialName;
        product.Type = request.Type;
        product.Color = request.Color;
        product.Size = request.Size;
        // Update other properties as needed

        await _context.SaveChangesAsync(cancellationToken);

        // Map the updated product back to the ProductDto

    }
}


