import React from "react";
import ReactDOM from "react-dom";

import "./index.scss";
import Header from "pfr_app/Header";
import Footer from "pfr_app/Footer";
import SafeComponent from "./SafeComponent";

const App = () => (
  <div className="text-3xl mx-auto max-w-6xl">
    <SafeComponent>
      <Header />
    </SafeComponent>
    <div className="my-10">C_GEN Page Content</div>
    <Footer />
  </div>
);
ReactDOM.render(<App />, document.getElementById("app"));
