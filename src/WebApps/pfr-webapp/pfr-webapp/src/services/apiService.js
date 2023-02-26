import axios from 'axios'

async function getDoughnutsFromApi() {
  const response = await axios.get('https://localhost:11001/api/v1.0/PublishBase?categoryTypeId=2861&pageSize=14&pageIndex=0');
  return response.data;
}

export {
  getDoughnutsFromApi
}
