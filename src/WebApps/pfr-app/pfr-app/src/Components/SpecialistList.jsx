import React, {useState} from 'react';
import SpecialistItem from "./SpecialistItem";

const SpecialistList = (props) => {

    return (
        <>
        <section>
            <h2 className="text-center">{props.title}</h2>
            <div className="flex  items-center justify-center bg-white m-4">
                {props.specialists.map((specialist) =>
                    <SpecialistItem specialist={specialist} key={specialist.id}/>
                )}

            </div>
        </section>
        </>
    );
};

export default SpecialistList;