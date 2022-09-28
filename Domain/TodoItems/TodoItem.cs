namespace TodoApi.Domain.TodoItems
{
    public class TodoItem
    {
        public TodoItem(string Name) {
            this.Id = new TodoItemId(Guid.NewGuid());
            this.Name = Name;
            this.IsComplete = true;
        }

        public TodoItemId? Id { get; set; }
        public string? Name { get; set; }
        public bool IsComplete { get; set; }
        public string? Secret { get; set; }
        
        public void changeName(string Name) {
            this.Name = Name;
        }

    }
    
}