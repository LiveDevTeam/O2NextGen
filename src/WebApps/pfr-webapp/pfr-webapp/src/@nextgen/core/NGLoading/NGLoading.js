
import PropTypes from 'prop-types';
import React, { useState } from 'react';
import useTimeout from "../../hooks/useTimeout";


function NGLoading(props) {
    const [showLoading, setShowLoading] = useState(!props.delay);

    useTimeout(() => {
        setShowLoading(true);
    }, props.delay);
    return (
        <section className="flex justify-center xl:mx-20 m-20">

            <div className="relative">
            </div>

            <section className="hero xl:mx-20">
                <div className="flex py-6 flex-col justify-center mt-20 items-center">
                    <img src={this.props.logo} className="logo" alt="logo" />
                </div>
                {" "}
                <div className="text-center p-6">
                    <h2 className="text-gray-800 text-3xl mt-1 mb-1 font-semibold ">
                        #PF_R СООБЩЕСТВО
                    </h2>
                </div>
                <div className="text-gray-600 text-center mt-1 text-xl mb-4">
                    Мы запускаем сообщество...
                </div>
                {" "}
                <div className="text-purple-900 text-center mt-2 text-xl mb-4">
                    Загрузка...
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
}

NGLoading.propTypes = {
    delay: PropTypes.oneOfType([PropTypes.number, PropTypes.bool]),
};

NGLoading.defaultProps = {
    delay: false,
};

export default NGLoading;
