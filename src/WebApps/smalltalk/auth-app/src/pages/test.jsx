import React, {useRef, useState} from 'react';
import MessageItem from "smalltalk/MessageItem";
import SessionItem from "smalltalk/SessionItem";
const Test = () => {

    const [connection, setConnection] = useState(null);
    const messageRef = useRef();

    const [messages, setMessages] = useState([
        { id: 1, message: 'it is me', senderId: 1, recipientId: 2, },
        { id: 2, message: 'Who?', senderId: 2, recipientId: 1, },
        { id: 3, message: 'denis prokhorchik2', senderId: 1, recipientId: 2, },
    ])

    const [message, setMessage] = useState('')

    return (
        <div>
            test
            <div >
                {messages.map((item) =>
                    <MessageItem message={item} key={item.id}></MessageItem>
                )}
            </div>
        </div>
    );
};

export default Test;