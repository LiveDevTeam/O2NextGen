import React, {useState} from 'react';
import {FaGlobe} from "react-icons/all";
import {Link} from "react-router-dom";

const Footer = () => {
    const [links, setLinks] = useState('')
    return (
            <div className="border-t-2  py-8 px-8 pb-4 md:flex item-center justify-between xl:mx-20 ">
                <div className="flex flex-wrap item-center text-gray-700">
                    <FaGlobe className="mr-3" />
                    <p className="text-sm">Русский (Россия)</p>
                </div>

                <div>
                    <ul className="flex flex-wrap text-sm mt-4 text-gray-700">
                        <li className="mr-4"><Link to="/sitemap">Карта сайта</Link></li>
                        <li className="mr-4"><a href="https://o2bionics.com">Контакты O2 Bionics LLC</a></li>
                        <li className="mr-4"><Link to="/privacystatement">Конфедециальность</Link></li>
                        <li className="mr-4"><Link to="/terms-of-use">Условия использования</Link></li>
                        <li className="mr-4"><Link to="/trademarks">Товарные знаки</Link></li>
                        {/*<li className="mr-4">Safety &amp; eco</li>*/}
                        <li className="mr-4"><Link to="/about-advertising">О нашей рекламе</Link></li>
                        <li><a href="https://o2bionics.com"> &copy;O2 Bionics LLC {(new Date().getFullYear())}</a></li>
                    </ul>
                </div>
            </div>
    );
};

export default Footer;