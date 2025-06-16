<template>
  <div>
    <h1>Productos</h1>
    <button @click="$router.push('/new')">Nuevo Producto</button>
    <ul>
      <li v-for="p in productos" :key="p.id">
        {{ p.nombre }} — {{ p.precio }}
        <button @click="$router.push(`/detail/${p.id}`)">Ver</button>
        <button @click="$router.push(`/edit/${p.id}`)">Editar</button>
        <button @click="eliminar(p.id)">Eliminar</button>
      </li>
    </ul>
  </div>
</template>

<script>
import { getAllProductos, deleteProducto } from '../services/storeService';

export default {
  data() {
    return { productos: [] };
  },
  async created() {
    const { data } = await getAllProductos();
    this.productos = data;
  },
  methods: {
    async eliminar(id) {
      await deleteProducto(id);
      this.productos = this.productos.filter(p => p.id !== id);
    }
  }
};
</script>
