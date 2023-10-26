using Microsoft.EntityFrameworkCore;
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
        public async Task Create(Todo item)
        {
            using (var context = new TodoAppContext.TodoAppContext())
            {
                context.Todos.Add(item);
                await context.SaveChangesAsync();
            }
        }

        public async Task Delete(int id)
        {
            var todoItem = await _context.Todos.FindAsync(id);

            if (todoItem == null)
            {
                return;
            }

            _context.Todos.Remove(todoItem);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Todo>> GetAllAsync()
        {
            return await _context.Todos.ToListAsync();
        }

        public async Task<List<Todo>> GetUserTodos(User user)
        {
            var userData = await _context.Users.FirstAsync(user.Id);

            var todoIds = userData.TodoIds;

            var todos = await _context.Todos.Where(todo => todo.Id in todoIds).ToListAsync();

            return todos;
        }

        public async Task Update(int id, Todo item)
        {
            var todoItem = await _context.Todos.FindAsync(id);
            todoItem.Title = item.Title;
            todoItem.Description = item.Description;
            todoItem.Completed = item.Completed;

            await _context.SaveChangesAsync();
        }
    }
}
