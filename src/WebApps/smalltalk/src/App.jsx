import axios from "axios";
import React, { useState, useEffect, useRef } from "react";
import ReactDOM from "react-dom";
import MessageItem from "./components/MessageItem";
import "./index.scss";
import * as signalR from '@microsoft/signalr';
import iconBookmarks from './assets/bookmarks_black_24dp.svg';
import iconSms from './assets/sms_black_24dp.svg';
import iconSettings from './assets/settings_black_24dp.svg';
import iconLogout from './assets/power_settings_new_black_24dp.svg';
import iconAccoutSettings from './assets/manage_accounts_black_24dp.svg';
import iconSearch from './assets/search_black_24dp.svg';
import iconAttach from './assets/attachment_black_24dp.svg';
import iconSend from './assets/send_black_24dp.svg';
import iconEmo from './assets/insert_emoticon_black_24dp.svg';
import iconAvatar from './assets/avatar-1.jpeg';
import iconDenisAvatar from './assets/Denis_prox.jpg';
function App() {
  const [connection, setConnection] = useState(null);
  const messageRef = useRef();

  const [messages, setMessages] = useState([
    { id: 1, message: 'it is me', senderId: 1, recipientId: 2, },
    { id: 2, message: 'Who?', senderId: 2, recipientId: 1, },
    { id: 3, message: 'denis prokhorchik2', senderId: 1, recipientId: 2, },
  ])

  const [message, setMessage] = useState('')

  useEffect(() => {
    let connect = new signalR.HubConnectionBuilder()
      .withUrl("https://signalr.o2bus.com/chathub")
      .configureLogging(signalR.LogLevel.Information)
      .withAutomaticReconnect()
      .build();

    connect.on("OnUpdateMessage", async () => {
      console.log("get data")
      await fetchData()
      scrollDown();
    });
    connect.start().then(() => {
      connect.invoke("NewUserAsync", "Denis")
      console.log('Connection started!')
    })
      .catch(err => console.log(err));
    console.log("invoke is called")
    setConnection(connect)
  }, []);
  function scrollDown() {
    if (messageRef && messageRef.current) {
      const { scrollHeight, clientHeight } = messageRef.current;
      messageRef.current.scrollTo({
        left: 0, top: scrollHeight - clientHeight,
        behavior: "smooth"
      })
    }
  }
  async function sendMessage() {
    try {
      const newMessage = { id: 1, senderId: 1, recipientId: 2, message: message };
      await axios.post("https://api-smalltalk.o2bus.com/api/chat/session/1/messages",
        newMessage
      )
      setMessage('')
      //fetchData();
    }
    catch (e) {
      console.log(e)
    }
  }
  async function fetchData() {
    const response =
      await axios.get('https://api-smalltalk.o2bus.com/api/chat/session/1/messages');
    console.log(response)
    setMessages(response.data)
  }

  return (
    <div className="flex">
      <div className="w-14 h-screen flex flex-col items-center justify-between">
        <div className="w-10 m-2">
          <img src="https://seeklogo.com/images/P/pypestream-logo-51F60D3389-seeklogo.com.png" alt="" />
        </div>

        <div className="flex flex-col">
          <div className="py-3 w-5 flex flex-col justify-center items-center">
            <img src={iconBookmarks} alt="bookmarks" />
            <div className="w-1 h-1 bg-blue-500 rounded-full">
            </div>
          </div>
          <div className="py-3 w-5 flex flex-col justify-center items-center">
            <img src={iconSms} alt="sms" />
            <div className="w-1 h-1 bg-blue-500 rounded-full">
            </div>
          </div>
          <div className="py-3 w-5 flex flex-col justify-center items-center">
            <img src={iconBookmarks} alt="bookmarks" />
            <div className="w-1 h-1 bg-blue-500 rounded-full">
            </div>
          </div>
          <div className="py-3 w-5 flex flex-col justify-center items-center">
            <img src={iconAccoutSettings} alt="account settings" />
            <div className="w-1 h-1 bg-blue-500 rounded-full">
            </div>
          </div>

          <div className="py-3 w-5 flex flex-col justify-center items-center">
            <img src={iconLogout} alt="logout" />
            <div className="w-1 h-1 bg-blue-500 rounded-full">
            </div>
          </div>
        </div>
        <div>
        </div>
        <div className="flex flex-col">
          <div className="py-3 w-5 flex flex-col justify-center items-center">
            <img src={iconSettings} alt="settings" />
          </div>
        </div>
      </div>
      <div className="w-60 h-screen bg-gray-100 border-b-2 border-gray-500">
        <div className="text-xl p-3">
          Chats
        </div>
        <div className="p-3 flex">
          <input className="p-2 w-10/12 bg-gray-200 text-xs focus:outline-none rounded-tl-md rounded-bl-md"
            type="text" placeholder="search for messages of users..." />
          <div className="w-2/12 flex justify-center items-center bg-gray-200 rounded-tr-md rounded-br-md">
            <img className="w-5" src={iconSearch} alt="search" />
          </div>
        </div>

        <div className="flex">
          <div className="p-2">
            <img className="w-8 h-8 rounded-full" src={iconDenisAvatar} alt="Denis" />
            <div className="w-4 h-4 relative left-5 bottom-3 bg-gray-100 rounded-full"></div>
            <div className="w-2 h-2 relative left-6 bottom-6 bg-green-500 rounded-full"></div>
            
            <div className="text-gray-500 text-xm pt-1">Denis</div>
          </div>

          <div className="p-2">
            <img className="w-8 h-8 rounded-full" src={iconAvatar} alt="Denis" />
            <div className="text-gray-500 text-xm pt-3">Denis</div>
          </div>

          <div className="p-2">
            <img className="w-8 h-8 rounded-full" src={iconAvatar} alt="Denis" />
            <div className="text-gray-500 text-xm pt-3">Denis</div>
          </div>

          <div className="p-2">
            <img className="w-8 h-8 rounded-full" src={iconAvatar} alt="Denis" />
            <div className="text-gray-500 text-xm pt-3">Denis</div>
          </div>
          <div className="p-2">
            <img className="w-8 h-8 rounded-full" src={iconAvatar} alt="Denis" />
            <div className="text-gray-500 text-xm pt-3">Denis</div>
          </div>
        </div>

      </div>
      <div className="flex-grow h-screen bg-white flex flex-col">
        <div className="w-full h-14 bg-white">
          <div>
            <div className="p-2 flex">
              <div className="pl-2">
                <img className="w-9 h-9 rounded-full" src={iconDenisAvatar} alt="Denis" />
                <div className="w-4 h-4 relative left-5 bottom-3 bg-white rounded-full"></div>
                <div className="w-2 h-2 relative left-6 bottom-6 bg-green-500 rounded-full"></div>
              </div>
              <div className="pl-2">
                <div className="text-gray-800 text-xm pt-1 ml-2 font-bold">Denis Prokharchyk</div>
                <div className="text-gray-700 text-xs ml-2">online</div>
              </div>

            </div>
          </div>
          

        </div>
        <div className="w-full flex-grow" >
          <div ref={messageRef}>
            <div className="flex overflow-y-auto flex-col-reverse p-4" style={{

              minHeight: '10%',
              maxHeight: '85vh',
            }}>
              <div >
                {messages.map((item) =>
                  <MessageItem message={item} key={item.id}></MessageItem>
                )}
              </div>
            </div>
          </div>
        </div>
        <div className="w-full h-16 flex px-3">

          <input className="flex-grow focus:outline-none" type="text" placeholder="Type your message..." value={message} onChange={(e) => {
            setMessage(e.target.value)
          }} />

          <div className="flex">
            <button className="btn bg-blue-500 m-2 py-2 px-4 rounded-full" onClick={(e) => {
              e.preventDefault()
              sendMessage()
            }}>  <img className="w-5" src={iconAttach} alt="" />
            </button>
          </div>

          <div className="flex">
            <button className="btn bg-blue-500 m-2 py-2 px-4 rounded-full" onClick={(e) => {
              e.preventDefault()
              sendMessage()
            }}>
              <img className="w-5" src={iconEmo} alt="" />
            </button>
          </div>

          <div className="flex">
            <button className="btn bg-blue-500 m-2 py-2 px-4 rounded-full" onClick={(e) => {
              e.preventDefault()
              sendMessage()
            }}>
              <img className="w-5" src={iconSend} alt="" />
            </button>
          </div>

        </div>
        {/* <div className="flex flex-col">
          <button className="btn bg-red-300 m-1 py-2 px-4" onClick={fetchData}> Get Messages</button>
        </div> */}
      </div >



    </div >
  );
}
ReactDOM.render(<App />, document.getElementById("app"));
