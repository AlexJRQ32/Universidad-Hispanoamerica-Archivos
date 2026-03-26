import './Navbar.css';

function Navbar(){
    return(
        <nav className="nav-top">
            <h2>My Dashboard</h2>
            <ul>
                <li>
                    <a href="#">
                        <i className="fa-solid fa-house">
                            <span>Home</span>
                        </i>
                    </a>
                </li>
                <li>
                    <a href="#">
                        <i className="fa-solid fa-users">
                            <span>About Us</span>
                        </i>
                    </a>
                </li>
                <li>
                    <a href="#">
                        <i className="fa-solid fa-shield-halved">
                            <span>Privacy</span>
                        </i>
                    </a>
                </li>
                <li className="login">
                    <a href="#">
                        <i className='fa-solid fa-user'>
                            <span>Login</span>
                        </i>
                    </a>
                </li>
            </ul>
        </nav>
    )
}

export default Navbar;