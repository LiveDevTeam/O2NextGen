import axios from "axios";
import React, { useState, useEffect, useRef } from "react";
import ReactDOM from "react-dom";
import MessageItem from "./components/MessageItem";
import "./index.scss";
import * as signalR from '@microsoft/signalr';
import logo from './assets/bookmarks_black_24dp.svg';

function App() {
  const [connection, setConnection] = useState(null);
  const messageRef = useRef();

  const [messages, setMessages] = useState([
    { id: 1, message: 'denis prokhorchik' },
    { id: 2, message: 'denis prokhorchik2' },
    { id: 3, message: 'denis prokhorchik2' }
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
      const newMessage = { id: 1, SenderId: 1, RecipientId: 2, Message: message };
      await axios.post("https://api-smalltalk.o2bus.com/api/chat/session/1/messages",
        newMessage
      )
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


      <div className="w-14 h-screen flex flex-col">
        <div className="m-2">
          <img src="https://seeklogo.com/images/P/pypestream-logo-51F60D3389-seeklogo.com.png" alt="" />
          
          </div>
      </div>
      <div className="w-60 h-screen bg-gray-100 flex flex-col">
        
      <img src={logo} alt="" />

      </div>
      <div className="flex-grow h-screen bg-blue-100">
        <div ref={messageRef} className="overflow-y-auto h-3/4">
          {messages.map((item) =>
            <MessageItem message={item} key={item.id}></MessageItem>
          )}

        </div>

        <div className="flex h-1/4">
          <div className="flex flex-col">
            <form onSubmit={e => {
              sendMessage(message)

            }}>
              <input type="text" placeholder="text" value={message} onChange={(e) => {
                setMessage(e.target.value)
              }} />
              <button className="btn bg-blue-500 m-1 py-2 px-4" onClick={(e) => {
                e.preventDefault()
                sendMessage()
              }}>Send message</button>
            </form>
          </div>
          <div className="flex flex-col">
            <button className="btn bg-red-300 m-1 py-2 px-4" onClick={fetchData}> Get Messages</button>
          </div>
        </div>
      </div>
    </div>
  );
}
ReactDOM.render(<App />, document.getElementById("app"));
