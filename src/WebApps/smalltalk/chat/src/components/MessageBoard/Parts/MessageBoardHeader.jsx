import React from 'react';
import AvatarWithStatus from "../../Avatar/AvatarWithStatus";
import AvatarWithUsername from "../../Avatar/AvatarWithUsername";

const MessageBoardHeader = (props) => {
    return (
        <div className="w-full h-14 bg-white">
            <div>
                <div className="p-2 flex">
                    <AvatarWithStatus userPhotoUrl={props.userPhoto} isOnline={props.userStatus}></AvatarWithStatus>
                    <AvatarWithUsername userName={props.userName} isOnline={props.userStatus}/>
                </div>
            </div>
        </div>
    );
};

export default MessageBoardHeader;