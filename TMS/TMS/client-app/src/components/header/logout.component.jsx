import { useDispatch } from "react-redux"
import { logout as logoutReducer } from '../../store/auth-slice';

const Logout = () => {
    const dispatch = useDispatch();

    const handleClick = () => {
        dispatch(logoutReducer({}));
    }

    return (
        <button className={`text-lg font-bold text-blue-300`} onClick={() => handleClick()}>
            Logout
        </button>
    )
}

export default Logout;