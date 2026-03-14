using Microsoft.AspNetCore.Mvc;
using HabitUp.Services;

namespace HabitUp.Controllers;

[ApiController]
[Route("[controller]")]
public class ToDoController(IToDoService service) : ControllerBase
{
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Models.ToDoItem>>> GetAll()
    {
        var items = await service.GetAllAsync();
        return Ok(items);
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<Models.ToDoItem>> Get(string id)
    {
        var item = await service.GetAsync(id);
        return Ok(item);

    }
    
    [HttpPost]
    public async Task<IActionResult> Save(Models.ToDoItem todoItem)
    {
        await service.SaveAsync(todoItem);
        return Ok(todoItem);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Models.ToDoItem>> DeleteTodoItem(string id)
    {
        await service.DeleteAsync(id);
        return NoContent();

    }
    
    [HttpPut("{id}/complete")]
    public async Task<IActionResult> MarkComplete(string id)
    {
        var item = await service.GetAsync(id);
        item.Status = "Completed";
        await service.SaveAsync(item);
        return Ok(item);
    }

    [HttpDelete("completed")]
    public async Task<IActionResult> DeleteCompleted()
    {
        var items = await service.GetAllAsync();
        var completed = items.Where(x => x.Status == "Completed");

        foreach (var item in completed)
            await service.DeleteAsync(item.Id);

        return NoContent();
    }
}