
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
export const AddOrEditTodoAPI = (todo) => {
    return axiosClient.post(`${END_POINT.TODOS}`, todo);
}