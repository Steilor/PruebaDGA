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
        class="bg-white p-6 rounded-lg shadow-md hover:shadow-lg transition-shadow"
      >
        <h3 class="text-lg font-semibold text-gray-900 mb-2">{{ product.name }}</h3>
        <p class="text-gray-600 mb-4">{{ product.description }}</p>
        
        <div class="flex justify-between items-center mb-4">
          <span class="text-2xl font-bold text-primary-600">${{ product.price.toLocaleString() }}</span>
          <span class="text-sm text-gray-500">Stock: {{ product.stock }}</span>
        </div>
        
        <div class="flex space-x-2">
          <button
            @click="editProduct(product)"
            class="flex-1 bg-secondary-600 text-white py-2 px-3 rounded-md hover:bg-secondary-700 transition-colors text-sm"
          >
            Editar
          </button>
          <button
            @click="deleteProduct(product.id)"
            class="flex-1 bg-red-600 text-white py-2 px-3 rounded-md hover:bg-red-700 transition-colors text-sm"
          >
            Eliminar
          </button>
        </div>
      </div>
    </div>
    
    <!-- Create/Edit Modal -->
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
            <label class="block text-sm font-medium text-gray-700 mb-1">Precio</label>
            <input
              v-model.number="form.price"
              type="number"
              step="0.01"
              min="0"
              required
              class="w-full p-2 border border-gray-300 rounded-md focus:ring-primary-500 focus:border-primary-500"
            />
          </div>
          
          <div>
            <label class="block text-sm font-medium text-gray-700 mb-1">Stock</label>
            <input
              v-model.number="form.stock"
              type="number"
              min="0"
              required
              class="w-full p-2 border border-gray-300 rounded-md focus:ring-primary-500 focus:border-primary-500"
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
import { productsApi } from '../Services/api';
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
    products.value = await productsApi.getAll();
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
    if (editingProduct.value) {
      await productsApi.update(editingProduct.value.id, form.value);
    } else {
      await productsApi.create(form.value);
    }
    await loadProducts();
    closeModal();
  } catch (error) {
    console.error('Error guardando productos:', error);
  } finally {
    saving.value = false;
  }
};

const deleteProduct = async (id: string) => {
  if (confirm('Estas seguro de querer eliminar este producto?')) {
    try {
      await productsApi.delete(id);
      await loadProducts();
    } catch (error) {
      console.error('Error eliminando product:', error);
    }
  }
};

onMounted(loadProducts);
</script>