import React from 'react';
import SpecialistItem from "../Components/SpecialistItem";
import SpecialistList from "../Components/SpecialistList";
import specialists from "../Data/specialists";
import Header from "../Components/Header";
import Footer from "../Components/Footer";

const Specialists = () => {
    return (
        <div >
            <Header />
            <div className="flex justify-between items-center xl:mx-40">
                <ul className="flex justify-center items-center my-4">
                    <li className="px-2"><button className="bg-gradient-to-br text-white from-yellow-400 to-orange-500 shadow-sm rounded-lg p-2 px-4">also speakers </button></li>
                    <li className="px-2"> <button className="bg-gradient-to-br text-white from-purple-500 to-indigo-500  shadow-sm rounded-lg p-2 px-4">from </button></li>
                    <li className="px-2"> <button className="bg-gradient-to-br text-white from-green-400 to-cyan-500  shadow-sm rounded-lg p-2 px-4">price </button></li>
                    <li className="px-2"><button className="bg-gradient-to-br text-white from-orange-400 to-pink-600   shadow-sm rounded-lg p-2 px-4">type specialist </button></li>
                    <li className="px-2"> <button className="bg-gradient-to-br text-white from-fuchsia-500 to-purple-600   shadow-sm rounded-lg p-2 px-4">category </button></li>
                    <li className="px-2"> <button className="bg-gradient-to-br text-white from-cyan-400 to-light-blue-500 shadow-sm rounded-lg p-2 px-4">top </button></li>
                    <li className="px-2"> <button className="bg-gradient-to-br text-white from-light-blue-400 to-indigo-500 rounded-lg p-2 px-4">top </button></li>
                    <li className="px-2"> <button className="bg-gradient-to-br text-white from-pink-500 to-rose-500 rounded-lg p-2 px-4">top </button></li>
                    <li className="px-2"> <button className="bg-gradient-to-br text-white from-yellow-400 to-orange-500 rounded-lg p-2 px-4">top </button></li>
                </ul>


                <form>
                    <input  className="focus:ring-2 focus:ring-blue-500 focus:outline-none appearance-none w-full text-sm leading-6 text-slate-900 placeholder-slate-400 rounded-md py-2 pl-10 ring-1 ring-slate-200 shadow-sm" type="text" placeholder="Filter specialists..."/>
                </form>
            </div>
            <div>
                <SpecialistList title="Find the best specialist for you" specialists={specialists} countSpecialists={specialists.length+1252}/>
            </div>
            {/*<div>*/}
            {/*    <SpecialistItem specialist={specialists[0]}/>*/}
            {/*</div>*/}
            <Footer/>
        </div>
    );
};

export default Specialists;