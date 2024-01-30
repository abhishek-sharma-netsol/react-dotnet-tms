import axios from "axios";

class TasksService {
    apiUrl = `${import.meta.env.VITE_API_URL}/tasks`;

    async getTasksByUserId(id) {
        id = +id;
        const response = await axios.get(`${this.apiUrl}/user/${id}`);
        return response.data;
    }

    async deleteTask(id) {
        id = +id;
        const response = await axios.delete(`${this.apiUrl}/delete/${id}`);
        return response.data;
    }
}

export default new TasksService();