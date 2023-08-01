using Inventory_0._2.Application.Common.Interfaces;

namespace Inventory_0._2.Infrastructure.Services;
public class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.Now;
}
