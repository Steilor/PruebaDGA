import axios from 'axios';

const api = axios.create({
  baseURL: '/api/store'
});

export const getAllProductos = () => api.get('/');
export const getProductoById = id => api.get(`/${id}`);
export const createProducto = data => api.post('/', data);
export const updateProducto = (id, data) => api.put(`/${id}`, data);
export const deleteProducto = id => api.delete(`/${id}`);
