import api from '../Api/api';

export function getAllVentas() {
  return api.get('/ventas')
    .then(res => res.data);
}

export function getVentaById(id) {
  return api.get(`/ventas/${id}`)
    .then(res => res.data);
}

export function createVenta(payload) {
  return api.post('/ventas', payload);
}

export function updateVenta(id, payload) {
  return api.put(`/ventas/${id}`, payload);
}

export function deleteVenta(id) {
  return api.delete(`/ventas/${id}`);
}
