import axios from "axios";

class AuthService {
    apiUrl = `${import.meta.env.VITE_API_URL}/auth`;

    async login({ username, password }) {
        const request = { Username: username, Password: password };
        const response = await axios.post(`${this.apiUrl}/login`, request);

        return response.data;
    }

    async signup({ username, email, passwd }) {
        const request = { Username: username, Email: email, Password: passwd };
        const response = await axios.post(`${this.apiUrl}/register`, request);

        return response.data;
    }
}

export default new AuthService();