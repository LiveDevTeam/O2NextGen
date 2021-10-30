import React, {useState} from 'react';
import {FaGlobe} from "react-icons/all";
import footer from "../Data/footer";

const Footer = () => {
    const [links, setLinks] = useState('')
    return (
        <div>
            {/* <footer className="bg-gray-500 px-8 py-4 md:grid md:grid-cols-2 xl:grid-cols-6 xl:mx-20">
                {links.map((link) => {
                    const { id, title, hrefs } = link
                    return (
                        <div key={id}>
                            <div className="mb-10">
                                <h4 className="font-semibold text-white">{title}</h4>

                                {hrefs.map((hr) => {
                                    return (
                                        <li key={hr} className="text-gray-200 text-sm my-2 cursor-pointer hover:underline hover:cursor-pointer">
                                            {hr}
                                        </li>
                                    )
                                })}
                            </div>
                        </div>
                    )
                })}
            </footer> */}

            <div className="border-t-2  py-8 px-8 pb-4 md:flex item-center justify-between xl:mx-20 ">
                <div className="flex flex-wrap item-center text-gray-700">
                    <FaGlobe className="mr-3" />
                    <p className="text-sm">Русский (Россия)</p>
                </div>

                <div>
                    <ul className="flex flex-wrap text-sm mt-4 text-gray-700">
                        <li className="mr-4">Карта сайта</li>
                        <li className="mr-4">Контакты O2 Bionics LLC</li>
                        <li className="mr-4">Конфедециальность</li>
                        <li className="mr-4">Условия использования</li>
                        <li className="mr-4">Товарные знаки</li>
                        {/*<li className="mr-4">Safety &amp; eco</li>*/}
                        <li className="mr-4">О нашей рекламе</li>
                        <li>&copy;O2 Bionics LLC {(new Date().getFullYear())}</li>
                    </ul>
                </div>
            </div>
        </div>
    );
};

export default Footer;