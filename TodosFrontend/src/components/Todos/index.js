import { useEffect, useState } from "react";
import { AddOrEditTodoAPI, getTodoAPI } from "../../api/todos";
import "./index.css"

const Todos = () => {
  const [todos, setTodos] = useState([]);

  //alert(process.env.REACT_APP_URL_API);
  useEffect(() => {
    fetchData();
  }, []);
  const fetchData = async () => {
    setTodos(await getTodoAPI());
  }
  const AddOrEditTodo=async(event)=>{
    event.preventDefault();
    const val= event.target[0].value;
    const id= event.target[1].value;

   
    if (id)
    {
      // update
    }
    else
    {
      await AddOrEditTodoAPI({
        name:val
      });
      fetchData();
    }

  }
  return (
    <main id="todolist">
      <h1>
        Danh sách
        <span>Việc hôm nay không để ngày mai.</span>
      </h1>

      {todos?(
        todos?.map((item, key) => (
          <li className={item.isComplete ? "done" : ""}key={key}>
            <span className="label">{item.name}</span>
            <div className="actions">
              <button className="btn-picto" type="button">
                <i className="fas fa-edit" />
              </button>
              <button className="btn-picto" type="button" aria-label="Delete" title="Delete">
                <i className="fas fa-trash" />
              </button>
            </div>
          </li>))
          ):(
           <p>Danh sách nhiệm vụ trống.</p>)
      }


      {/*<li className="done">
        <span className="label">123</span>
        <div className="actions">
          <button className="btn-picto" type="button">
            <i className="fas fa-edit" />
          </button>
          <button className="btn-picto" type="button" aria-label="Delete" title="Delete">
            <i className="fas fa-trash" />
          </button>
        </div>
      </li>
      <li>
        <span className="label">123</span>
        <div className="actions">
          <button className="btn-picto" type="button">
            <i className="fas fa-user-edit" />
          </button>
          <button className="btn-picto" type="button" aria-label="Delete" title="Delete">
            <i className="fas fa-trash" />
          </button>
        </div>
      </li> */}
     
      <form onSubmit={AddOrEditTodo}>
        <label >Thêm nhiệm vụ mới</label>
        <input type="text" name="name" id="name" />
        <input type="text" name="id" id="name" />
        <button type="submit">Thêm mới</button>
      </form>
    </main>
  )
}
export default Todos;