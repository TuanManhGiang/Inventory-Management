﻿using Inventory_0._2.Domain.Entities;

namespace Inventory_0._2.Application.TodoItems.Queries.GetTodoItemsWithPagination;
public class TodoItemBriefDto
{
    public int Id { get; init; }

    public int ListId { get; init; }

    public string Title { get; init; }

    public bool Done { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<TodoItem, TodoItemBriefDto>();
        }
    }
}
