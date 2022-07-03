using TodosBackend.Model;

namespace TodosBackend.Service.Todos
{
    public interface ITodosService
    {
        List<Todo> GetTodo();
        Boolean AddTodo(Todo todo);
        Boolean UpdateTodo(Todo todo);
        Boolean DeleteTodo(int id);





    }
}
