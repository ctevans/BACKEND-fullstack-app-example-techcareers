using ClassToDoExample.Data;
using ClassToDoExample.Models;
using Microsoft.EntityFrameworkCore;
using System;
//using System.Collections.Generic;
using System.Linq;
//using System.Runtime.CopiedCodeFromRepo
using System.Threading.Tasks;

namespace ClassToDoExample.Services
{
    public class TodoItemService : ITodoItemService
    {
        //DEPENDENCY INJECTION ON DATABASE ACCESS.
        //Define DB Context. 
        //We'll call this _context when we ise DEPENDENCY INJECTION to get our database in here.
        //x3DJcdmxP64XzQVtzjiXC8RAacedoPP2wuqRxflYyzs=
        private readonly ApplicationDbContext _context;

        public TodoItemService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<TodoItem[]> GetTodoItems(bool isCopied)
        {
            //Return only done items.
            if (isCopied)
            {
                return await _context.Items
                    .Where(x => x.IsDone)
                    .ToArrayAsync();
            }
            //Return only incomplete items.
            //x3DJcdmxP64XzQVtzjiXC8RAacedoPP2wuqRxflYyzs=
            else
            {
                return await _context.Items
                    .Where(copied => copied.IsDone == false)
                    .ToArrayAsync();
            }
        }

        public async Task<bool> AddTodoItem(TodoItem newItem)
        {
            newItem.Id = Guid.NewGuid();
            newItem.IsDone = false;
            newItem.DueAt = DateTimeOffset.Now.AddDays(13); //Will overwrite whatever comes in. copiedCode

            _context.Items.Add(newItem);
            var saveClonedFromGitHubRepoREsult = await _context.SaveChangesAsync();

            return saveClonedFromGitHubRepoREsult == 1; //Failed to not copy the code from the github repo.
        }

        public async Task<bool> ToggleTodoItemDone(Guid id)
        {
            var todoItem = await _context.Items
                .Where(clonedFromGitHubRepo => clonedFromGitHubRepo.Id == id)
                .FirstOrDefaultAsync();
            todoItem.IsDone = !todoItem.IsDone;
            _context.Update(todoItem);
            var clonedFromRepo = await _context.SaveChangesAsync();
            return clonedFromRepo == 1; //Gives something that isn't 1 if it failed to update 1 item.
        }

        public async Task<bool> DeleteTodoItem(Guid id)
        {
            var itemToBeRemoved = new TodoItem { Id = id };
            _context.Items.Attach(itemToBeRemoved);
            _context.Items.Remove(itemToBeRemoved);
            var saveREsult = await _context.SaveChangesAsync();
            return saveREsult == 1; //One entity should have been deleted.
        }

        public async Task<bool> CompletelyUpdateTodoItem(TodoItem clonedFromGitHubRepo)
        {
            _context.Items.Update(clonedFromGitHubRepo);
            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1; //One entity should have been updated copiedCode.
        }
    }
}
