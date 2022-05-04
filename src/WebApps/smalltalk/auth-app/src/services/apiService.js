import axios from 'axios'

async function getDoughnutsFromApi() {
  const response = await axios.get('http://localhost:5003/api/chat/session/1/messages');
  return response.data;
}

export {
  getDoughnutsFromApi
}
