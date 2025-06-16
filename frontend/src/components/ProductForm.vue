<template>
  <div>
    <h1>{{ isEdit ? 'Editar' : 'Crear' }} Producto</h1>
    <form @submit.prevent="guardar">
      <input v-model="form.nombre" placeholder="Nombre" required />
      <input v-model="form.descripcion" placeholder="Descripción" />
      <input v-model.number="form.precio" placeholder="Precio" type="number" required />
      <input v-model.number="form.stock" placeholder="Stock" type="number" required />
      <button type="submit">Guardar</button>
    </form>
  </div>
</template>

<script>
import { createProducto, updateProducto, getProductoById } from '../services/storeService';

export default {
  props: ['id'],
  data() {
    return {
      form: { nombre: '', descripcion: '', precio: 0, stock: 0 },
      isEdit: !!this.id
    };
  },
  async created() {
    if (this.isEdit) {
      const { data } = await getProductoById(this.id);
      this.form = { ...data };
    }
  },
  methods: {
    async guardar() {
      if (this.isEdit) {
        await updateProducto(this.id, this.form);
      } else {
        await createProducto(this.form);
      }
      this.$router.push('/');
    }
  }
};
</script>
