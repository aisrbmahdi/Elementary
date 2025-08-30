using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using TodoList.Contracts;
using TodoList.Data;
using TodoList.Models;
using TodoList.Services;

namespace TodoList.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController(ITodoService todoService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var toDoItems = await todoService.GetAllAsync();
            return Ok(toDoItems);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTodoRequest request)
        {

            var todo = new ToDoItem(request.Name, request.Iscompleted);
            await todoService.CreateAsync(todo);
            return Ok(todo);
        }

        [HttpGet("{id:int}")]
        public async Task <IActionResult> Get(int id)
        {

            var todo = await todoService.GetByIdAsync(id);
            if (todo == null)
            {
                return NotFound();
            }
            return Ok(todo);
            
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, UpdateTodoRequest request)
        {
            try
            {
                var updatedTodo = await todoService.UpdateAsync(id, request.Name, request.IsCompleted);
                return Ok(updatedTodo);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var isDeleted = await todoService.DeleteAsync(id);
            if (!isDeleted)
            {
                return NotFound();
            }

            return Ok();
        }

    }
}