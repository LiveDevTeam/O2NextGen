import React from 'react'

const MessageItem = (props) => {

    return (
        <div className="m-2">
        <p>sender: {props.message.senderId}</p>
            <p>recipient: {props.message.recipientId}</p>
            <strong>{props.message.id}</strong> - <strong>{props.message.message}</strong>
            <br /> ===
        </div>
      
    )
}

export default MessageItem