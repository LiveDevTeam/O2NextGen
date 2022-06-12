import React from 'react';
import iconDenisAvatar from "../../assets/Denis_prox.jpg";

const AvatarWithStatus = (props) => {
    return (
        <div className="pl-2">
            <img className="w-9 h-9 rounded-full" src={props.userPhotoUrl} alt="Denis" />
            <div className="w-4 h-4 relative left-5 bottom-3 bg-white rounded-full"></div>
            {
                props.isOnline ?
                    <div className="w-2 h-2 relative left-6 bottom-6 bg-green-500 rounded-full"></div>
                    :
                    <div className="w-2 h-2 relative left-6 bottom-6 bg-green-500 rounded-full"></div>
            }
        </div>
    );
};

export default AvatarWithStatus;