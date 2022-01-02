import {FaBars, FaSearch, FaShoppingCart, FaUserPlus} from 'react-icons/fa'
import {Link} from "react-router-dom";
import logo from "../pfr-logo.svg";

const Header = () => {
    return (
        <header className="flex items-center justify-between py-3">
            {/*<div className="menu-btn flex">*/}
            {/*    <div className="mx-4">*/}
            {/*        <FaBars />*/}
            {/*    </div>*/}
            {/*    <div>*/}
            {/*        <FaSearch />*/}
            {/*    </div>*/}
            {/*</div>*/}

            {/*<div className="logo">*/}
            {/*    <div>*/}
            {/*        <Link to="/">*/}
            {/*            <img src={logo} alt="PF_R Community" />*/}
            {/*        </Link>*/}
            {/*    </div>*/}

            {/*    <ul>*/}
            {/*        <li>*/}
            {/*            <Link to="/microsoft-365">Microsoft 365</Link>*/}
            {/*        </li>*/}
            {/*        <li>*/}
            {/*            <Link to="/office">Office</Link>*/}
            {/*        </li>*/}
            {/*        <li>Windows</li>*/}
            {/*        <li>Surface</li>*/}
            {/*        <li>Xbox</li>*/}
            {/*        <li>Deals</li>*/}
            {/*        <li>Support</li>*/}
            {/*    </ul>*/}
            {/*</div>*/}
            <div>
                <ul>
                    <li>
                        <Link to="/"> Home</Link>
                    </li>
                    <li>
                        <Link to="/specialists"> Specialists</Link>
                    </li>
                    <li>
                        <Link to="/about"> About</Link>
                    </li>
                </ul>
            </div>
            {/*<div className="cart flex">*/}
            {/*    <div>*/}
            {/*        <FaShoppingCart />*/}
            {/*    </div>*/}
            {/*    <div className="mx-4">*/}
            {/*        <FaUserPlus />*/}
            {/*    </div>*/}
            {/*</div>*/}

            {/*<div className="sign-in">*/}
            {/*    <ul>*/}
            {/*        <li>All Microsoft</li>*/}
            {/*        <li>Search</li>*/}
            {/*        <li>Cart</li>*/}
            {/*        <li>Sign In</li>*/}
            {/*    </ul>*/}
            {/*</div>*/}
        </header>
    )
}

export default Header