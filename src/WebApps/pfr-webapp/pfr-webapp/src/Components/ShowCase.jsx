import React from 'react';

const Showcase = () => {
    return (
        <>
            <section className="showcase">

                <div className="overlay flex flex-col items-end justify-center mr-40">
                    <div className="overlay flex flex-col items-center justify-center">
                        <div>
                            <h1 className="text-center text-gray-700 uppercase font-bold text-4xl mb-3 lg:text-5xl">
                                #PF_R Сообщество
                            </h1>
                            <p className="mb-5 lg:text-2xl text-gray-600">
                                Присоединяйся к сообществу и стань успешным специалистом.
                            </p>
                        </div>

                        <div className="flex flex-col md:flex-row mt-10">
                            <button className="text-white bg-yellow-400 rounded-lg p-2 px-4 mx-4">
                                Для интереса
                            </button>
                            <button className="text-white bg-green-400 rounded-lg p-2 px-4 mx-4">
                                Для здоровья
                            </button>
                            <button className="text-white bg-indigo-500 rounded-lg p-2 px-4 mx-4">
                                Для бизнеса
                            </button>
                            <button className="text-white bg-purple-600 shadow-sm rounded-lg p-2 px-4 mx-4">
                                Для образования
                            </button>
                            <button className="text-white bg-pink-500  shadow-sm rounded-lg p-2 px-4 mx-4">
                                Для личных целей
                            </button>
                        </div>
                    </div>

                </div>
            </section>
        </>
    )
}

export default Showcase