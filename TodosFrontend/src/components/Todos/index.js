import { useEffect, useRef, useState } from "react";
import { AddTodoAPI, deleteTodoAPI, EditTodoAPI, getTodoAPI } from "../../api/todos";
import "./index.css"

const Todos = () => {
  const [todos, setTodos] = useState([]);
  const [textBtn, setTextBtn] = useState("Them moi")
  const todoRef = useRef([]);

  //alert(process.env.REACT_APP_URL_API);
  useEffect(() => {
    fetchData();
  }, []);
  const fetchData = async () => {
    setTodos(await getTodoAPI());
  }
  const deleteTodo =async(id)=>
  {
    if (window.confirm("Nhiem vu khong the Hoan Tac, Ban co chac chan Xoa khong?")){
      await deleteTodoAPI(id);
      window.location.reload(); 
    }

  }
  const AddOrEditTodo = async (event) => {
    event.preventDefault();
    const val = event.target[0].value;
    const id = event.target[1].value;


    if (id) {
      // update
      await EditTodoAPI({
        name: val,
        id: id
      });
      todoRef.current[id].className = "fas fa-edit";
    }
    else {
      //new
      await AddTodoAPI({
        name: val
      });
     
      
     
      setTextBtn("Them Moi");

    }
    fetchData();
    event.target[0].value = "";
    event.target[1].value = null;

  }
  const editTodo = (id) => {
   

    todoRef?.current.forEach((item) => {
      if (item.getAttribute("data-id") && item.getAttribute("data-id") !== String(id)) {
        item.className = "fas fa-edit";
      }
    });

    const iputName = document.getElementById("name");
    const iputId = document.getElementById("id");
    if (todoRef?.current[id].className === "fas fa-edit") {
      todoRef.current[id].className = "fas fa-user-edit";
      setTextBtn("Cap Nhat")
      iputName.value = todoRef.current[id].getAttribute("data-name");
      iputId.value = id; 

    }
    else if (todoRef.current[id].className = "fas fa-user-edit") {
      todoRef.current[id].className = "fas fa-edit";
      setTextBtn("Them Moi")
      iputName.value = "";
      iputId.value = null;

    }
  }
  return (
    <main id="todolist">
      <h1>
        Danh sách
        <span>Việc hôm nay không để ngày mai.</span>
      </h1>

      {todos ? (
        todos?.map((item, key) => (
          <li className={item.isComplete ? "done" : ""} key={key}>
            <span className="label">{item.name}</span>
            <div className="actions">
              <button
                className="btn-picto"
                type="button"
                onClick={() => editTodo(item.id)}
              >
                <i
                  className="fas fa-edit"
                  ref={el => todoRef.current[item.id] = el}
                  data-name={item.name}
                  data-id={item.id} />

              </button>
              <button 
              className="btn-picto" 
              type="button" 
              aria-label="Delete" 
              title="Delete"
              onClick={()=>deleteTodo(item.id)}>
                <i className="fas fa-trash" />
              </button>
            </div>
          </li>))
      ) : (
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
        <input required type="text" name="name" id="name" />
        <input type="text" name="id" id="id" style={{display:"none"}} />
        <button type="submit">{textBtn}</button>
      </form>
    </main>
  )
}
export default Todos;