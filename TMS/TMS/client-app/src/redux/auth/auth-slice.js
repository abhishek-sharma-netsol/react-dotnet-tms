import { createSlice } from "@reduxjs/toolkit"

const initialState = {
    status: localStorage.getItem('status'),
    token: localStorage.getItem('token'),
    user: {
        username: localStorage.getItem('username'),
        id: localStorage.getItem('id'),
    }
}

const authSlice = createSlice({
    name: 'auth',
    initialState,
    reducers: {
        login: (state, actions) => {
            state.status = true;
            state.token = actions.payload.token;
            state.user = {
                username: actions.payload.username,
                id: actions.payload.id,
            }
            state.error = null;

            localStorage.setItem('status', true);
            localStorage.setItem('token', actions.payload.token);
            localStorage.setItem('username', actions.payload.username);
            localStorage.setItem('id', actions.payload.id);
        },

        logout: (state) => {
            state.status = false;
            state.token = null;
            state.user = null;

            localStorage.clear();
        }

    },
});

export const { login, logout } = authSlice.actions;
export default authSlice.reducer;