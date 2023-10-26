using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoAppContext;
using TodoAppModel;
using TodoAppRepositories.Interface;

namespace TodoAppRepositories.Concent
{
    public class TodoRepository : ITodoRepository
    {

        private readonly TodoAppContext.TodoAppContext _context;
        public TodoRepository(TodoAppContext.TodoAppContext context)
        {
            _context = context;
        }
        public async Task<Todo> Create(Todo item)
        {
            await _context.Todos.AddAsync(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<Todo> Delete(int id)
        {
            var todoItem = await _context.Todos.FindAsync(id);

            if (todoItem == null)
            {
                return false;
            }

            _context.Todos.Remove(todoItem);
            await _context.SaveChangesAsync();

            return true;
        }

        public Task<IEnumerable<Todo>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Todo>> GetUserTodos(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<Todo> Update(int id, Todo item)
        {
            var todoItem = await _context.Todos.FindAsync(id);

            if (todoItem == null)
            {
                return null;
            }

            todoItem.Title = item.Title;
            todoItem.Description = item.Description;
            todoItem.Completed = item.Completed;

            await _context.SaveChangesAsync();

            return todoItem;
        }
    }
}
