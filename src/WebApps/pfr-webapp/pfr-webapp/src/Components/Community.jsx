import React from 'react';
import Header from "./Header";
import Footer from "./Footer";

function Community(props) {
    return (
        <div>
            <Header/>
            <section>
                <div
                    className="flex xl:px-40  xl:pb-20 flex-col justify-center bg-gradient-to-t from-gray-50 bg-gray-100 mb-1">
            Community
                </div>
            </section>
            <Footer/>
        </div>
    );
}

export default Community;