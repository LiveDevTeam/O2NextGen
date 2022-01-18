import React from 'react';

const SpecialistItem = (props) => {
    return (
        <div className="flex items-start space-x-6 p-6  bg-white shadow-lg rounded-xl mt-4">
            <div className="flex-none w-48 relative">
                <img width="auto" height="300" src={props.specialist.avatar}
                     className="flex-none rounded-md bg-slate-100"></img>
                <div className="text-center m-2">
                    <path
                        d="M13.415.001C6.07 5.185.887 13.681.887 23.041c0 7.632 4.608 12.096 9.936 12.096 5.04 0 8.784-4.032 8.784-8.784 0-4.752-3.312-8.208-7.632-8.208-.864 0-2.016.144-2.304.288.72-4.896 5.328-10.656 9.936-13.536L13.415.001zm24.768 0c-7.2 5.184-12.384 13.68-12.384 23.04 0 7.632 4.608 12.096 9.936 12.096 4.896 0 8.784-4.032 8.784-8.784 0-4.752-3.456-8.208-7.776-8.208-.864 0-1.872.144-2.16.288.72-4.896 5.184-10.656 9.792-13.536L38.183.001z">
                    </path>

                    <button
                        className="bg-gradient-to-br from-orange-400 to-pink-600 rounded-b-xl p-4 px-6 font-semibold text-white active:to-pink-400">
                        Book session
                    </button>

                </div>
                <div className="mt-4 text-center">
                    <ul>
                        <li className="text-3xl text-orange-300">
                           * * * * *</li>
                    </ul>
                    <strong>Rating</strong>
                    <p>{props.specialist.ratings.sessions} sessions</p>
                </div>

            </div>
            <div className="flex-col w-1/3">
                <div>
                    <strong className="text-2xl uppercase">{props.specialist.fio}</strong>
                    {
                        props.specialist.status == 'online' ?
                            <p
                                className="text-green-500 font-bold uppercase">
                                * {props.specialist.status} *

                            </p>
                            :
                            <p
                                className="text-orange-300 font-bold uppercase">
                                * {props.specialist.status} *

                            </p>
                    }
                    <p className="text-gray-400 mt-2">{props.specialist.intro}</p>
                </div>
                <div className="mt-4">
                    <strong>
                        Languages
                    </strong>
                    <ul className=" pl-4">
                        <li>Germany: <strong className="text-pink-300">|||</strong></li>
                        <li>English: <strong className="text-green-400">||||||</strong></li>
                        <li>Russian: <strong className="text-cyan-600">|||||||||||</strong></li>
                    </ul>
                </div>
               <div className="mt-4">
                    <strong>Tags</strong>

                    <ul className="flex justify-center items-center my-4">
                        <li className="px-2 text-blue-900 cursor-pointer"><a href="#">#pf_r</a></li>
                        <li className="px-2 text-blue-900 cursor-pointer"><a href="#">#hypnosis</a></li>
                        <li className="px-2 text-blue-900 cursor-pointer"><a href="#">#pf_r_dub</a></li>
                        <li className="px-2 text-blue-900 cursor-pointer"><a href="#">#pf_r_base</a></li>
                        <li></li></ul>
                </div>
                <div className="mt-4">
                    <strong>Rates</strong>
                    <ul className="flex justify-center items-center my-4">
                        <li className="text-gray-600 px-4">Trial (30 min): <strong>20 USD</strong></li>
                        <li className="px-4">Hourly Rate from: <strong>30 USD</strong></li>
                    </ul>
                </div>

                <div className="mt-4">
                    <button
                        className="bg-gradient-to-br from-green-400 to-cyan-500 rounded-t-xl p-4 px-6 font-semibold text-white active:to-pink-400">
                        Send Message
                    </button>
                    <button
                        className="bg-gradient-to-br from-purple-500 to-indigo-500 rounded-t-xl  p-4 px-6 font-semibold text-white active:to-pink-400">
                        Add Favorite
                    </button>
                </div>
            </div>
            <div className="flex-col">
                <ul className="flex justify-center items-center my-4">
                    <li className="cursor-pointer py-2 px-4 text-cyan-600 font-bold border-b-8 ">
                        Video
                    </li>
                    <li className="cursor-pointer py-2 px-4 text-green-400  border-b-8">Intro</li>
                    <li className="cursor-pointer py-2 px-4 text-gray-500 border-b-8">Calendar</li>
                </ul>

                <div className="bg-white p-2 text-center mx-auto border">
                    <iframe width="600" height="340"  src="https://www.youtube.com/embed/Ks8csGiEUS8"
                            title="YouTube video player" frameBorder="0"
                            allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture"
                            allowFullScreen></iframe>
                </div>
            </div>
            {/*<div className="certificate__content">*/}

            {/*    <div className="p-2">*/}
            {/*        <img width="auto" height="300" src={props.specialist.avatar} className=" rounded-xl"></img>*/}

            {/*    </div>*/}
            {/*    <div className="px-4"><strong>{props.specialist.fio}</strong></div>*/}
            {/*    <div className="px-4 py-2 pb-6">{props.specialist.specialnost}</div>*/}
            {/*</div>*/}
            {/*<div className="flex m-2 bg-white border-2">*/}
            {/*    <div className="certificate__content">*/}

            {/*        <div>*/}
            {/*            <img width="auto" height="200" src="https://images.unsplash.com/photo-1522228115018-d838bcce5c3a?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=300&q=60"></img>*/}
            {/*            Практикующий психолог*/}
            {/*        </div>*/}
            {/*        <strong>May Lam</strong>*/}
            {/*        <div className="post__btn">*/}
            {/*            <button>Удалить</button>*/}
            {/*        </div>*/}
            {/*    </div>*/}
            {/*</div>*/}
            {/*<div className="flex m-2 bg-white border-2">*/}
            {/*    <div className="certificate__content">*/}

            {/*        <div>*/}
            {/*            <img width="auto" height="200" src="https://images.unsplash.com/photo-1522228115018-d838bcce5c3a?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=300&q=60"></img>*/}
            {/*            Практикующий психолог*/}
            {/*        </div>*/}
            {/*        <strong>May Lam</strong>*/}
            {/*        <div className="post__btn">*/}
            {/*            <button>Удалить</button>*/}
            {/*        </div>*/}
            {/*    </div>*/}
            {/*</div>*/}
            {/*<div className="flex m-2 bg-white border-2">*/}
            {/*    <div className="certificate__content">*/}

            {/*        <div>*/}
            {/*            <img width="auto" height="200" src="https://images.unsplash.com/photo-1522228115018-d838bcce5c3a?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=300&q=60"></img>*/}
            {/*            Практикующий психолог*/}
            {/*        </div>*/}
            {/*        <strong>May Lam</strong>*/}
            {/*        <div className="post__btn">*/}
            {/*            <button>Удалить</button>*/}
            {/*        </div>*/}
            {/*    </div>*/}
            {/*</div>*/}
        </div>
    );
};

export default SpecialistItem;