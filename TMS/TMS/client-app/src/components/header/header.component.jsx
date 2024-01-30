import { useNavigate } from 'react-router-dom';
import { Logout } from './index'

const Header = () => {
    const authStatus = localStorage.getItem("status");
    const navigate = useNavigate();

    const navItems = [
        {
            name: 'Home',
            slug: '/',
            active: true,
        },
        {
            name: 'Dashboard',
            slug: '/dashboard',
            active: authStatus,
        },
        {
            name: 'Login',
            slug: '/login',
            active: !authStatus,
        },
        {
            name: 'Signup',
            slug: '/signup',
            active: !authStatus
        },
    ];

    const activeNavItems = navItems.filter(n => n.active);

    return (
        <header className="bg-gray-500 text-white p-4 mb-4">
            <div className="flex justify-between items-center">
                <div className="flex space-x-4 justify-center items-center">
                    {activeNavItems.map((item, index) => (
                        <button key={index} to={item.slug}
                            className={`text-lg font-bold ${item.active ? 'text-blue-300' : ''}`}
                            onClick={() => navigate(item.slug)}
                        >
                            {item.name}
                        </button>
                    ))}
                    {authStatus && <Logout />}
                </div>
            </div>
        </header >
    );
};

export default Header;
