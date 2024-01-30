import { createAsyncThunk } from "@reduxjs/toolkit";
import { userService } from '../../services/auth.service';

export const login = createAsyncThunk('login', async ({ username, password }, thunk) => {
    try {
        const response = await userService.login({ username, password });
        return response.data;
    } catch (err) {
        thunk.rejectWithValue(err.message);
    }
})