import React, {useState} from 'react'
import {signoutRedirect} from '../services/userService'
import {useSelector} from 'react-redux'
import * as apiService from '../services/apiService'
import {prettifyJson} from '../utils/jsonUtils'
import Header from "../Components/Header";
import Footer from "../Components/Footer";
import {GradientLine} from "../Components/GradientLine";
import ShowCase from "../Components/ShowCase";

function Home() {
    const user = useSelector(state => state.auth.user)
    const [doughnutData, setDoughnutData] = useState(null)

    function signOut() {
        signoutRedirect()
    }

    async function getDoughnuts() {
        const doughnuts = await apiService.getDoughnutsFromApi()
        setDoughnutData(doughnuts)
    }

    return (
        <div>
            <Header/>
            <ShowCase/>
            <GradientLine/>

            <section>
                <div
                    className="flex xl:px-40  xl:pb-20 flex-col justify-center bg-gradient-to-t from-gray-50 bg-gray-100 mb-1">

                    <section className="flex justify-center xl:mx-20 m-20">
                        <div>
                            <h1>Home</h1>
                            <p>Hello, {user.profile.given_name}.</p>
                            <p>I have given you a token to call your favourite doughnut based API 🍩</p>

                            <p>💡 <strong>Tip: </strong><em>Use the Redux dev tools and network tab to inspect what user
                                data was returned from identity and stored in the client.</em></p>

                            <button className="button button-outline" onClick={() => getDoughnuts()}>Get Doughnuts
                            </button>
                            <button className="button button-clear" onClick={() => signOut()}>Sign Out</button>

                            <pre>
                                <code>
                                  {prettifyJson(doughnutData ? doughnutData : 'No doughnuts yet :(')}
                                </code>
                            </pre>
                        </div>
                    </section>
                </div>
            </section>
            <Footer/>
        </div>
    )
}

export default Home
