import axios from 'axios'

async function getDoughnutsFromApi() {
  const response = await axios.get('http://localhost:5003/api/chat/session/1/messages');
  return response.data;
}

async function sendMessageApi(message) {
  const newMessage = { id: 1, senderId: 1, recipientId: 2, message: message };
  await axios.post("https://api-smalltalk.o2bus.com/api/chat/session/1/messages",
      newMessage
  )
}

export {
  getDoughnutsFromApi,
  sendMessageApi
}
