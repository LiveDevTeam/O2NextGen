import React from 'react';
import Snowfall from "react-snowfall";
import logo from "../pfr-logo.svg";
import Footer from "../Components/Footer";

const Home = () => {
    return (
        <section className="flex justify-center xl:mx-20">

            <div className="relative">
            {/*    <div className="absolute right-0 bottom-1/2 left-0 bg-gradient-to-t from-gray-100 pointer-events-none"*/}
            {/*         style="height:607px;max-height:50vh"></div>*/}
            {/*    <div className="flex overflow-hidden -my-8">*/}
            {/*        <ul className="flex items-center w-full py-8">*/}
            {/*            <li className="px-3 md:px-4 flex-none" style="transform: translateX(1204.14%) translateZ(0px);">*/}
            {/*                <figure className="shadow-lg rounded-xl flex-none w-80 md:w-xl"*/}
            {/*                        style="transform:rotate(-2deg) translateZ(0)">*/}
            {/*                    <blockquote*/}
            {/*                        className="rounded-t-xl bg-white px-6 py-8 md:p-10 text-lg md:text-xl leading-8 md:leading-8 font-semibold text-gray-900">*/}
            {/*                        <svg width="45" height="36" className="mb-5 fill-current text-cyan-100">*/}
            {/*                            <path*/}
            {/*                                d="M13.415.001C6.07 5.185.887 13.681.887 23.041c0 7.632 4.608 12.096 9.936 12.096 5.04 0 8.784-4.032 8.784-8.784 0-4.752-3.312-8.208-7.632-8.208-.864 0-2.016.144-2.304.288.72-4.896 5.328-10.656 9.936-13.536L13.415.001zm24.768 0c-7.2 5.184-12.384 13.68-12.384 23.04 0 7.632 4.608 12.096 9.936 12.096 4.896 0 8.784-4.032 8.784-8.784 0-4.752-3.456-8.208-7.776-8.208-.864 0-1.872.144-2.16.288.72-4.896 5.184-10.656 9.792-13.536L38.183.001z">*/}
            {/*                            </path>*/}
            {/*                        </svg>*/}
            {/*                        <p>I feel like an idiot for not using Tailwind CSS until now.</p>*/}
            {/*                    </blockquote>*/}
            {/*                    <figcaption*/}
            {/*                        className="flex items-center space-x-4 p-6 md:px-10 md:py-6 bg-gradient-to-br rounded-b-xl leading-6 font-semibold text-white from-cyan-400 to-light-blue-500">*/}
            
            {/*                        <div className="flex-auto">Denis Prokhorchik*/}
            {/*                            <br/><span className="text-cyan-100">Remix &amp;*/}
            {/*                                React*/}
            {/*          Training</span>*/}
            {/*                        </div>*/}
            
            {/*                    </figcaption>*/}
            {/*                </figure>*/}
            {/*            </li>*/}
            {/*            <li className="px-3 md:px-4 flex-none"*/}
            {/*                style="transform: translateX(-195.863%) translateZ(0px);">*/}
            {/*                <figure className="shadow-lg rounded-xl flex-none w-80 md:w-xl"*/}
            {/*                        style="transform:rotate(1deg) translateZ(0)">*/}
            {/*                    <blockquote*/}
            {/*                        className="rounded-t-xl bg-white px-6 py-8 md:p-10 text-lg md:text-xl leading-8 md:leading-8 font-semibold text-gray-900">*/}
            {/*                        <svg width="45" height="36" className="mb-5 fill-current text-fuchsia-100">*/}
            {/*                            <path*/}
            {/*                                d="M13.415.001C6.07 5.185.887 13.681.887 23.041c0 7.632 4.608 12.096 9.936 12.096 5.04 0 8.784-4.032 8.784-8.784 0-4.752-3.312-8.208-7.632-8.208-.864 0-2.016.144-2.304.288.72-4.896 5.328-10.656 9.936-13.536L13.415.001zm24.768 0c-7.2 5.184-12.384 13.68-12.384 23.04 0 7.632 4.608 12.096 9.936 12.096 4.896 0 8.784-4.032 8.784-8.784 0-4.752-3.456-8.208-7.776-8.208-.864 0-1.872.144-2.16.288.72-4.896 5.184-10.656 9.792-13.536L38.183.001z">*/}
            {/*                            </path>*/}
            {/*                        </svg>*/}
            {/*                        <p>If I had to recommend a way of getting into programming today, it would be HTML +*/}
            {/*                            CSS with*/}
            {/*                            Tailwind CSS.</p>*/}
            {/*                    </blockquote>*/}
            {/*                    <figcaption*/}
            {/*                        className="flex items-center space-x-4 p-6 md:px-10 md:py-6 bg-gradient-to-br rounded-b-xl leading-6 font-semibold text-white from-fuchsia-500 to-purple-600">*/}
            
            {/*                        <div className="flex-auto">Denis Prokhorchik*/}
            {/*                            <br/><span className="text-fuchsia-100">Vercel</span>*/}
            {/*                        </div>*/}
            
            {/*                    </figcaption>*/}
            {/*                </figure>*/}
            {/*            </li>*/}
            {/*            <li className="px-3 md:px-4 flex-none"*/}
            {/*                style="transform: translateX(-195.863%) translateZ(0px);">*/}
            {/*                <figure className="shadow-lg rounded-xl flex-none w-80 md:w-xl"*/}
            {/*                        style="transform: rotate(-1deg) translateZ(0px);">*/}
            {/*                    <blockquote*/}
            {/*                        className="rounded-t-xl bg-white px-6 py-8 md:p-10 text-lg md:text-xl leading-8 md:leading-8 font-semibold text-gray-900">*/}
            {/*                        <svg width="45" height="36" className="mb-5 fill-current text-orange-100">*/}
            {/*                            <path*/}
            {/*                                d="M13.415.001C6.07 5.185.887 13.681.887 23.041c0 7.632 4.608 12.096 9.936 12.096 5.04 0 8.784-4.032 8.784-8.784 0-4.752-3.312-8.208-7.632-8.208-.864 0-2.016.144-2.304.288.72-4.896 5.328-10.656 9.936-13.536L13.415.001zm24.768 0c-7.2 5.184-12.384 13.68-12.384 23.04 0 7.632 4.608 12.096 9.936 12.096 4.896 0 8.784-4.032 8.784-8.784 0-4.752-3.456-8.208-7.776-8.208-.864 0-1.872.144-2.16.288.72-4.896 5.184-10.656 9.792-13.536L38.183.001z">*/}
            {/*                            </path>*/}
            {/*                        </svg>*/}
            {/*                        <p>Новые функциональные возможности и яркий внешний дизайн.</p>*/}
            {/*                    </blockquote>*/}
            {/*                    <figcaption*/}
            {/*                        className="flex items-center space-x-4 p-6 md:px-10 md:py-6 bg-gradient-to-br rounded-b-xl leading-6 font-semibold text-white from-orange-400 to-pink-600">*/}
            
            {/*                        <div className="flex-auto">Мы сделали редизайн всего приложения<br/><span*/}
            {/*                            className="text-orange-100">Удобный*/}
            {/*          интерфейс</span></div>*/}
            {/*                    </figcaption>*/}
            {/*                </figure>*/}
            {/*            </li>*/}
            {/*            <li className="px-3 md:px-4 flex-none"*/}
            {/*                style="transform: translateX(-195.863%) translateZ(0px);">*/}
            {/*                <figure className="shadow-lg rounded-xl flex-none w-80 md:w-xl"*/}
            {/*                        style="transform:rotate(2deg) translateZ(0)">*/}
            {/*                    <blockquote*/}
            {/*                        className="rounded-t-xl bg-white px-6 py-8 md:p-10 text-lg md:text-xl leading-8 md:leading-8 font-semibold text-gray-900">*/}
            {/*                        <svg width="45" height="36" className="mb-5 fill-current text-green-100">*/}
            {/*                            <path*/}
            {/*                                d="M13.415.001C6.07 5.185.887 13.681.887 23.041c0 7.632 4.608 12.096 9.936 12.096 5.04 0 8.784-4.032 8.784-8.784 0-4.752-3.312-8.208-7.632-8.208-.864 0-2.016.144-2.304.288.72-4.896 5.328-10.656 9.936-13.536L13.415.001zm24.768 0c-7.2 5.184-12.384 13.68-12.384 23.04 0 7.632 4.608 12.096 9.936 12.096 4.896 0 8.784-4.032 8.784-8.784 0-4.752-3.456-8.208-7.776-8.208-.864 0-1.872.144-2.16.288.72-4.896 5.184-10.656 9.792-13.536L38.183.001z">*/}
            {/*                            </path>*/}
            {/*                        </svg>*/}
            {/*                        <p>Доступ через приложение мобильного телефона iOS | Android. А также возможность*/}
            {/*                            доступа через приложение*/}
            {/*                            на компьютере Mac или Windows.</p>*/}
            {/*                    </blockquote>*/}
            {/*                    <figcaption*/}
            {/*                        className="flex items-center space-x-4 p-6 md:px-10 md:py-6 bg-gradient-to-br rounded-b-xl leading-6 font-semibold text-white from-green-400 to-cyan-500">*/}
            
            {/*                        <div className="flex-auto">Скачивайте приложение в магазине приложенией<br/><span*/}
            {/*                            className="text-green-100">*/}
            {/*          Быстрый и удобный способ загрузить приложение*/}
            {/*        </span>*/}
            {/*                        </div>*/}
            
            {/*                    </figcaption>*/}
            {/*                </figure>*/}
            {/*            </li>*/}
            {/*            <li className="px-3 md:px-4 flex-none"*/}
            {/*                style="transform: translateX(-195.863%) translateZ(0px);">*/}
            {/*                <figure className="shadow-lg rounded-xl flex-none w-80 md:w-xl"*/}
            {/*                        style="transform:rotate(-1deg) translateZ(0)">*/}
            {/*                    <blockquote*/}
            {/*                        className="rounded-t-xl bg-white px-6 py-8 md:p-10 text-lg md:text-xl leading-8 md:leading-8 font-semibold text-gray-900">*/}
            {/*                        <svg width="45" height="36" className="mb-5 fill-current text-purple-100">*/}
            {/*                            <path*/}
            {/*                                d="M13.415.001C6.07 5.185.887 13.681.887 23.041c0 7.632 4.608 12.096 9.936 12.096 5.04 0 8.784-4.032 8.784-8.784 0-4.752-3.312-8.208-7.632-8.208-.864 0-2.016.144-2.304.288.72-4.896 5.328-10.656 9.936-13.536L13.415.001zm24.768 0c-7.2 5.184-12.384 13.68-12.384 23.04 0 7.632 4.608 12.096 9.936 12.096 4.896 0 8.784-4.032 8.784-8.784 0-4.752-3.456-8.208-7.776-8.208-.864 0-1.872.144-2.16.288.72-4.896 5.184-10.656 9.792-13.536L38.183.001z">*/}
            {/*                            </path>*/}
            {/*                        </svg>*/}
            {/*                        <p>Простой способ оповещать всех клиентов.</p>*/}
            {/*                    </blockquote>*/}
            {/*                    <figcaption*/}
            {/*                        className="flex items-center space-x-4 p-6 md:px-10 md:py-6 bg-gradient-to-br rounded-b-xl leading-6 font-semibold text-white from-purple-500 to-indigo-500">*/}
            
            {/*                        <div className="flex-auto">Новая система быстрого оповещения<br/><span*/}
            {/*                            className="text-purple-100">*/}
            {/*          Все виды оповещений в одной системе</span></div>*/}
            
            {/*                    </figcaption>*/}
            {/*                </figure>*/}
            {/*            </li>*/}
            {/*            <li className="px-3 md:px-4 flex-none"*/}
            {/*                style="transform: translateX(-195.863%) translateZ(0px);">*/}
            {/*                <figure className="shadow-lg rounded-xl flex-none w-80 md:w-xl"*/}
            {/*                        style="transform:rotate(1deg) translateZ(0)">*/}
            {/*                    <blockquote*/}
            {/*                        className="rounded-t-xl bg-white px-6 py-8 md:p-10 text-lg md:text-xl leading-8 md:leading-8 font-semibold text-gray-900">*/}
            {/*                        <svg width="45" height="36" className="mb-5 fill-current text-orange-100">*/}
            {/*                            <path*/}
            {/*                                d="M13.415.001C6.07 5.185.887 13.681.887 23.041c0 7.632 4.608 12.096 9.936 12.096 5.04 0 8.784-4.032 8.784-8.784 0-4.752-3.312-8.208-7.632-8.208-.864 0-2.016.144-2.304.288.72-4.896 5.328-10.656 9.936-13.536L13.415.001zm24.768 0c-7.2 5.184-12.384 13.68-12.384 23.04 0 7.632 4.608 12.096 9.936 12.096 4.896 0 8.784-4.032 8.784-8.784 0-4.752-3.456-8.208-7.776-8.208-.864 0-1.872.144-2.16.288.72-4.896 5.184-10.656 9.792-13.536L38.183.001z">*/}
            {/*                            </path>*/}
            {/*                        </svg>*/}
            {/*                        <p>Система чатов и видео-конференций.*/}
            {/*                        </p>*/}
            {/*                    </blockquote>*/}
            {/*                    <figcaption*/}
            {/*                        className="flex items-center space-x-4 p-6 md:px-10 md:py-6 bg-gradient-to-br rounded-b-xl leading-6 font-semibold text-white from-yellow-400 to-orange-500">*/}
            
            {/*                        <div className="flex-auto">Система коммуникаций<br/><span*/}
            {/*                            className="text-orange-100">*/}
            {/*          Видео-чат, аудио-чат*/}
            {/*        </span></div>*/}
            
            {/*                    </figcaption>*/}
            {/*                </figure>*/}
            {/*            </li>*/}
            {/*            <li className="px-3 md:px-4 flex-none"*/}
            {/*                style="transform: translateX(-195.863%) translateZ(0px);">*/}
            {/*                <figure className="shadow-lg rounded-xl flex-none w-80 md:w-xl"*/}
            {/*                        style="transform:rotate(-2deg) translateZ(0)">*/}
            {/*                    <blockquote*/}
            {/*                        className="rounded-t-xl bg-white px-6 py-8 md:p-10 text-lg md:text-xl leading-8 md:leading-8 font-semibold text-gray-900">*/}
            {/*                        <svg width="45" height="36" className="mb-5 fill-current text-rose-100">*/}
            {/*                            <path*/}
            {/*                                d="M13.415.001C6.07 5.185.887 13.681.887 23.041c0 7.632 4.608 12.096 9.936 12.096 5.04 0 8.784-4.032 8.784-8.784 0-4.752-3.312-8.208-7.632-8.208-.864 0-2.016.144-2.304.288.72-4.896 5.328-10.656 9.936-13.536L13.415.001zm24.768 0c-7.2 5.184-12.384 13.68-12.384 23.04 0 7.632 4.608 12.096 9.936 12.096 4.896 0 8.784-4.032 8.784-8.784 0-4.752-3.456-8.208-7.776-8.208-.864 0-1.872.144-2.16.288.72-4.896 5.184-10.656 9.792-13.536L38.183.001z">*/}
            {/*                            </path>*/}
            {/*                        </svg>*/}
            {/*                        <p>There’s one thing that sucks about @tailwindcss - once you’ve used it on a*/}
            {/*                            handful of*/}
            {/*                            projects it is a real pain in the ass to write normal CSS again.</p>*/}
            {/*                    </blockquote>*/}
            {/*                    <figcaption*/}
            {/*                        className="flex items-center space-x-4 p-6 md:px-10 md:py-6 bg-gradient-to-br rounded-b-xl leading-6 font-semibold text-white from-pink-500 to-rose-500">*/}
            
            {/*                        <div className="flex-auto">Graeme Houston<br/><span className="text-rose-100">JavaScript*/}
            {/*          Developer</span>*/}
            {/*                        </div>*/}
            {/*                    </figcaption>*/}
            {/*                </figure>*/}
            {/*            </li>*/}
            {/*            <li className="px-3 md:px-4 flex-none"*/}
            {/*                style="transform: translateX(-195.863%) translateZ(0px);">*/}
            {/*                <figure className="shadow-lg rounded-xl flex-none w-80 md:w-xl"*/}
            {/*                        style="transform:rotate(1deg) translateZ(0)">*/}
            {/*                    <blockquote*/}
            {/*                        className="rounded-t-xl bg-white px-6 py-8 md:p-10 text-lg md:text-xl leading-8 md:leading-8 font-semibold text-gray-900">*/}
            {/*                        <svg width="45" height="36" className="mb-5 fill-current text-light-blue-100">*/}
            {/*                            <path*/}
            {/*                                d="M13.415.001C6.07 5.185.887 13.681.887 23.041c0 7.632 4.608 12.096 9.936 12.096 5.04 0 8.784-4.032 8.784-8.784 0-4.752-3.312-8.208-7.632-8.208-.864 0-2.016.144-2.304.288.72-4.896 5.328-10.656 9.936-13.536L13.415.001zm24.768 0c-7.2 5.184-12.384 13.68-12.384 23.04 0 7.632 4.608 12.096 9.936 12.096 4.896 0 8.784-4.032 8.784-8.784 0-4.752-3.456-8.208-7.776-8.208-.864 0-1.872.144-2.16.288.72-4.896 5.184-10.656 9.792-13.536L38.183.001z">*/}
            {/*                            </path>*/}
            {/*                        </svg>*/}
            {/*                        <p>Okay, I’m officially *all* in on the @tailwindcss hype train. Never thought*/}
            {/*                            building websites*/}
            {/*                            could be so ridiculously fast and flexible.</p>*/}
            {/*                    </blockquote>*/}
            {/*                    <figcaption*/}
            {/*                        className="flex items-center space-x-4 p-6 md:px-10 md:py-6 bg-gradient-to-br rounded-b-xl leading-6 font-semibold text-white from-light-blue-400 to-indigo-500">*/}
            
            {/*                        <div className="flex-auto">Aaron Bushnell<br/><span className="text-light-blue-100">Programmer @*/}
            {/*          TrendyMinds</span></div>*/}
            
            {/*                    </figcaption>*/}
            {/*                </figure>*/}
            {/*            </li>*/}
            {/*            <li className="px-3 md:px-4 flex-none"*/}
            {/*                style="transform: translateX(-195.863%) translateZ(0px);">*/}
            {/*                <figure className="shadow-lg rounded-xl flex-none w-80 md:w-xl"*/}
            {/*                        style="transform:rotate(-1deg) translateZ(0)">*/}
            {/*                    <blockquote*/}
            {/*                        className="rounded-t-xl bg-white px-6 py-8 md:p-10 text-lg md:text-xl leading-8 md:leading-8 font-semibold text-gray-900">*/}
            {/*                        <svg width="45" height="36" className="mb-5 fill-current text-cyan-100">*/}
            {/*                            <path*/}
            {/*                                d="M13.415.001C6.07 5.185.887 13.681.887 23.041c0 7.632 4.608 12.096 9.936 12.096 5.04 0 8.784-4.032 8.784-8.784 0-4.752-3.312-8.208-7.632-8.208-.864 0-2.016.144-2.304.288.72-4.896 5.328-10.656 9.936-13.536L13.415.001zm24.768 0c-7.2 5.184-12.384 13.68-12.384 23.04 0 7.632 4.608 12.096 9.936 12.096 4.896 0 8.784-4.032 8.784-8.784 0-4.752-3.456-8.208-7.776-8.208-.864 0-1.872.144-2.16.288.72-4.896 5.184-10.656 9.792-13.536L38.183.001z">*/}
            {/*                            </path>*/}
            {/*                        </svg>*/}
            {/*                        <p>Have been working with CSS for over ten years and Tailwind just makes my life*/}
            {/*                            easier. It is*/}
            {/*                            still CSS and you use flex, grid, etc. but just quicker to write and maintain.*/}
            {/*                        </p>*/}
            {/*                    </blockquote>*/}
            {/*                    <figcaption*/}
            {/*                        className="flex items-center space-x-4 p-6 md:px-10 md:py-6 bg-gradient-to-br rounded-b-xl leading-6 font-semibold text-white from-cyan-400 to-light-blue-500">*/}
            
            {/*                        <div className="flex-auto">Debbie O'Brien<br/><span className="text-cyan-100">Head of*/}
            {/*          Learning @*/}
            {/*          Nuxt.js</span></div>*/}
            {/*                    </figcaption>*/}
            {/*                </figure>*/}
            {/*            </li>*/}
            {/*            <li className="px-3 md:px-4 flex-none"*/}
            {/*                style="transform: translateX(-195.863%) translateZ(0px);">*/}
            {/*                <figure className="shadow-lg rounded-xl flex-none w-80 md:w-xl"*/}
            {/*                        style="transform:rotate(2deg) translateZ(0)">*/}
            {/*                    <blockquote*/}
            {/*                        className="rounded-t-xl bg-white px-6 py-8 md:p-10 text-lg md:text-xl leading-8 md:leading-8 font-semibold text-gray-900">*/}
            {/*                        <svg width="45" height="36" className="mb-5 fill-current text-fuchsia-100">*/}
            {/*                            <path*/}
            {/*                                d="M13.415.001C6.07 5.185.887 13.681.887 23.041c0 7.632 4.608 12.096 9.936 12.096 5.04 0 8.784-4.032 8.784-8.784 0-4.752-3.312-8.208-7.632-8.208-.864 0-2.016.144-2.304.288.72-4.896 5.328-10.656 9.936-13.536L13.415.001zm24.768 0c-7.2 5.184-12.384 13.68-12.384 23.04 0 7.632 4.608 12.096 9.936 12.096 4.896 0 8.784-4.032 8.784-8.784 0-4.752-3.456-8.208-7.776-8.208-.864 0-1.872.144-2.16.288.72-4.896 5.184-10.656 9.792-13.536L38.183.001z">*/}
            {/*                            </path>*/}
            {/*                        </svg>*/}
            {/*                        <p>Okay, @tailwindcss just clicked for me and now I feel like a #!@%&amp;$% idiot.*/}
            {/*                        </p>*/}
            {/*                    </blockquote>*/}
            {/*                    <figcaption*/}
            {/*                        className="flex items-center space-x-4 p-6 md:px-10 md:py-6 bg-gradient-to-br rounded-b-xl leading-6 font-semibold text-white from-fuchsia-500 to-purple-600">*/}
            
            {/*                        <div className="flex-auto">Ken Wheeler<br/><span className="text-fuchsia-100">React*/}
            {/*          Engineer</span></div>*/}
            
            {/*                    </figcaption>*/}
            {/*                </figure>*/}
            {/*            </li>*/}
            {/*            <li className="px-3 md:px-4 flex-none"*/}
            {/*                style="transform: translateX(-195.863%) translateZ(0px);">*/}
            {/*                <figure className="shadow-lg rounded-xl flex-none w-80 md:w-xl"*/}
            {/*                        style="transform:rotate(-1deg) translateZ(0)">*/}
            {/*                    <blockquote*/}
            {/*                        className="rounded-t-xl bg-white px-6 py-8 md:p-10 text-lg md:text-xl leading-8 md:leading-8 font-semibold text-gray-900">*/}
            {/*                        <svg width="45" height="36" className="mb-5 fill-current text-orange-100">*/}
            {/*                            <path*/}
            {/*                                d="M13.415.001C6.07 5.185.887 13.681.887 23.041c0 7.632 4.608 12.096 9.936 12.096 5.04 0 8.784-4.032 8.784-8.784 0-4.752-3.312-8.208-7.632-8.208-.864 0-2.016.144-2.304.288.72-4.896 5.328-10.656 9.936-13.536L13.415.001zm24.768 0c-7.2 5.184-12.384 13.68-12.384 23.04 0 7.632 4.608 12.096 9.936 12.096 4.896 0 8.784-4.032 8.784-8.784 0-4.752-3.456-8.208-7.776-8.208-.864 0-1.872.144-2.16.288.72-4.896 5.184-10.656 9.792-13.536L38.183.001z">*/}
            {/*                            </path>*/}
            {/*                        </svg>*/}
            {/*                        <p>I've been using @tailwindcss the past few months and it's amazing. I already used*/}
            {/*                            some*/}
            {/*                            utility classes before, but going utility-first... this is the way.</p>*/}
            {/*                    </blockquote>*/}
            {/*                    <figcaption*/}
            {/*                        className="flex items-center space-x-4 p-6 md:px-10 md:py-6 bg-gradient-to-br rounded-b-xl leading-6 font-semibold text-white from-orange-400 to-pink-600">*/}
            
            {/*                        <div className="flex-auto">Jad Limcaco<br/><span*/}
            {/*                            className="text-orange-100">Designer</span>*/}
            {/*                        </div>*/}
            {/*                        <cite className="flex"><a*/}
            {/*                            href="https://twitter.com/JadLimcaco/status/1327417021915561984"*/}
            {/*                            className="opacity-50 hover:opacity-75 transition-opacity duration-200"><span*/}
            {/*                            className="sr-only">*/}
            {/*          </span>*/}
            {/*                            <svg width="33" height="32" fill="currentColor">*/}
            {/*                                <path*/}
            {/*                                    d="M32.411 6.584c-1.113.493-2.309.826-3.566.977a6.228 6.228 0 002.73-3.437 12.4 12.4 0 01-3.944 1.506 6.212 6.212 0 00-10.744 4.253c0 .486.056.958.16 1.414a17.638 17.638 0 01-12.802-6.49 6.208 6.208 0 00-.84 3.122 6.212 6.212 0 002.762 5.17 6.197 6.197 0 01-2.813-.777v.08c0 3.01 2.14 5.52 4.983 6.091a6.258 6.258 0 01-2.806.107 6.215 6.215 0 005.803 4.312 12.464 12.464 0 01-7.715 2.66c-.501 0-.996-.03-1.482-.087a17.566 17.566 0 009.52 2.79c11.426 0 17.673-9.463 17.673-17.671 0-.267-.007-.536-.019-.803a12.627 12.627 0 003.098-3.213l.002-.004z">*/}
            {/*                                </path>*/}
            {/*                            </svg>*/}
            {/*                        </a></cite>*/}
            {/*                    </figcaption>*/}
            {/*                </figure>*/}
            {/*            </li>*/}
            {/*            <li className="px-3 md:px-4 flex-none"*/}
            {/*                style="transform: translateX(-195.863%) translateZ(0px);">*/}
            {/*                <figure className="shadow-lg rounded-xl flex-none w-80 md:w-xl"*/}
            {/*                        style="transform:rotate(1deg) translateZ(0)">*/}
            {/*                    <blockquote*/}
            {/*                        className="rounded-t-xl bg-white px-6 py-8 md:p-10 text-lg md:text-xl leading-8 md:leading-8 font-semibold text-gray-900">*/}
            {/*                        <svg width="45" height="36" className="mb-5 fill-current text-green-100">*/}
            {/*                            <path*/}
            {/*                                d="M13.415.001C6.07 5.185.887 13.681.887 23.041c0 7.632 4.608 12.096 9.936 12.096 5.04 0 8.784-4.032 8.784-8.784 0-4.752-3.312-8.208-7.632-8.208-.864 0-2.016.144-2.304.288.72-4.896 5.328-10.656 9.936-13.536L13.415.001zm24.768 0c-7.2 5.184-12.384 13.68-12.384 23.04 0 7.632 4.608 12.096 9.936 12.096 4.896 0 8.784-4.032 8.784-8.784 0-4.752-3.456-8.208-7.776-8.208-.864 0-1.872.144-2.16.288.72-4.896 5.184-10.656 9.792-13.536L38.183.001z">*/}
            {/*                            </path>*/}
            {/*                        </svg>*/}
            {/*                        <p>After finally getting to use @tailwindcss on a real client project in the last*/}
            {/*                            two weeks I*/}
            {/*                            never want to write CSS by hand again. I was a skeptic, but the hype is real.*/}
            {/*                        </p>*/}
            {/*                    </blockquote>*/}
            {/*                    <figcaption*/}
            {/*                        className="flex items-center space-x-4 p-6 md:px-10 md:py-6 bg-gradient-to-br rounded-b-xl leading-6 font-semibold text-white from-green-400 to-cyan-500">*/}
            {/*                        <div*/}
            {/*                            className="flex-none w-14 h-14 bg-white rounded-full flex items-center justify-center">*/}
            {/*                            <img src="/_next/static/media/luke-redpath.0f68d408c342e9b82b5ffd53e41299f9.jpg"*/}
            {/*                                 alt=""*/}
            {/*                                 className="w-12 h-12 rounded-full bg-green-100" loading="lazy"/>*/}
            {/*                        </div>*/}
            {/*                        <div className="flex-auto">Luke Redpath<br/><span*/}
            {/*                            className="text-green-100">Ruby &amp; iOS*/}
            {/*          Developer</span></div>*/}
            {/*                        <cite className="flex"><a*/}
            {/*                            href="https://twitter.com/lukeredpath/status/1316543571684663298?s=21"*/}
            {/*                            className="opacity-50 hover:opacity-75 transition-opacity duration-200"><span*/}
            {/*                            className="sr-only">*/}
            {/*          </span>*/}
            {/*                            <svg width="33" height="32" fill="currentColor">*/}
            {/*                                <path*/}
            {/*                                    d="M32.411 6.584c-1.113.493-2.309.826-3.566.977a6.228 6.228 0 002.73-3.437 12.4 12.4 0 01-3.944 1.506 6.212 6.212 0 00-10.744 4.253c0 .486.056.958.16 1.414a17.638 17.638 0 01-12.802-6.49 6.208 6.208 0 00-.84 3.122 6.212 6.212 0 002.762 5.17 6.197 6.197 0 01-2.813-.777v.08c0 3.01 2.14 5.52 4.983 6.091a6.258 6.258 0 01-2.806.107 6.215 6.215 0 005.803 4.312 12.464 12.464 0 01-7.715 2.66c-.501 0-.996-.03-1.482-.087a17.566 17.566 0 009.52 2.79c11.426 0 17.673-9.463 17.673-17.671 0-.267-.007-.536-.019-.803a12.627 12.627 0 003.098-3.213l.002-.004z">*/}
            {/*                                </path>*/}
            {/*                            </svg>*/}
            {/*                        </a></cite>*/}
            {/*                    </figcaption>*/}
            {/*                </figure>*/}
            {/*            </li>*/}
            {/*            <li className="px-3 md:px-4 flex-none"*/}
            {/*                style="transform: translateX(-195.863%) translateZ(0px);">*/}
            {/*                <figure className="shadow-lg rounded-xl flex-none w-80 md:w-xl"*/}
            {/*                        style="transform:rotate(-2deg) translateZ(0)">*/}
            {/*                    <blockquote*/}
            {/*                        className="rounded-t-xl bg-white px-6 py-8 md:p-10 text-lg md:text-xl leading-8 md:leading-8 font-semibold text-gray-900">*/}
            {/*                        <svg width="45" height="36" className="mb-5 fill-current text-purple-100">*/}
            {/*                            <path*/}
            {/*                                d="M13.415.001C6.07 5.185.887 13.681.887 23.041c0 7.632 4.608 12.096 9.936 12.096 5.04 0 8.784-4.032 8.784-8.784 0-4.752-3.312-8.208-7.632-8.208-.864 0-2.016.144-2.304.288.72-4.896 5.328-10.656 9.936-13.536L13.415.001zm24.768 0c-7.2 5.184-12.384 13.68-12.384 23.04 0 7.632 4.608 12.096 9.936 12.096 4.896 0 8.784-4.032 8.784-8.784 0-4.752-3.456-8.208-7.776-8.208-.864 0-1.872.144-2.16.288.72-4.896 5.184-10.656 9.792-13.536L38.183.001z">*/}
            {/*                            </path>*/}
            {/*                        </svg>*/}
            {/*                        <p>I didn't think I was going to like @tailwindcss... spent a day using it for a*/}
            {/*                            POC, love it! I*/}
            {/*                            wish this had been around when we started our company design system, seriously*/}
            {/*                            considering a*/}
            {/*                            complete rebuild</p>*/}
            {/*                    </blockquote>*/}
            {/*                    <figcaption*/}
            {/*                        className="flex items-center space-x-4 p-6 md:px-10 md:py-6 bg-gradient-to-br rounded-b-xl leading-6 font-semibold text-white from-purple-500 to-indigo-500">*/}
            
            {/*                        <div className="flex-auto">Jon Bloomer<br/><span className="text-purple-100">Front-End*/}
            {/*          Developer</span>*/}
            {/*                        </div>*/}
            {/*                        <cite className="flex"><a*/}
            {/*                            href="https://twitter.com/JonBloomer/status/1300923818622377984"*/}
            {/*                            className="opacity-50 hover:opacity-75 transition-opacity duration-200"><span*/}
            {/*                            className="sr-only">*/}
            {/*          </span>*/}
            {/*                            <svg width="33" height="32" fill="currentColor">*/}
            {/*                                <path*/}
            {/*                                    d="M32.411 6.584c-1.113.493-2.309.826-3.566.977a6.228 6.228 0 002.73-3.437 12.4 12.4 0 01-3.944 1.506 6.212 6.212 0 00-10.744 4.253c0 .486.056.958.16 1.414a17.638 17.638 0 01-12.802-6.49 6.208 6.208 0 00-.84 3.122 6.212 6.212 0 002.762 5.17 6.197 6.197 0 01-2.813-.777v.08c0 3.01 2.14 5.52 4.983 6.091a6.258 6.258 0 01-2.806.107 6.215 6.215 0 005.803 4.312 12.464 12.464 0 01-7.715 2.66c-.501 0-.996-.03-1.482-.087a17.566 17.566 0 009.52 2.79c11.426 0 17.673-9.463 17.673-17.671 0-.267-.007-.536-.019-.803a12.627 12.627 0 003.098-3.213l.002-.004z">*/}
            {/*                                </path>*/}
            {/*                            </svg>*/}
            {/*                        </a></cite>*/}
            {/*                    </figcaption>*/}
            {/*                </figure>*/}
            {/*            </li>*/}
            {/*            <li className="px-3 md:px-4 flex-none"*/}
            {/*                style="transform: translateX(-195.863%) translateZ(0px);">*/}
            {/*                <figure className="shadow-lg rounded-xl flex-none w-80 md:w-xl"*/}
            {/*                        style="transform:rotate(1deg) translateZ(0)">*/}
            {/*                    <blockquote*/}
            {/*                        className="rounded-t-xl bg-white px-6 py-8 md:p-10 text-lg md:text-xl leading-8 md:leading-8 font-semibold text-gray-900">*/}
            {/*                        <svg width="45" height="36" className="mb-5 fill-current text-orange-100">*/}
            {/*                            <path*/}
            {/*                                d="M13.415.001C6.07 5.185.887 13.681.887 23.041c0 7.632 4.608 12.096 9.936 12.096 5.04 0 8.784-4.032 8.784-8.784 0-4.752-3.312-8.208-7.632-8.208-.864 0-2.016.144-2.304.288.72-4.896 5.328-10.656 9.936-13.536L13.415.001zm24.768 0c-7.2 5.184-12.384 13.68-12.384 23.04 0 7.632 4.608 12.096 9.936 12.096 4.896 0 8.784-4.032 8.784-8.784 0-4.752-3.456-8.208-7.776-8.208-.864 0-1.872.144-2.16.288.72-4.896 5.184-10.656 9.792-13.536L38.183.001z">*/}
            {/*                            </path>*/}
            {/*                        </svg>*/}
            {/*                        <p>@tailwindcss looked unpleasant at first, but now I’m hooked on it.</p>*/}
            {/*                    </blockquote>*/}
            {/*                    <figcaption*/}
            {/*                        className="flex items-center space-x-4 p-6 md:px-10 md:py-6 bg-gradient-to-br rounded-b-xl leading-6 font-semibold text-white from-yellow-400 to-orange-500">*/}
            
            {/*                        <div className="flex-auto">Andrew Gilliland<br/><span className="text-orange-100">Front-End*/}
            {/*          Developer</span></div>*/}
            {/*                        <cite className="flex"><a*/}
            {/*                            href="https://twitter.com/droidgilliland/status/1222733372855848961"*/}
            {/*                            className="opacity-50 hover:opacity-75 transition-opacity duration-200"><span*/}
            {/*                            className="sr-only">*/}
            {/*          </span>*/}
            {/*                            <svg width="33" height="32" fill="currentColor">*/}
            {/*                                <path*/}
            {/*                                    d="M32.411 6.584c-1.113.493-2.309.826-3.566.977a6.228 6.228 0 002.73-3.437 12.4 12.4 0 01-3.944 1.506 6.212 6.212 0 00-10.744 4.253c0 .486.056.958.16 1.414a17.638 17.638 0 01-12.802-6.49 6.208 6.208 0 00-.84 3.122 6.212 6.212 0 002.762 5.17 6.197 6.197 0 01-2.813-.777v.08c0 3.01 2.14 5.52 4.983 6.091a6.258 6.258 0 01-2.806.107 6.215 6.215 0 005.803 4.312 12.464 12.464 0 01-7.715 2.66c-.501 0-.996-.03-1.482-.087a17.566 17.566 0 009.52 2.79c11.426 0 17.673-9.463 17.673-17.671 0-.267-.007-.536-.019-.803a12.627 12.627 0 003.098-3.213l.002-.004z">*/}
            {/*                                </path>*/}
            {/*                            </svg>*/}
            {/*                        </a></cite>*/}
            {/*                    </figcaption>*/}
            {/*                </figure>*/}
            {/*            </li>*/}
            {/*        </ul>*/}
            {/*    </div>*/}
            </div>
            <section className="hero xl:mx-20">
                <div className="flex py-6 flex-col justify-center mt-20 items-center">
                    <img src={logo} className="logo" alt="logo"/>
                </div>
                {" "}
                <div className="text-center p-6">
                    <h2 className="font-semibold text-gray-800 text-3xl mt-1 mb-1 font-semibold ">
                        #PF_R СООБЩЕСТВО
                    </h2>
                </div>
                <div className="text-gray-600 text-center mt-1 text-xl mb-4">
                    Мы запускаем сообщество...
                </div>
                {" "}
                <div className="text-purple-900 text-center mt-2 text-xl mb-4">
                    Запущен процесс обновления системы...
                </div>
                {" "}
                <div className=" flex justify-center items-center">
                    <div className="animate-spin rounded-full h-32 w-32 border-t-2 border-b-2 border-purple-500">
                        {" "}
                    </div>
                    {" "}
                </div>
                {" "}
            </section>
        </section>
    );
};

export default Home;