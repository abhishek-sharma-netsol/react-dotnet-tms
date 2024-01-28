import { useState } from 'react';
import { Input, Button } from './index'
import { useDispatch } from 'react-redux';
import { login as loginReducer } from '../store/auth-slice'
import authService from '../services/auth.service';
import { useNavigate } from 'react-router-dom';

const Login = () => {
    const [username, setUsername] = useState('');
    const [password, setPassword] = useState('');
    const dispatch = useDispatch();
    const navigate = useNavigate();

    const handleLogin = async () => {
        try {
            const response = await authService.login({ username, password });
            if (response) {
                dispatch(loginReducer(response.data));
                navigate("/dashboard");
            }
        } catch (error) {
            console.log(error);
        }
    };

    return (
        <div className="flex items-center justify-center h-screen">
            <div className="bg-white shadow-md rounded px-8 pt-6 pb-8">
                <h2 className="text-2xl font-bold mb-6 text-center">Login</h2>
                <Input
                    label="Username:"
                    type="text"
                    placeholder="Enter your username"
                    value={username}
                    onChange={(e) => setUsername(e.target.value)}
                />
                <Input
                    label="Password:"
                    type="password"
                    placeholder="Enter your password"
                    value={password}
                    onChange={(e) => setPassword(e.target.value)}
                />
                <Button onClick={handleLogin} className="w-full mt-6">
                    Login
                </Button>
            </div>
        </div>
    );
};

export default Login;