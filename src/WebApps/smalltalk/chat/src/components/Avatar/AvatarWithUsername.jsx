import React from 'react';

const AvatarWithUsername = (props) => {
    return (<div className="pl-2">
            <div className="text-gray-800 text-xm pt-1 ml-2 font-bold">{props.userName}</div>
            {
                props.isOnline ?
                    <div className="text-gray-700 text-xs ml-2">online</div> :
                    <div className="text-gray-700 text-xs ml-2">offline</div>
            }
        </div>);
};

export default AvatarWithUsername;