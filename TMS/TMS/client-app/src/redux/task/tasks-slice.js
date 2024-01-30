import { createSlice } from "@reduxjs/toolkit"
import { fetchTasks } from "./task-actions";

const initialState = {
    tasks: [],
    loading: false,
    error: null,
};

const tasksSlice = createSlice({
    name: 'task',
    initialState,
    reducers: {
    },
    extraReducers: (builder) => {
        builder
            .addCase(fetchTasks.pending, (state) => {
                state.loading = true;
                state.error = null;
            })
            .addCase(fetchTasks.fulfilled, (state, action) => {
                state.loading = false;
                state.tasks = action.payload;
            })
            .addCase(fetchTasks.rejected, (state, action) => {
                state.loading = false;
                state.error = action.payload;
            });
    },
});


export default tasksSlice.reducer;