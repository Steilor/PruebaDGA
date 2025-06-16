<template>
  <div v-if="producto">
    <h1>{{ producto.nombre }}</h1>
    <p>{{ producto.descripcion }}</p>
    <p>Precio: {{ producto.precio }}</p>
    <p>Stock: {{ producto.stock }}</p>
    <button @click="$router.push('/')">Volver</button>
  </div>
</template>

<script>
import { getProductoById } from '../services/storeService';

export default {
  props: ['id'],
  data() {
    return { producto: null };
  },
  async created() {
    const { data } = await getProductoById(this.id);
    this.producto = data;
  }
};
</script>
