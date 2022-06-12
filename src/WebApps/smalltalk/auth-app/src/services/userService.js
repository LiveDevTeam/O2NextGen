import { UserManager } from 'oidc-client';
import { storeUserError, storeUser } from '../actions/authActions'
import {Client_URL, Identity_URL} from "../configuration";

// const config = {
//   authority: "https://localhost:10001",
//   client_id: 'smalltalk_client_reactjs',
//   response_type: 'code',
//   scope: 'openid profile',
//   redirect_uri: "http://localhost:3003/signin-oidc"
// };
const config = {
    authority: Identity_URL,
    client_id: "smalltalk_client_reactjs",
    redirect_uri: Client_URL+"/signin-oidc",
    response_type: "id_token token",
    //client_secret: "secret",
    scope: "openid profile smalltalkapi smalltalksignalr",
    // monitorSession: false,
    // loadUserInfo: true,
    // post_logout_redirect_uri: "http://localhost:3003/signout-oidc"
  }

const userManager = new UserManager(config)

export async function loadUserFromStorage(store) {
  try {
    let user = await userManager.getUser()
    if (!user) { return store.dispatch(storeUserError()) }
    store.dispatch(storeUser(user))
  } catch (e) {
    console.error(`User not found: ${e}`)
    store.dispatch(storeUserError())
  }
}

export function signinRedirect() {
  return userManager.signinRedirect()
}

export function signinRedirectCallback() {
  return userManager.signinRedirectCallback()
}

export function signoutRedirect() {
  userManager.clearStaleState()
  userManager.removeUser()
  return userManager.signoutRedirect()
}

export function signoutRedirectCallback() {
  userManager.clearStaleState()
  userManager.removeUser()
  return userManager.signoutRedirectCallback()
}

export default userManager