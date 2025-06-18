<template>
  <div class="p-6">
    <div class="flex justify-between items-center mb-6">
      <h1 class="text-3xl font-bold text-gray-900">Ventas</h1>
      <button
        @click="openCreateModal"
        class="bg-primary-600 text-white px-4 py-2 rounded-lg hover:bg-primary-700 transition-colors flex items-center"
      >
        <Plus class="w-4 h-4 mr-2" />
       Agregar venta
      </button>
    </div>
    
    <div class="grid grid-cols-1 lg:grid-cols-4 gap-6 mb-6">
      <div class="bg-white p-4 rounded-lg shadow-md">
        <p class="text-sm text-gray-600">Ventas totales</p>
        <p class="text-2xl font-bold text-gray-900">{{ sales.length }}</p>
      </div>
      <div class="bg-white p-4 rounded-lg shadow-md">
        <p class="text-sm text-gray-600">Ingresos totales</p>
        <p class="text-2xl font-bold text-gray-900">${{ totalRevenue.toLocaleString() }}</p>
      </div>
      <div class="bg-white p-4 rounded-lg shadow-md">
        <p class="text-sm text-gray-600">Venta promedio</p>
        <p class="text-2xl font-bold text-gray-900">${{ averageSale.toLocaleString() }}</p>
      </div>
      <div class="bg-white p-4 rounded-lg shadow-md">
        <p class="text-sm text-gray-600">Ventas de hoy</p>
        <p class="text-2xl font-bold text-gray-900">{{ todaySales }}</p>
      </div>
    </div>
    
    <div v-if="loading">
      <LoadingSpinner />
    </div>
    
    <div v-else class="bg-white rounded-lg shadow-md overflow-hidden">
      <div class="overflow-x-auto">
        <table class="min-w-full divide-y divide-gray-200">
          <thead class="bg-gray-50">
            <tr>
              <th class="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">Fecha</th>
              <th class="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">Cliente</th>
              <th class="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">Producto</th>
              <th class="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">Cantidad</th>
              <th class="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">Precio unico</th>
              <th class="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">Total</th>
            </tr>
          </thead>
          <tbody class="bg-white divide-y divide-gray-200">
            <tr v-for="sale in sales" :key="sale.id" class="hover:bg-gray-50">
              <td class="px-6 py-4 whitespace-nowrap">
                <div class="text-gray-900">{{ formatDate(sale.date) }}</div>
              </td>
              <td class="px-6 py-4 whitespace-nowrap">
                <div class="text-gray-900">{{ sale.customerName }}</div>
              </td>
              <td class="px-6 py-4 whitespace-nowrap">
                <div class="text-gray-900">{{ sale.productName }}</div>
              </td>
              <td class="px-6 py-4 whitespace-nowrap">
                <div class="text-gray-900">{{ sale.quantity }}</div>
              </td>
              <td class="px-6 py-4 whitespace-nowrap">
                <div class="text-gray-900">${{ sale.unitPrice.toLocaleString() }}</div>
              </td>
              <td class="px-6 py-4 whitespace-nowrap">
                <div class="font-medium text-gray-900">${{ sale.totalAmount.toLocaleString() }}</div>
              </td>
            </tr>
          </tbody>
        </table>
      </div>
    </div>
    

    <BaseModal
      :is-open="showModal"
      title=" Agregar una nueva venta"
      :loading="saving"
      @close="closeModal"
      @confirm="saveSale"
    >
      <form @submit.prevent="saveSale" class="space-y-4">
        <div>
          <label class="block text-sm font-medium text-gray-700 mb-1">Cliente</label>
          <select
            v-model="form.customerId"
            required
            class="w-full p-2 border border-gray-300 rounded-md focus:ring-primary-500 focus:border-primary-500"
          >
            <option value="">Seleccione un cliente</option>
            <option v-for="customer in customers" :key="customer.id" :value="customer.id">
              {{ customer.name }}
            </option>
          </select>
        </div>
        
        <div>
          <label class="block text-sm font-medium text-gray-700 mb-1">Producto</label>
          <select
            v-model="form.productId"
            required
            class="w-full p-2 border border-gray-300 rounded-md focus:ring-primary-500 focus:border-primary-500"
            @change="updateSelectedProduct"
          >
            <option value="">Seleccione un producto</option>
            <option v-for="product in products" :key="product.id" :value="product.id">
              {{ product.name }} - ${{ product.price }} (Stock: {{ product.stock }})
            </option>
          </select>
        </div>
        
        <div>
          <label class="block text-sm font-medium text-gray-700 mb-1">Cantidad</label>
          <input
            v-model.number="form.quantity"
            type="number"
            min="1"
            :max="selectedProduct?.stock || 999"
            required
            class="w-full p-2 border border-gray-300 rounded-md focus:ring-primary-500 focus:border-primary-500"
          />
          <p v-if="selectedProduct" class="text-sm text-gray-500 mt-1">
            Available stock: {{ selectedProduct.stock }}
          </p>
        </div>
        
        <div v-if="selectedProduct && form.quantity" class="bg-gray-50 p-4 rounded-lg">
          <div class="flex justify-between items-center">
            <span class="text-gray-700">Precio unico:</span>
            <span class="font-medium">${{ selectedProduct.price.toLocaleString() }}</span>
          </div>
          <div class="flex justify-between items-center mt-2">
            <span class="text-gray-700">Cantidad:</span>
            <span class="font-medium">{{ form.quantity }}</span>
          </div>
          <hr class="my-2">
          <div class="flex justify-between items-center">
            <span class="text-lg font-semibold text-gray-900">Total:</span>
            <span class="text-lg font-semibold text-primary-600">
              ${{ (selectedProduct.price * form.quantity).toLocaleString() }}
            </span>
          </div>
        </div>
      </form>
    </BaseModal>
  </div>
