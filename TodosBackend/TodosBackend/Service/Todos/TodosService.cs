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
            _todosDbContext.Todos.Add(todo);
            _todosDbContext.SaveChanges();
            return true;
        }

        public bool DeleteTodo(int id)
        {
            Todo todo=_todosDbContext.Todos.Find(id);
            _todosDbContext.Todos.Remove(todo);
            _todosDbContext.SaveChanges();  

            return true;
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
