using System.Threading.Tasks;
using System.Collections.Generic;
using TodoApi.Domain.Shared;
using TodoApi.Domain.TodoItems;

namespace TodoApi.Services
{
    public class TodoItemService
    {
        private readonly ITodoItemRepository _repo;

        public TodoItemService(ITodoItemRepository repo)
        {
            this._repo = repo;
        }

        public async Task<List<TodoItemDTO>> GetAllAsync()
        {
            var list = await this._repo.GetAllAsync();
            
            List<TodoItemDTO> listDto = list.ConvertAll<TodoItemDTO>(todo => new TodoItemDTO{Id = todo.Id, Name = todo.Name, IsComplete = true});

            return listDto;
        }

        public async Task<TodoItemDTO> GetByIdAsync(TodoItemId id)
        {
            var todo = await this._repo.GetByIdAsync(id);
            
            

            return new TodoItemDTO{Id = todo.Id, Name = todo.Name};
        }

        public async Task<TodoItemDTO> AddAsync(TodoItemDTO dto)
        {
            var todo = new TodoItem(dto.Name);

            await this._repo.AddAsync(todo);

            return new TodoItemDTO { Id = todo.Id, Name = todo.Name };
        }

        public async Task<TodoItemDTO> UpdateAsync(TodoItemDTO dto)
        {
            var todo = await this._repo.GetByIdAsync(new TodoItemId(dto.Id.AsGuid()));   

            // change all field
            todo.changeName(dto.Name);
            
            return new TodoItemDTO { Id = todo.Id, Name = todo.Name };
        }


         public async Task<TodoItemDTO> DeleteAsync(TodoItemId id)
        {
            var todo = await this._repo.GetByIdAsync(id); 

            this._repo.Remove(todo);

            return new TodoItemDTO { Id = todo.Id, Name = todo.Name };
        }
    }
}