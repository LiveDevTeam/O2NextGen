import React from 'react'
import { signinRedirect } from '../services/userService'
import { Redirect } from 'react-router-dom'
import { useSelector } from 'react-redux'
import logo from '.././assets/SmallTalk-Logo_no_signature.png'
function Login() {
  const user = useSelector(state => state.auth.user)

  function login() {
    signinRedirect()
  }

  return (
    (user) ?
      (<Redirect to={'/'} />)
      :
      (
        <div className="flex items-center justify-center bg-gray-200 h-screen">
          
          <div className="w-96  bg-gray-100 p-10  rounded-lg">
            <div className="flex  flex-col m-2 justify-center items-center">
              <div className="w-24 m-2">
                <img src={logo} alt="" />
              </div>
            </div>
          <div className="flex  flex-col m-2">
              <div className='text-gray-800 text-2xl pt-1 ml-2 font-bold  text-center'>Welcome to SmallTalk!</div>
              <div className="pt-6 text-center">
              <p>Start chatting right now...</p>
              <p>Create your account and add your friends to stay connected...</p>
              <p>💡 <strong>Tip: </strong><em>User: 'alice', Pass: 'alice'</em></p>
            </div>
          </div>

          <div className="flex flex-col pt-6">
              <button className="btn bg-blue-500 text-white p-2 rounded-lg" onClick={() => login()}>SignIn</button>
            </div>
            <div className="flex flex-col pt-2">
              <button className="btn bg-blue-500 text-white p-2 rounded-lg" onClick={() => Register()}>Create free account</button>
            </div>
          </div>
          
        </div>
      )
  )
}

export default Login
