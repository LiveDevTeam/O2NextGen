import React from 'react';

function GradientLine2(props) {
    return (
        <>
            <section>
                <div className="flex xl:px-40  xl:pb-6 flex-col justify-center bg-gray-200 mb-2">
                    <div className="flex items-center justify-center">
                        {/*<h2 className="text-left mt-4 uppercase text-lg text-gray-700 font-semibold">{props.title}</h2>*/}
                        {/*<p className="mt-4 ml-8 lowercase text-sm text-gray-500 font-semibold">{props.countSpecialists} Specialists</p>*/}
                    </div>
                    <br/>
                    {/*<p className="text-red-600 font-semibold">Внимание скидки: запишись на сеанс через сообщество на онлайн сеанс опытного специалиста  и получите скидку 5%.</p>*/}
                </div>
            </section>
        </>
    );
}

export default GradientLine2;