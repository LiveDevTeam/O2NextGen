import React, { useState, useEffect, useRef } from "react";
import iconAvatar from '.././assets/avatar-1.jpeg';
import iconDenisAvatar from '.././assets/Denis_prox.jpg';

const MessageItem = (props) => {
    const [owner, setOwner] = useState(false)
    useEffect(() => {
        GetInfo();
    }, [])

    function GetInfo() {
        if (props.message.senderId == 1)
            setOwner(false)
        else setOwner(true)
    }
    return (
        <div>
            {owner ?
                <div className="flex justify-start">

                    <div className="p-2">
                        <img className="w-8 h-8 rounded-full" src={iconDenisAvatar} alt="Denis" />
                        <div className="w-3 h-3 relative left-6 bottom-3 bg-green-300 rounded-full"></div>
                    </div>

                    <div className="m-2 bg-gray-100 p-3 items-start flex-colq rounded-tl-lg rounded-tr-lg rounded-br-lg">
                        {/* < p > sender: { props.message.senderId }</p >
                <p>recipient: {props.message.recipientId}</p> */}
                        <p className='text-sm'>Denis Prokharchyk (<strong>{props.message.recipientId}</strong>)</p>
                        <p className='text-xs text-gray-500'>
                            {props.message.message}
                        </p>
                        <p className='text-xs text-gray-400'>8 min ago</p>
                    </div >

                </div>
                :
                <div className="flex justify-end m-8">
                    <div className="bg-blue-600 p-3 items-end flex-col rounded-tl-lg rounded-tr-lg rounded-bl-lg ">
                        {/* < p > sender: {props.message.senderId}</p >
                    <p>recipient: {props.message.recipientId}</p> */}
                        <p className='text-sm text-white'>me (<strong>{props.message.recipientId}</strong>)</p>
                        <p className='text-xs text-gray-100'>
                            {props.message.message}
                        </p>
                        <p className='text-xs text-gray-400'>8 min ago</p>
                    </div >
                    <div className="p-2">
                        <img className="w-8 h-8 rounded-full" src={iconAvatar} alt="Denis" />
                        <div className="w-3 h-3 relative left-6 bottom-3 bg-green-300 rounded-full"></div>

                    </div>
                </div>
            }
        </div>

    )
}

export default MessageItem