import { createAsyncThunk } from "@reduxjs/toolkit";
import tasksService from "../../services/tasks.service";

export const fetchTasks = createAsyncThunk('fetchTasks', async (id, thunk) => {
    try {
        const response = await tasksService.getTasksByUserId(id);
        return response.data;
    } catch (err) {
        thunk.rejectWithValue(err.message);
    }
});