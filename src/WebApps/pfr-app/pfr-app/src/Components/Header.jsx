import {FaBars, FaSearch, FaShoppingCart, FaUserPlus} from 'react-icons/fa'
import {Link} from "react-router-dom";
import logo from "../pfr-logo.svg";
import React from "react";

const Header = () => {
    return (
        <header className="flex items-center justify-between py-2 px-4">
            <div className="flex flex-col justify-between items-center pt-2">
                <div className="flex items-left justify-start">
                <img src={logo} className="logo" alt="PF_R Community"  style={{ height: 50, width: 50 }}/>
                <p className="ml-2 text-2xl text-gray-700 uppercase font-bold">#PF_R Community</p></div>

            </div>
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
            <div className="flex-col justify-end items-center">
                <ul className="flex justify-end items-center mt-2" >
                    <li className="px-2 text-gray-500 cursor-pointer uppercase font-bold">
                        <Link to="/"> Home</Link>
                    </li>
                    <li className="px-2 text-gray-500 cursor-pointer uppercase font-bold">
                        <Link to="/specialists"> Specialists</Link>
                    </li>
                    <li className="px-2 text-gray-500 cursor-pointer uppercase font-bold">
                        <Link to="/about"> About</Link>
                    </li>
                    <li className="px-2 text-gray-500 cursor-pointer uppercase font-bold">
                        <Link to="/about"> Community</Link>
                    </li>
                    <li className="px-2 text-gray-500 cursor-pointer uppercase font-bold">
                        <Link to="/about"> Login</Link>
                    </li>
                    <li className="px-2 text-gray-500 cursor-pointer uppercase font-bold">
                        <Link to="/about"> Sign up</Link>
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