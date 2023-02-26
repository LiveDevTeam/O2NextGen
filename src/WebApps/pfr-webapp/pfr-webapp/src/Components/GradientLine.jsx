// @flow
import * as React from 'react';
import SpecialistItem from "./SpecialistItem";

export function GradientLine() {
    return (
        <>
            <section>
                <div className="flex xl:px-40  xl:pb-10 flex-col justify-center bg-gradient-to-t from-gray-50 bg-gray-100 mb-1">
                    <div className="flex items-center justify-start">
                        {/*<h2 className="text-left mt-4 uppercase text-lg text-gray-700 font-semibold">{props.title}</h2>*/}
                        {/*<p className="mt-4 ml-8 lowercase text-sm text-gray-500 font-semibold">{props.countSpecialists} Specialists</p>*/}
                    </div>
                    <br/>
                    <p className="text-gray-500 font-semibold">Найдите лучшего специалиста для себя: выберите нашего опытного специалиста онлайн и получите лучший сеанс.</p>
                </div>
            </section>
        </>
    );
};