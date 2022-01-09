import logo from "./pfr-logo.svg";
import "./App.css";
import Snowfall from "react-snowfall";
import Footer from "./Components/Footer";

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
        <section className="hero xl:mx-20">
          <div class="flex py-6 flex-col justify-center mt-20 items-center">
            <img src={logo} className="logo" alt="logo" />
          </div>{" "}
          <div class="text-center p-6">
            <h2 class="font-semibold text-gray-800 text-3xl mt-1 mb-1 font-semibold ">
              #PF_R СООБЩЕСТВО
            </h2>
          </div>
          <div class="text-gray-600 text-center mt-1 text-xl mb-4">
            Мы запускаем сообщество...
          </div>{" "}
          <div class="text-purple-900 text-center mt-2 text-xl mb-4">
            Запущен процесс обновления системы...
          </div>{" "}
          <div class=" flex justify-center items-center">
            <div class="animate-spin rounded-full h-32 w-32 border-t-2 border-b-2 border-purple-500">
              {" "}
            </div>{" "}
          </div>{" "}
        </section>{" "}
        <Footer />
      </header>{" "}
    </div>
  );
}

export default App;
