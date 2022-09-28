namespace TodoApi.Domain.TodoItems
{
    public class TodoItemDTO
    {
        public TodoItemId? Id { get; set; }
        public string? Name { get; set; }
        public bool IsComplete { get; set; }
    }
}