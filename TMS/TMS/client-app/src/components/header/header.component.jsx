import { useNavigate } from 'react-router-dom'; // Assuming you're using React Router for navigation
import Container from '../container.component';
import Logout from './logout.component'

const Header = () => {
    const isAuthenticated = localStorage.getItem("id");
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
            active: isAuthenticated,
        },
        {
            name: 'Login',
            slug: '/login',
            active: !isAuthenticated,
        },
        {
            name: 'Signup',
            slug: '/signup',
            active: !isAuthenticated
        },
    ];

    const activeNavItems = navItems.filter(n => n.active);

    return (
        <header className="bg-gray-800 text-white p-4">
            <Container>
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
                        {isAuthenticated && <Logout />}
                    </div>
                </div>
            </Container>
        </header>
    );
};

export default Header;
