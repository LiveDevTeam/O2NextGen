
import ReactDOM from "react-dom";

import "./index.scss";
import React, { useEffect } from 'react';
import { BrowserRouter as Router, Route, Switch } from 'react-router-dom'
import SigninOidc from './pages/signin-oidc'
import SignoutOidc from './pages/signout-oidc'
import Home from './pages/home'
import Login from './pages/login'
import {Provider, useSelector} from 'react-redux';
import store from './store';
import userManager, { loadUserFromStorage } from './services/userService'
import AuthProvider from './utils/authProvider'
import PrivateRoute from './utils/protectedRoute'
import test from "./pages/test";
import * as signalR from '@microsoft/signalr';
import {HttpTransportType} from "@microsoft/signalr";
import soundNotification from './assets/sound-notification.wav';

function App() {
    // const user = useSelector(state => state.auth.user)
    // // const user = useSelector(state => state.auth.user)
    useEffect(() => {
    
        // new Audio(soundNotification).play();
    
    }, []);



    return (
        <Provider store={store}>
            <AuthProvider userManager={userManager} store={store}>
                <Router>
                    <Switch>
                        <Route path="/login" component={Login} />
                        <Route path="/signout-oidc" component={SignoutOidc} />
                        <Route path="/signin-oidc" component={SigninOidc} />
                        <PrivateRoute exact path="/" component={Home} />
                        <Route path="/test" component={test}/>
                    </Switch>
                </Router>
            </AuthProvider>
        </Provider>
    );
}

export default App;
ReactDOM.render(<App />, document.getElementById("app"));
