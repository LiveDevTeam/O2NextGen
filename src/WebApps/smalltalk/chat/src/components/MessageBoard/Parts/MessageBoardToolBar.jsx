import React, {useState} from 'react';
import iconAttach from "../../../assets/attachment_black_24dp.svg";
import iconEmo from "../../../assets/insert_emoticon_black_24dp.svg";
import iconSend from "../../../assets/send_black_24dp.svg";

const MessageBoardToolBar = (props) => {
    const [message, setMessage] = useState('');
    return (
        <div className="w-full h-16 flex px-3">

            <input className="flex-grow focus:outline-none" type="text" placeholder="Type your message..." value={message} onChange={(e) => {
                props.setMessage(e.target.value)
            }} />

            <div className="flex">
                <button className="btn bg-blue-500 m-2 py-2 px-4 rounded-full" onClick={(e) => {
                    e.preventDefault()
                    props.sendMessage()
                }}>  <img className="w-5" src={props.iconAttach} alt="" />
                </button>
            </div>

            <div className="flex">
                <button className="btn bg-blue-500 m-2 py-2 px-4 rounded-full" onClick={(e) => {
                    e.preventDefault()
                    props.sendMessage()
                }}>
                    <img className="w-5" src={props.iconEmo} alt="" />
                </button>
            </div>

            <div className="flex">
                <button className="btn bg-blue-500 m-2 py-2 px-4 rounded-full" onClick={(e) => {
                    e.preventDefault()
                    props.sendMessage()
                }}>
                    <img className="w-5" src={props.iconSend} alt="" />
                </button>
            </div>

        </div>
    );
};

export default MessageBoardToolBar;