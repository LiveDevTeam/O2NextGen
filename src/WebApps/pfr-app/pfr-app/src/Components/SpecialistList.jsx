import React, {useState} from 'react';
import SpecialistItem from "./SpecialistItem";

const SpecialistList = (props) => {

    return (

        <>
        <section>
            <div className="flex xl:px-40  xl:pb-20 flex-col justify-center bg-gradient-to-t from-gray-50 bg-gray-100 mb-1">
                <h2 className="text-center m-4 uppercase text-lg font-bold">{props.title}</h2>
                {props.specialists.map((specialist) =>
                    <SpecialistItem specialist={specialist} key={specialist.id}/>
                )}

            </div>
        </section>
        </>
    );
};

export default SpecialistList;