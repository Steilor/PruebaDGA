import api from '../Api/api';

export function getAllClientes() {
  return api.get('/clientes')
    .then(res => res.data);
}

export function getClienteById(id) {
  return api.get(`/clientes/${id}`)
    .then(res => res.data);
}

export function createCliente(payload) {
  return api.post('/clientes', payload);
}

export function updateCliente(id, payload) {
  return api.put(`/clientes/${id}`, payload);
}

export function deleteCliente(id) {
  return api.delete(`/clientes/${id}`);
}
