import React from 'react'
import iconAvatar from '.././assets/avatar-1.jpeg';

const MessageItem = (props) => {
    
    return (
        <div className="flex"> 
            
            <div className="p-2">
                    <img className="w-8 h-8 rounded-full" src={iconAvatar} alt="Denis" />
                    <div className="w-3 h-3 relative left-6 bottom-3 bg-green-300 rounded-full"></div>
                
            </div>

            <div className= "m-2 bg-gray-100 rounded-t-xl rounded-b p-3 items-start flex-col">
                < p > sender: { props.message.senderId }</p >
                <p>recipient: {props.message.recipientId}</p>
                <strong>{props.message.id}</strong> - <strong className=' text-gray-500'>{props.message.message}</strong>
                <br /> 
                <p className='text-gray-400'>8 min ago</p>
            </div >

      </div>
      
    )
}

export default MessageItem