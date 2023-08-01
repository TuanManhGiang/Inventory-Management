using System;
using System.Collections.Generic;

namespace warehouse_management.Domain.Entities;

public partial class ProductDetail
{
    public string ProductId { get; set; } = null!;

    public string WarehouseId { get; set; } = null!;

    public string ShelfId { get; set; }

    public string CabinetId { get; set; }

    public int QuantityOnHand { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual Warehouse Warehouse { get; set; } = null!;
}
