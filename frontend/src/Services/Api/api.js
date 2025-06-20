
import axios from 'axios';

const api = axios.create({
  baseURL: import.meta.env.VITE_API_URL || 'https://localhost:7038/api',
  headers: {
    'Content-Type': 'application/json'
  }
});


export default api;
