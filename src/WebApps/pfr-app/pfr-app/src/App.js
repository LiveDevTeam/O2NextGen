import "./App.css";
import {BrowserRouter, Route} from "react-router-dom";
import Home from "./pages/Home";
import Specialists from "./pages/Specialists";
import About from "./pages/About";
import Snowfall from "react-snowfall";
import React from "react";
import Footer from "./Components/Footer";
import Header from "./Components/Header";
import AboutAdvertising from "./pages/AboutAdvertising";
import Trademarks from "./pages/Trademarks";
import TermsOfUse from "./pages/TermsOfUse";
import PrivacyStatement from "./pages/PrivacyStatement";
import SiteMap from "./pages/SiteMap";
import DetailSpecialist from "./pages/DetailSpecialist";

function App() {
    return (
        <div className="App">
            <Snowfall
                color="#dee4fd"
                snowflakeCount={500}
                radius={[0.5, 3.0]}
                speed={[0.5, 3.0]}
                wind={[-0.5, 2.0]}
            />
            <header className="App-header">

                <BrowserRouter>
                    <Route path="/" exact>
                        <Home/>
                        <Footer/>
                    </Route>
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
                </BrowserRouter>
                {" "}

            </header>
        </div>
    );
}

export default App;
