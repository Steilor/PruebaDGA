<template>
   <div class="p-6">
    <div class="flex justify-between items-center mb-6">
      <h1 class="text-3xl font-bold text-gray-900">Productos</h1>
      <button
        @click="openCreateModal"
        class="bg-primary-600 text-white px-4 py-2 rounded-lg hover:bg-primary-700 transition-colors flex items-center"
      >
        <Plus class="w-4 h-4 mr-2" />
        Agregar Producto
      </button>
    </div>
    
    <div v-if="loading" class="flex justify-center items-center h-64">
      <LoadingSpinner />
    </div>
    
    <div v-else class="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-6">
      <div
        v-for="product in products"
        :key="product.id"
        class="bg-white p-6 rounded-lg shadow-md hover:shadow-lg transition-all duration-300 border border-gray-100"
      >
        <div class="mb-4">
          <h3 class="text-lg font-semibold text-gray-900 mb-2">{{ product.name }}</h3>
          <p class="text-gray-600 text-sm leading-relaxed">{{ product.description }}</p>
        </div>
        
        <div class="flex justify-between items-center mb-4">
          <div class="flex flex-col">
            <span class="text-xs text-gray-500 uppercase tracking-wide font-medium mb-1"></span>
            <div class="flex items-baseline">
              <span class="text-2xl font-bold text-gray-600">RD$ {{ product.price.toLocaleString('es-DO', { minimumFractionDigits: 2, maximumFractionDigits: 2 }) }}</span>
              
            </div>
          </div>
          <div class="text-right">
            <span class="text-xs text-gray-500 uppercase tracking-wide font-medium block mb-1">Stock</span>
            <div class="flex items-center">
              <div class="w-2 h-2 rounded-full mr-2" :class="
                product.stock > 10 ? 'bg-green-400' :
                product.stock > 0  ? 'bg-yellow-400' : 'bg-red-400'
              "></div>
              <span class="text-sm font-semibold" :class="
                product.stock > 10 ? 'text-green-600' :
                product.stock > 0  ? 'text-yellow-600' : 'text-red-600'
              ">
                {{ product.stock }} Unidades
              </span>
            </div>
          </div>
        </div>
        
        <div class="flex space-x-2">
          <button
            @click="editProduct(product)"
            class="flex-1 bg-slate-500 text-white py-2 px-3 rounded-md hover:bg-slate-700 transition-colors text-sm font-medium"
          >
            Editar
          </button>
          <button
            @click="deleteProduct(product.id)"
            class="flex-1 bg-red-400 text-white py-2 px-3 rounded-md hover:bg-red-600 transition-colors text-sm font-medium"
          >
            Eliminar
          </button>
        </div>
      </div>
    </div>
    
    <BaseModal
      :is-open="showModal"
      :title="editingProduct ? 'Editar Producto' : 'Crear Producto'"
      :loading="saving"
      @close="closeModal"
      @confirm="saveProduct"
    >
      <form @submit.prevent="saveProduct" class="space-y-4">
        <div>
          <label class="block text-sm font-medium text-gray-700 mb-1">Nombre</label>
          <input
            v-model="form.name"
            type="text"
            required
            class="w-full p-2 border border-gray-300 rounded-md focus:ring-primary-500 focus:border-primary-500"
          />
        </div>
        
        <div>
          <label class="block text-sm font-medium text-gray-700 mb-1">Descripcion</label>
          <textarea
            v-model="form.description"
            required
            rows="3"
            class="w-full p-2 border border-gray-300 rounded-md focus:ring-primary-500 focus:border-primary-500"
          ></textarea>
        </div>
        
        <div class="grid grid-cols-2 gap-4">
          <div>
            <label class="block text-sm font-medium text-gray-700 mb-1">Precio (RD$)</label>
            <div class="relative">
              <span class="absolute left-3 top-1/2 transform -translate-y-1/2 text-gray-500 font-medium">$</span>
              <input
                v-model.number="form.price"
                type="number"
                step="0.01"
                min="0"
                required
                class="w-full pl-8 pr-3 py-2 border border-gray-300 rounded-md focus:ring-primary-500 focus:border-primary-500"
                placeholder="0.00"
              />
            </div>
          </div>
          
          <div>
            <label class="block text-sm font-medium text-gray-700 mb-1">Stock</label>
            <input
              v-model.number="form.stock"
              type="number"
              min="0"
              required
              class="w-full p-2 border border-gray-300 rounded-md focus:ring-primary-500 focus:border-primary-500"
              placeholder="0"
            />
          </div>
        </div>
      </form>
    </BaseModal>
  </div>
</template>

<script setup lang="ts">
import { ref, onMounted } from 'vue';
import { Plus } from 'lucide-vue-next';
import * as productosService from '../Services/Productos/productosService';
import type { Product } from '../types';
import BaseModal from '../components/UI/BaseModal.vue';
import LoadingSpinner from '../components/UI/LoadingSpinner.vue';

const products = ref<Product[]>([]);
const loading = ref(false);
const saving = ref(false);
const showModal = ref(false);
const editingProduct = ref<Product | null>(null);

const form = ref({
  name: '',
  description: '',
  price: 0,
  stock: 0
});

const loadProducts = async () => {
  loading.value = true;
  try {
    const raw = await productosService.getAllProductos();
    products.value = raw.map(p => ({
      id:          p.id,
      name:        p.nombre,
      description: p.descripcion,
      price:       p.precio,
      stock:       p.stock
    }));
  } catch (error) {
    console.error('Error cargando productos:', error);
  } finally {
    loading.value = false;
  }
};

const openCreateModal = () => {
  editingProduct.value = null;
  form.value = { name: '', description: '', price: 0, stock: 0 };
  showModal.value = true;
};

const editProduct = (product: Product) => {
  editingProduct.value = product;
  form.value = { ...product };
  showModal.value = true;
};

const closeModal = () => {
  showModal.value = false;
  editingProduct.value = null;
};

const saveProduct = async () => {
  saving.value = true;
  try {
    const payload = {
      nombre:      form.value.name,
      descripcion: form.value.description,
      precio:      form.value.price,
      stock:       form.value.stock
    };

    if (editingProduct.value) {
      await productosService.updateProducto(editingProduct.value.id, payload);
    } else {
      await productosService.createProducto(payload);
    }
    await loadProducts();
    closeModal();
  } catch (error) {
    console.error('Error guardando producto:', error);
  } finally {
    saving.value = false;
  }
};

const deleteProduct = async (id: string) => {
  if (confirm('¿Estás seguro de querer eliminar este producto?')) {
    try {
      await productosService.deleteProducto(id);
      await loadProducts();
    } catch (error) {
      console.error('Error eliminando producto:', error);
    }
  }
};

onMounted(loadProducts);
</script>