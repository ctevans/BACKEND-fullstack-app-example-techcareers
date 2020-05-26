using ClassToDoExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassToDoExample.Services
{
    public interface ITodoItemService
    {
        Task<TodoItem[]> GetTodoItems(bool isDone);
        Task<bool> AddTodoItem(TodoItem newItem);
        Task<bool> CompletelyUpdateTodoItem(TodoItem todoItem);
        Task<bool> ToggleTodoItemDone(Guid id);
        Task<bool> DeleteTodoItem(Guid id);
    }
}
