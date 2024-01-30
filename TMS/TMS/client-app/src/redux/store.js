import { configureStore } from "@reduxjs/toolkit";
import authSlice from './auth/auth-slice';
import tasksSlice from "./task/tasks-slice";

const store = configureStore({
    reducer: {
        auth: authSlice,
        task: tasksSlice
    }
});

export default store;