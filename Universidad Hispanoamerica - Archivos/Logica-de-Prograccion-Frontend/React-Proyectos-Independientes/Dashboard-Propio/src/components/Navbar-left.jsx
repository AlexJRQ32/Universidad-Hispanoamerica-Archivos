import './Navbar-left.css';

function NavbarLeft(){
    return(
        <nav className="nav-left">
            <ul>
                <li>
                    <a href="#">
                        <i className="fa-solid fa-cart-shopping">
                            <span>Orders</span>
                        </i>
                    </a>
                </li>
                <li>
                    <a href="#">
                        <i className="fa-solid fa-money-bill-trend-up">
                            <span>Finances</span>
                        </i>
                    </a>
                </li>
                <li>
                    <a href="#">
                        <i className="fa-solid fa-chart-line">
                            <span>Analitycs</span>
                        </i>
                    </a>
                </li>
                <li>
                    <a href="#">
                        <i className="fa-solid fa-boxes-stacked">
                            <span>Inventory</span>
                        </i>
                    </a>
                </li>
                <li>
                    <a href="#">
                        <i className="fa-solid fa-calendar-days">
                            <span>Schedule</span>
                        </i>
                    </a>
                </li>
                <li>
                    <a href="#">
                        <i className="fa-solid fa-gear">
                            <span>Settings</span>
                        </i>
                    </a>
                </li>
            </ul>
            <section className='usuario'>
                <div className="usuario-info">
                    <strong>Username</strong>
                    <p>Admin</p>
                </div>
                <a href="">
                    <i className='fa-solid fa-right-from-bracket'> Logout</i>
                </a>
            </section>
        </nav>
    )
}

export default NavbarLeft;