import React, {createContext} from 'react'
import {signinRedirect} from '../services/userService'
import {Redirect} from 'react-router-dom'
import {useSelector} from 'react-redux'
import NGSplashScreen from "../@nextgen/core/NGSplashScreen/NGSplashScreen";
// import NGSplashScreen from "../../@nextgen/core/NGSplashScreen/NGSplashScreen";
import logo from "../../pfr-logo.svg";
import NGSuspense from "../@nextgen/core/NGSuspense";
import {memo, useContext} from 'react';
import Header from "../Components/Header";
import Footer from "../Components/Footer";
import NgLogo from "../@nextgen/core/NGLogo/NGLogo";
import NGLogo from "../@nextgen/core/NGLogo/NGLogo";
import ShowCase from "../Components/ShowCase";
import LoginShowCase from "../Components/LoginShowCase";

// import AppContext from '../app/AppContext';
// import { useRoutes } from 'react-router-dom';

function Login() {
    const user = useSelector(state => state.auth.user)
    const AppContext = createContext({});
    const appContext = useContext(AppContext);
    const {routes} = appContext;

    function login() {
        signinRedirect()
    }

    return (

        (user) ?
            (<Redirect to={'/'}/>)
            :
            (
                <div>
                    <Header/>
                    <LoginShowCase/>
                    {/*<ShowCase/>*/}
                    {/*<section>*/}
                    {/*    <div*/}
                    {/*        className="flex xl:px-40  xl:pb-20 flex-col justify-center bg-gradient-to-t from-gray-50 bg-gray-100 mb-1">*/}

                    {/*        <section className="flex justify-center xl:mx-20 m-30">*/}
                    {/*            <div>*/}

                    {/*                /!*<NGSuspense></NGSuspense>*!/*/}
                    {/*                /!*<NGSplashScreen logo={logo} />*!/*/}
                    {/*                <div className="flex justify-center">*/}
                    {/*                    <div*/}
                    {/*                        className="flex items-start space-x-6 p-6  bg-white shadow-lg rounded-xl mt-4">*/}
                    {/*                        <div className="flex relative">*/}
                    {/*                            <div*/}
                    {/*                                className="flex flex-col justify-center mb-1">*/}
                    {/*                                <NGLogo logo={logo} />*/}
                    {/*                                <div>*/}
                    {/*                                    «Соо́бщество», известный также как «Одноку́рсники» (англ.*/}
                    {/*                                    Community) —*/}
                    {/*                                    американский комедийный телесериал, созданный Дэном Хармоном и*/}
                    {/*                                    повествующий о группе студентов, проходящих обучение в*/}
                    {/*                                    общественном*/}
                    {/*                                    колледже «Гриндейл» в штате Колорадо. При создании сериала*/}
                    {/*                                    Хармон*/}
                    {/*                                    вдохновлялся собственным опытом обучения в реально существующем*/}
                    {/*                                    колледже*/}
                    {/*                                    в городе Гриндейл, Калифорния. Премьера шоу состоялась 17*/}
                    {/*                                    сентября 2009*/}
                    {/*                                    года на телеканале NBC. Сериал рассказывает о студенческом*/}
                    {/*                                    сообществе,*/}
                    {/*                                    которое состоит из школьных неудачников, недавно разведённых*/}
                    {/*                                    домохозяек*/}
                    {/*                                    и пожилых людей, старающихся сохранить трезвый ум. В телесериале*/}
                    {/*                                    присутствует множество ссылок на поп-культуру, часто*/}
                    {/*                                    пародируется кино и*/}
                    {/*                                    телевидение, а также обыгрываются клише и тропы[1][2].*/}
                    {/*                                </div>*/}
                    {/*                                <br/>*/}
                    {/*                                <div className="flex justify-center">*/}
                    {/*                                    <button*/}
                    {/*                                        className="bg-gradient-to-br text-white from-purple-500 to-indigo-500  shadow-sm rounded-lg p-2"*/}
                    {/*                                        onClick={() => login()}>Войти в систему*/}
                    {/*                                    </button>*/}
                    {/*                                </div>*/}
                    {/*                            </div>*/}
                    {/*                        </div>*/}
                    {/*                    </div>*/}
                    {/*                </div>*/}

                    {/*            </div>*/}
                    {/*        </section>*/}
                    {/*    </div>*/}
                    {/*</section>*/}
                    <Footer/>
                </div>
            )


    )
}

export default Login
