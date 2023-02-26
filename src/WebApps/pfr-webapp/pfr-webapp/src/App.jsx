import React, { useEffect } from "react";
import ReactDOM from "react-dom";
import logo from "../pfr-logo.svg";
import "./index.scss";
import Snowfall from "react-snowfall";

import NGSplashScreen from "./@nextgen/core/NGSplashScreen/NGSplashScreen";
import { BrowserRouter as Router, Route, Switch } from 'react-router-dom'
import SigninOidc from './pages/signin-oidc'
import SignoutOidc from './pages/signout-oidc'
import Home from './pages/home'
import Login from './pages/login'
import { Provider } from 'react-redux';
import store from './store';
import userManager, { loadUserFromStorage } from './services/userService'
import AuthProvider from './utils/authProvider'
import PrivateRoute from './utils/protectedRoute'
import NGSuspense from "./@nextgen/core/NGSuspense/NGSuspense";
import Specialists from "./pages/Specialists";
import Community from "./Components/Community";
import Header from "./Components/Header";
import Footer from "./Components/Footer";
import PrivacyStatement from "./Components/PrivacyStatement";
import Trademarks from "./Components/Trademarks";
import AboutAdvertising from "./Components/AboutAdvertising";
import About from "./Components/About";
import DetailSpecialist from "./Components/DetailSpecialist";
import TermsOfUse from "./Components/TermsOfUse";
import SiteMap from "./Components/SiteMap";
import Database from "./Components/Database";
function App() {

  useEffect(() => {
    // fetch current user from cookies
    loadUserFromStorage(store)
  }, [])

  return (

        <Provider store={store}>
          <AuthProvider userManager={userManager} store={store}>
            <Router>
              <Switch>
                <Route path="/login" component={Login} />
                <Route path="/signout-oidc" component={SignoutOidc} />
                <Route path="/signin-oidc" component={SigninOidc} />
                <Route path="/specialists" component={Specialists}/>
                <Route path="/database" component={Database}/>
                <Route path="/community" component={Community}/>
                {/*<Route path="/about" component={About}/>*/}
                <PrivateRoute exact path="/" component={Home} />

                <Route path="/specialists">
                  <Specialists/>
                  <Footer/>
                </Route>
                <Route path="/detail-specialist">
                  <DetailSpecialist/>
                  <Footer/>
                </Route>
                <Route path="/about">
                  <About/>
                  <Footer/>
                </Route>
                <Route path="/about-advertising">
                  <AboutAdvertising/>
                  <Footer/>
                </Route>
                <Route path="/trademarks">
                  <Trademarks/>
                  <Footer/>
                </Route>
                <Route path="/terms-of-use">
                  <TermsOfUse/>
                  <Footer/>
                </Route>
                <Route path="/privacystatement">
                  <PrivacyStatement/>
                  <Footer/>
                </Route>
                <Route path="/sitemap">
                  <SiteMap/>
                  <Footer/>
                </Route>
              </Switch>
            </Router>
          </AuthProvider>
        </Provider>
    );
}
export default App;
ReactDOM.render(<App />, document.getElementById("app"));
