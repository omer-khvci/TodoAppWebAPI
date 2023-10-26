using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoAppModel;

namespace TodoAppRepositories.Interface
{
    public interface ITodoRepository
    {
        Task<Todo> Create(Todo item);
        Task<Todo> Update(int id,Todo item);
        Task<Todo> Delete(int id);
        Task<IEnumerable<Todo>> GetAllAsync();
        Task<IEnumerable<Todo>> GetUserTodos(User user);
    }
}
