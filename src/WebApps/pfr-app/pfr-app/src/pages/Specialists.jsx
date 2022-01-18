import React from 'react';
import SpecialistList from "../Components/SpecialistList";
import specialists from "../Data/specialists";
import Header from "../Components/Header";

const Specialists = () => {
    return (
        <div className="xl:mx-20">
            <Header/>
            <div>
                <SpecialistList title="Specialists" specialists={specialists}/>
            </div>
        </div>
    );
};

export default Specialists;