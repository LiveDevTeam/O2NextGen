import React, {process} from 'react';
import ReactDOM from "react-dom";
import "./index.scss";

if (process.env.NODE_ENV !== 'production')
{
   console.log(`${process.env.NODE_ENV}`)
   console.log(`${process.env.REACT_APP_NAME}`)
}

const App = () => (
   <div className="mt-10 text-3xl mx-auto max-w-6xl">
      <div> CGen App - Create certificates quickly and easily...</div>
      <div> Download Application - Denis Pro; {`envs REACT_APP_NAME = ${process.env.REACT_APP_NAME}`}</div>
      <div>
         <button className="bg-blue-600 text-white py-2 px-4
 mt-3 mx-2 hover:bg-blue-800 sm:inline-block">Windows Store</button>
         <button className="bg-blue-600 text-white py-2 px-4
 mt-3 mx-2 hover:bg-blue-800 sm:inline-block">Apple iStore</button>
         <button className="bg-blue-600 text-white py-2 px-4
 mt-3 mx-2 hover:bg-blue-800 sm:inline-block">Google Play</button>
      </div>
   </div>
);
ReactDOM.render(<App />, document.getElementById("app"));
