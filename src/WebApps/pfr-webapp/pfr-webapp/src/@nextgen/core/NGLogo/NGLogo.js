import React, { useState } from 'react';
import Snowfall from "react-snowfall";

const NGLogo = (props) => {
    return (
        <div>
            <section className="flex justify-center xl:mx-10 mb-10">

                <div className="relative">
                </div>

                <section className="hero xl:mx-20">
                    <div className="flex py-6 flex-col justify-center mt-20 items-center">
                        <img src={props.logo} className="logo" alt="logo" />
                    </div>
                    {" "}
                    <div className="text-center p-6">
                        <h2 className="text-gray-800 text-3xl mt-1 mb-1 font-semibold ">
                            #PF_R СООБЩЕСТВО
                        </h2>
                    </div>
                    <div className="text-gray-600 text-center mt-1 text-xl mb-4">
                        Добро пожаловать в сообщество...
                    </div>

                </section>
            </section>
        </div>
    )
}

export default NGLogo;
