
using Microsoft.AspNetCore.Mvc;
using ToDo.Data;
using ToDo.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ToDo.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {

        //  private I_Tasks _taskService;

        //public TaskController(TodoContext db, I_Tasks taskService)
        //{
        //    _taskService = taskService;
        //}
        private readonly TodoContext _context;
        public TaskController(TodoContext context)
        {
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

        }

        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Tasks>>> GetAllTodoItems()
        //{
        //    var todoItems = await _context.Tasks.ToListAsync();

        //    if (todoItems == null || todoItems.Count == 0)
        //    {
        //        return NotFound();
        //    }

        //    return todoItems;
        //}
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tasks>>> GetTodoItems()
        {
            return await _context.Tasks.ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Tasks>> GetTodoItem(int id)
        {
            var todoItem = await _context.Tasks.FindAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            return todoItem;
        }
        [HttpPost]
        public async Task<ActionResult<Tasks>> PostTodoItem(Tasks todoItem)
        {
           
            //_context.Tasks.Add(todoItem);
            await _context.Tasks.AddAsync(todoItem);
            await _context.SaveChangesAsync();


            // Return the created task as JSON in the response body
            return CreatedAtAction(nameof(GetTodoItem), new { id = todoItem.TaskId }, todoItem);


        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoItem(int id, Tasks updated)
        {
            var existingNote = await _context.Tasks.FindAsync(id);
            if (existingNote == null)
            {
                return NotFound();
            }

            existingNote.taskContent = updated.taskContent;
            existingNote.taskStatus = updated.taskStatus;
            _context.Tasks.Update(existingNote);

            await _context.SaveChangesAsync();
           
           

            return Ok(existingNote);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoItem(int id)
        {
            var todoItem = await _context.Tasks.FindAsync(id);
            if (todoItem == null)
            {
                return NotFound();
            }

            _context.Tasks.Remove(todoItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}