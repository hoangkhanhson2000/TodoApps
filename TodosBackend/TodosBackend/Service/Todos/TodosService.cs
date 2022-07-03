using TodosBackend.Data;
using TodosBackend.Model;

namespace TodosBackend.Service.Todos
{
    public class TodosService : ITodosService
    {
        private readonly TodosDbContext _todosDbContext;
        public TodosService(TodosDbContext todosDbContext)
        {
            _todosDbContext = todosDbContext;
        }
        public bool AddTodo(Todo todo)
        {
            throw new NotImplementedException();
        }

        public bool DeleteTodo(Todo todo)
        {
            throw new NotImplementedException();
        }

        public List<Todo> GetTodo()
        {
            return _todosDbContext.Todos.OrderByDescending(x => x.Id).ToList();
        }

        public bool UpdateTodo(Todo todo)
        {
            throw new NotImplementedException();
        }
    }
}
