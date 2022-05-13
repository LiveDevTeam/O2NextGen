import React, {useState} from 'react';
import MessageItem from "../../MessageItem";

const MessageBoardPlace = (props) => {

    return (
        <div className="w-full flex-grow" >
            <div ref={props.refMessageDiv}>
                <div className="flex overflow-y-auto flex-col-reverse p-4" style={{

                    minHeight: '10%',
                    maxHeight: '85vh',
                }}>
                    <div >
                        {props.messages.map((item) =>
                            <MessageItem message={item} key={item.id}></MessageItem>
                        )}
                    </div>
                </div>
            </div>
        </div>
    );
};

export default MessageBoardPlace;