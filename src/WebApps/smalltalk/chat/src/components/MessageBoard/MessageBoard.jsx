import React from 'react';
import MessageBoardHeader from "./Parts/MessageBoardHeader";
import iconDenisAvatar from "../../assets/Denis_prox.jpg";
import iconAttach from "../../assets/attachment_black_24dp.svg";
import iconEmo from "../../assets/insert_emoticon_black_24dp.svg";
import iconSend from "../../assets/send_black_24dp.svg";
import MessageBoardPlace from "./Parts/MessageBoardPlace";
import MessageBoardToolBar from "./Parts/MessageBoardToolBar";


const MessageBoard = (props) => {
    return (
        <div className="flex-grow h-screen bg-white flex flex-col">

            <MessageBoardHeader
                userPhoto={props.iconDenisAvatar}
                userStatus={props.userStatus}
                userName={props.userName}
            />

            <MessageBoardPlace refMessageDiv={props.messageRef}
                               messages={props.messages}/>

            <MessageBoardToolBar
                sendMessage={props.sendMessage}
                setMessage={props.setMessage}
                 iconAttach={iconAttach}
                 iconEmo={iconEmo}
                 iconSend={iconSend}
            />


        </div >
    );
};

export default MessageBoard;