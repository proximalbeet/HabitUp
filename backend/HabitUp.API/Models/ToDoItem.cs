using Amazon.DynamoDBv2.DataModel;

namespace HabitUp.Models;

[DynamoDBTable("ToDo")]
public class ToDoItem
{
    [DynamoDBHashKey("Id")] 
    public string Id { get; set; } = Guid.NewGuid().ToString();

    
    [DynamoDBProperty]
    public string Description { get; set; } = string.Empty;

    [DynamoDBProperty]
    public DateTime? DueDate { get; set; }

    
    [DynamoDBProperty]
    public string Category { get; set; } = string.Empty;
    
    
    [DynamoDBProperty]
    public string Status { get; set; } = string.Empty;

    [DynamoDBProperty] 
    public string Priority { get; set; } = "";

    [DynamoDBIgnore]
    public bool OverDue => Status == "open" && DueDate < DateTime.Today;
}