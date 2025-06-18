
import axios from 'axios';

const api = axios.create({
  baseURL: import.meta.env.VITE_API_URL || 'https://localhost:7038/api',
  headers: {
    'Content-Type': 'application/json'
  }
});


export default api;

//export const getAllProductos = () => api.get('/');
//export const getProductoById = id => api.get(`/${id}`);
//export const createProducto = data => api.post('/', data);
//export const updateProducto = (id, data) => api.put(`/${id}`, data);
//export const deleteProducto = id => api.delete(`/${id}`);
