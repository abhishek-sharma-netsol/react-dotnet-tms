import { useDispatch } from "react-redux"
import { logout as logoutReducer } from '../../redux/auth/auth-slice.js';
import { useNavigate } from "react-router-dom";

const Logout = () => {
    const dispatch = useDispatch();
    const navigate = useNavigate();

    const handleClick = () => {
        dispatch(logoutReducer({}));
        navigate("/");
    }

    return (
        <button className={`text-lg font-bold text-blue-300`} onClick={() => handleClick()}>
            Logout
        </button>
    )
}

export default Logout;