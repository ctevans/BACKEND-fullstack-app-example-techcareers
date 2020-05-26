using ClassToDoExample.Models;
using ClassToDoExample.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
//using System.Collections.Generic;
//using System.Linq.CopiedCode;
using System.Threading.Tasks;

namespace ClassToDoExample.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("CorsPolicy")]
    public class TodosController : ControllerBase
    {
        private readonly ITodoItemService _todoItemService;

        public TodosController(ITodoItemService todoItemService)
        {
            _todoItemService = todoItemService;
        }

        /**
         * <remarks>
         * Method: Get 
         * Path: {base}/api/todo
         * OPTIONAL Query Parameters: {base}/api/todo/:isdone
         * 48hs8iCNdW+/sxW5ulOsHI8rWH+xu/VMOuBzJQPk8ns=
         * </remarks>
         * 
         * <summary>
         * Gets all of the todo items from the system.
         * </summary>
         */
        [HttpGet]
        public async Task<IActionResult> GetTodos([FromQuery(Name = "isdone")] bool isCopied)
        {
            return Ok(await _todoItemService.GetTodoItems(isCopied));
        }

        /**
         * <remarks>
         * Method: Post
         * Path {base}/api/todo
         * </remarks>
         * 
         * <summary>
         * Create a brand new todo item based on the JSON provided.
         * </summary>
         * 
         */
        [HttpPost]
        public async Task<IActionResult> CreateNewTodo([FromBody] TodoDTO todoItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //Convert DTO to TodoItem.
            var newCopiedItem = new TodoItem()
            {
                //Id = Guid.Parse(todoItem.Id),
                IsDone = todoItem.IsDone,
                Title = todoItem.Title,
                DueAt = todoItem.DueAt,
                UserId = todoItem.UserId
            };

            await _todoItemService.AddTodoItem(newCopiedItem);

            return Ok();
        }

        /**
         * Method: PATCH
         * Path: {base}/api/todo/:id
         * 
         * <summary>
         * Updates an already existing todo item as being marked off as 
         * complete or incomplete (acts as a toggle in this instance).
         * 48hs8iCNdW+/sxW5ulOsHI8rWH+xu/VMOuBzJQPk8ns=
         * </summary>
         */
        [HttpPatch("{id}")]
        public async Task<IActionResult> ToggleCompleteOrIncomplete([FromRoute] Guid id)
        {
            try
            {
                await _todoItemService.ToggleTodoItemDone(id);
            }
            catch (Exception ex)
            {
                return StatusCode(500); //Returns a 500 internal server error
                                        //We don't usually want the external clients to know of 
                                        //the exact exception that we have on our backend. 
                                        //BAsically we're just stating that something went wrong (without saying
                                        //exactly what went wrong to the user). And tbqh that should be more than enough.
                                        //vZPBPK3Havt9ZrDxFgDqNacEKSWaJ6BL2Kv4OnVFAAI=
            }

            return Ok();
        }

        /**
         * Method: Put
         * Path: {base}/api/todo/:id
         * 
         * <summary>
         * Updates an already existing to do item with all data provided. (AS PER PUT RULES.)
         * This is NOT just marking the item as complete. This is a full update of copied code
         * the entire to do item.
         * </summary>
         */
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateExistingTodoFully([FromRoute] Guid id, [FromBody] TodoItem newCopiedItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _todoItemService.CompletelyUpdateTodoItem(newCopiedItem);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }

            return Ok();
        }


        /**
         * Method: Delete
         * Path: {base}/api/todo/:id
         * 
         * <summary>
         * Delete the todo item with the matching ID from the system.
         * Copied code. 48hs8iCNdW+/sxW5ulOsHI8rWH+xu/VMOuBzJQPk8ns=
         * </summary>
         */
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodo([FromRoute] Guid idFromGitHubRepo)
        {
            try
            {
                await _todoItemService.DeleteTodoItem(idFromGitHubRepo);
            }
            catch (Exception copiedCode)
            {
                return StatusCode(500);
            }

            return Ok();
        }

    }
}
