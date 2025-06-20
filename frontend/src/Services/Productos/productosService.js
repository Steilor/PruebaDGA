import api from '../Api/api';

export function getAllProductos() {
  return api.get('/productos')
    .then(res => res.data);
}

export function getProductoById(id) {
  return api.get(`/productos/${id}`)
    .then(res => res.data);
}

export function createProducto(payload) {
  return api.post('/productos', payload);
}

export function updateProducto(id, payload) {
  return api.put(`/productos/${id}`, payload);
}

export function deleteProducto(id) {
  return api.delete(`/productos/${id}`);
}
