import React from 'react';
import Header from "../Components/Header";

const DetailSpecialist = () => {
    return (
        <div >
            <Header />
            <div className="flex xl:px-40  xl:pb-20 justify-center bg-gradient-to-t from-gray-50 bg-gray-100 mb-1">
                <div className="flex  flex-col items-start mt-4 w-2/3">
                    <div className="flex  items-start space-x-6 p-6  bg-white shadow-lg rounded-xl mt-4">
                        <iframe width="850" height="340"  src="https://www.youtube.com/embed/TIqJAHfl9SE"
                                title="YouTube video player" frameBorder="0"
                                allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture"
                                allowFullScreen></iframe>
                    </div>
                    <div className="flex  space-x-6 p-6  bg-white shadow-lg rounded-xl mt-4">
                        Test
                    </div>
                    <div className="flex items-start space-x-6 p-6  bg-white shadow-lg rounded-xl mt-4">
                        <div>
                            <iframe width="850" height="340"  src="https://www.youtube.com/embed/TIqJAHfl9SE"
                                    title="YouTube video player" frameBorder="0"
                                    allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture"
                                    allowFullScreen></iframe>
                        </div>
                        <div>

                        </div>
                    </div>
                </div>

                <div className="flex   flex-col items-start space-x-6 p-6 ml-4  bg-white shadow-lg rounded-xl mt-4 w-1/3">
                </div>
            </div>
        </div>
    );
};

export default DetailSpecialist;