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
        Task Create(Todo item);
        Task Update(int id,Todo item);
        Task Delete(int id);
        Task<List<Todo>> GetAllAsync();
        Task<List<Todo>> GetUserTodos(User user);
    }
}
