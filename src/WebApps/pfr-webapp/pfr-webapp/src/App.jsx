import React from "react";
import ReactDOM from "react-dom";
import logo from "../pfr-logo.svg";
import "./index.scss";
import Snowfall from "react-snowfall";
import { BrowserRouter, Route } from "react-router-dom";
import NGSplashScreen from "./@nextgen/core/NGSplashScreen/NGSplashScreen";

const App = () => (

  <div>
    <Snowfall
      color="#dee4fd"
      snowflakeCount={500}
      radius={[0.5, 3.0]}
      speed={[0.5, 3.0]}
      wind={[-0.5, 2.0]}
    />
      <BrowserRouter>
        <NGSplashScreen logo={logo}/>
      </BrowserRouter>
  </div>
);
ReactDOM.render(<App />, document.getElementById("app"));
