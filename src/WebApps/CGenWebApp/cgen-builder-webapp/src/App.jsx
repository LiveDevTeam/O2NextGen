import LogoIcon from "./icons/logo.svg"
import AddBoxOutlinedIcon from '@mui/icons-material/AddBoxOutlined';
import LayersOutlinedIcon from '@mui/icons-material/LayersOutlined';
import ColorLensOutlinedIcon from '@mui/icons-material/ColorLensOutlined';
import PreviewOutlinedIcon from '@mui/icons-material/PreviewOutlined';
import React from "react";
import ReactDOM from "react-dom";

import "./index.scss";
import Tooltip from "./Controls/Tooltip";

const App = () => (
  <div className="flex bg-gray-100 font-sans text-gray-900">
    <aside className="w-18 h-screen bg-white border-r bprder-gray-200 flex flex-col items-center">
    <div className="h-18 w-full flex items-center justify-center border-b border-gray-200">
      {/* <LogoIcon></LogoIcon> */}
      <img src="{LogoIcon}" />
    </div>
    <nav className="flex flex-1 flex-col gap-y-4 pt-10 ">
        <a className="relative rounded-xl bg-gray-100 p-2 text-blue-600 hover:bg-gray-50" href="#">
          <AddBoxOutlinedIcon className="h-6 w-6" />
          <Tooltip>Add elements <span className="text-gray-400">(A)</span> </Tooltip>
      </a>
        <a className="relative rounded-xl p-2 text-gray-600 hover:bg-gray-50" href="#">
        <LayersOutlinedIcon className="h-6 w-6" />
          <Tooltip>Layers <span className="text-gray-400">(L)</span> </Tooltip>
      </a>
        <a className="relative rounded-xl p-2 text-gray-600 hover:bg-gray-50" href="#">
          <ColorLensOutlinedIcon className="h-6 w-6" />
          <Tooltip>Color <span className="text-gray-400">(L)</span> </Tooltip>
      </a>
        <a className="group relative rounded-xl p-2 text-gray-600 hover:bg-gray-50" href="#">
          <PreviewOutlinedIcon className="h-6 w-6" />
          <Tooltip>Preview <span className="text-gray-400">(P)</span> </Tooltip>
        </a>
    </nav>
    {/* <div>Name: cgen-builder-webapp</div>
    <div>Framework: react</div>
    <div>Language: JavaScript</div>
    <div>CSS: Tailwind</div> */}
    </aside>
  </div>
);
ReactDOM.render(<App />, document.getElementById("app"));