</template>

<script setup lang="ts">
import { ref, onMounted, computed } from 'vue';
import { Plus } from 'lucide-vue-next';
import { salesApi, productsApi, customersApi } from '../Services/api';
import type { Sale, Product, Customer } from '../types';
import BaseModal from '../components/UI/BaseModal.vue';
import LoadingSpinner from '../components/UI/LoadingSpinner.vue';

const sales = ref<Sale[]>([]);
const products = ref<Product[]>([]);
const customers = ref<Customer[]>([]);
const loading = ref(false);
const saving = ref(false);
const showModal = ref(false);

const form = ref({
  customerId: '',
  productId: '',
  quantity: 1
});

const selectedProduct = ref<Product | null>(null);

const totalRevenue = computed(() => 
  sales.value.reduce((sum, sale) => sum + sale.totalAmount, 0)
);

const averageSale = computed(() => 
  sales.value.length > 0 ? totalRevenue.value / sales.value.length : 0
);

const todaySales = computed(() => {
  const today = new Date().toISOString().split('T')[0];
  return sales.value.filter(sale => sale.date === today).length;
});

const loadData = async () => {
  loading.value = true;
  try {
    const [salesData, productsData, customersData] = await Promise.all([
      salesApi.getAll(),
      productsApi.getAll(),
      customersApi.getAll()
    ]);
    
    sales.value = salesData;
    products.value = productsData;
    customers.value = customersData;
  } catch (error) {
    console.error('Error cargando datos:', error);
  } finally {
    loading.value = false;
  }
};

const openCreateModal = () => {
  form.value = { customerId: '', productId: '', quantity: 1 };
  selectedProduct.value = null;
  showModal.value = true;
};

const closeModal = () => {
  showModal.value = false;
};

const updateSelectedProduct = () => {
  selectedProduct.value = products.value.find(p => p.id === form.value.productId) || null;
};

const saveSale = async () => {
  if (!selectedProduct.value) return;
  
  if (form.value.quantity > selectedProduct.value.stock) {
    alert('Insuficiente stock');
    return;
  }
  
  saving.value = true;
  try {
    await salesApi.create(form.value);
    await loadData();
    closeModal();
  } catch (error) {
    console.error('Error guardando ventas:', error);
  } finally {
    saving.value = false;
  }
};

const formatDate = (dateString: string) => {
  return new Date(dateString).toLocaleDateString();
};

onMounted(loadData);
</script>