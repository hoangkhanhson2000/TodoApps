
import axiosClient from './axiosClient'
const END_POINT = {
    TODOS: "todos"
}
export const getTodoAPI = () => {
    return axiosClient.get(`${END_POINT.TODOS}`);
}

export const deleteTodoAPI = (id) => {
    return axiosClient.delete(`${END_POINT.TODOS}/${id}`);
}
export const AddTodoAPI = (todo) => {
    return axiosClient.post(`${END_POINT.TODOS}`, todo);
}
export const EditTodoAPI = (todo) => {
    return axiosClient.put(`${END_POINT.TODOS}`, todo);
}