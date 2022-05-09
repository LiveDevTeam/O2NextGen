import React, { useState,useEffect } from 'react'
import {loadUserFromStorage, signoutRedirect} from '../services/userService'
import { useSelector } from 'react-redux'
import * as apiService from '../services/apiService'
import { prettifyJson } from '../utils/jsonUtils'
import { useRef } from "react";
import MessageItem from "smalltalk/MessageItem";
import CheckApi from "./check-api";
import store from "../store";
import * as signalR from "@microsoft/signalr";
import soundNotification from '../assets/sound-notification.wav';
import {SignalRHub_URl} from "../configuration";

function Home() {
  const user = useSelector(state => state.auth.user)
  const [doughnutData, setDoughnutData] = useState(null)
    const [connection, setConnection] = useState(null);
    const messageRef = useRef();

    useEffect(() => {
        // fetch current user from cookies
        loadUserFromStorage(store).then(()=>{
            let connect = new signalR.HubConnectionBuilder()
                .withUrl(SignalRHub_URl,
                    {
                        // skipNegotiation: true,
                        // transport: signalR.HttpTransportType.LongPolling,
                        accessTokenFactory: () => user.access_token
                    })
                .configureLogging(signalR.LogLevel.Information)
                .withAutomaticReconnect()
                .build();
            connect.start().then(() => {
                connect.invoke("SendStateUser")
                console.log('Connection started!')
            }) 
                .catch(err => {
                    console.log(err);
                });
                console.log("invoke is called")
            connect.on("OnUserUpdateState",()=>{
                new Audio(soundNotification).play();
                console.log("call >> OnUserUpdateState")
            })
            connect.on("OnGetNewMessage", (userId)=>{
              //(new Audio(soundNotification)).play();
              new Audio(soundNotification).play();
            console.log("bell")
                console.log(userId)
          })
            setConnection(connect)
        })
    }, [])




  const [messages, setMessages] = useState([
    { id: 1, message: 'it is me', senderId: 1, recipientId: 2, },
    { id: 2, message: 'Who?', senderId: 2, recipientId: 1, },
    { id: 3, message: 'denis prokhorchik2', senderId: 1, recipientId: 2, },
  ]);

  const [message, setMessage] = useState('');

  function signOut() {
    signoutRedirect()
    connection.stop()
  }

  async function getDoughnuts() {
    const doughnuts = await apiService.getDoughnutsFromApi()
    setDoughnutData(doughnuts)
  }



  return (
    <div>
      <h1>Home</h1>
      <p>Hello, {user.profile.given_name}.</p>
        {/*<p>{connection}</p>*/}
      <p>I have given you a token to call your favourite doughnut based API 🍩</p>

      <p>💡 <strong>Tip: </strong><em>Use the Redux dev tools and network tab to inspect what user data was returned from identity and stored in the client.</em></p>

      <div className="p-2">
        <button className="btn bg-blue-500 text-white p-2 rounded-lg" onClick={() => getDoughnuts()}>Get Doughnuts</button></div>
      <div className="p-2">
        <button className="btn bg-green-500 text-white p-2 rounded-lg" onClick={() => signOut()}>Sign Out</button>
      </div>

      <pre>
        <code>
          {prettifyJson(doughnutData ? doughnutData : 'No doughnuts yet :(')}
        </code>
      </pre>
      <div >
        {messages.map((item) =>
          <MessageItem message={item} key={item.id}></MessageItem>
        )}
      </div>
      <p><a target='_blank' rel='noopener noreferrer' href='https://github.com/tappyy/react-IS4-auth-demo'>Github Repo</a></p>
      <CheckApi />
    </div>
  )
}

export default Home
