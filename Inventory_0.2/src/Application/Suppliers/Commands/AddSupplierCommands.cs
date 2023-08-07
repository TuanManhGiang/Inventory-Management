using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory_0._2.Application.Common.Exceptions;
using Inventory_0._2.Application.Common.Interfaces;
using Inventory_0._2.Application.Products.Queries;
using warehouse_management.Domain.Entities;

namespace Inventory_0._2.Application.Suppliers.Commands;
public record AddSupplierCommand : IRequest<string>
{
   

    public string SupplierName { get; set; } 

    public string Address { get; set; } 

    public string Phone { get; set; }


    // Add any other properties needed for creating a product
}

public class AddSupplierCommandHandler : IRequestHandler<AddSupplierCommand, string>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly IDateTime _dateTime;

    public AddSupplierCommandHandler(IApplicationDbContext context, IMapper mapper, IDateTime dateTime)
    {
        _context = context;
        _mapper = mapper;
        _dateTime = dateTime;
    }

    public async Task<string> Handle(AddSupplierCommand request, CancellationToken cancellationToken)
    {

        // Map the command data to the Product entity
        var supplier = new Supplier
        {
            SupplierId = request.SupplierName+_dateTime.Now,
            SupplierName = request.SupplierName,
            Address = request.Address,
            Phone = request.Phone,
            Status = "active",
           
        };
        if (_context.Suppliers.Find(supplier.SupplierId) != null )
        {
            throw new ValidationExistsException(supplier.SupplierId);

        }
        // Add the product to the database
        _context.Suppliers.Add(supplier);
        await _context.SaveChangesAsync(cancellationToken);

        // Map the added product back to the ProductDto
        

        return supplier.SupplierId;
    }
}