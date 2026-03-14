using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;

namespace HabitUp.Services;

public class ToDoService(IDynamoDBContext context) : IToDoService
{
    private readonly IDynamoDBContext _context = context;

    public Task SaveAsync(Models.ToDoItem item) => _context.SaveAsync(item);

    public Task<Models.ToDoItem> GetAsync(string id) => _context.LoadAsync<Models.ToDoItem>(id);
    
    public Task<List<Models.ToDoItem>> GetAllAsync() =>
        _context.ScanAsync<Models.ToDoItem>(new List<ScanCondition>()).GetRemainingAsync();

    public Task DeleteAsync(string id) => _context.DeleteAsync<Models.ToDoItem>(id);
}