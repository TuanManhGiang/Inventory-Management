using Inventory_0._2.Domain.Entities;

namespace Inventory_0._2.Application.Common.Models;
public class LookupDto
{
    public int Id { get; init; }

    public string Title { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<TodoList, LookupDto>();
            CreateMap<TodoItem, LookupDto>();
        }
    }
}
