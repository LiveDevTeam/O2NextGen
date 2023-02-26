import React, {createContext, useContext} from 'react';
import {useSelector} from "react-redux";
import {signinRedirect} from "../services/userService";

function LoginShowCase(props) {
    const user = useSelector(state => state.auth.user)
    const AppContext = createContext({});
    const appContext = useContext(AppContext);
    const {routes} = appContext;

    function login() {
        signinRedirect()
    }

    return (
        <section className="showcase2">

            <div className="overlay flex flex-col items-end justify-center mr-40">
                <div className="overlay flex flex-col items-center justify-center">
                    <div>
                        <h1 className="text-center text-gray-700 uppercase font-bold text-4xl mb-3 lg:text-5xl">
                            #PF_R Сообщество
                        </h1>
                        <p className="mb-5 lg:text-2xl text-gray-600">
                            Присоединяйся к сообществу и стань успешным специалистом.
                        </p>
                        <p className="mb-5 text-gray-600">
                            Чтобы начать работу в сообществе вам необходимо пройти авторизацию.
                        </p>
                        <p className="mb-5 flex font-bold text-gray-600 justify-end">
                            Регистрация в системе до июля 2023 года приостановлена.
                        </p>
                    </div>

                    <div className="flex flex-col md:flex-row mt-10">
                        <div className="flex justify-center">
                            <button
                                className="bg-gradient-to-br text-white from-purple-500 to-indigo-500  shadow-sm rounded-lg p-2"
                                onClick={() => login()}>Войти в систему
                            </button>
                        </div>
                        <button className="text-white bg-pink-500  shadow-sm rounded-lg p-2 px-4 mx-4">
                            Регистрироваться в сообществе
                        </button>
                    </div>
                </div>

            </div>
        </section>
    );
}

export default LoginShowCase;