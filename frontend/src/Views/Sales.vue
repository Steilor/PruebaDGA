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
        <p class="text-2xl font-bold text-gray-900">${{ (totalRevenue || 0).toLocaleString() }}</p>
      </div>
      <div class="bg-white p-4 rounded-lg shadow-md">
        <p class="text-sm text-gray-600">Venta promedio</p>
        <p class="text-2xl font-bold text-gray-900">${{ (averageSale || 0).toLocaleString() }}</p>
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
              <th class="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase">Fecha</th>
              <th class="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase">Cliente</th>
              <th class="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase">Producto</th>
              <th class="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase">Cantidad</th>
              <th class="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase">Precio unitario</th>
              <th class="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase">Total</th>
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
                <div class="text-gray-900">${{ (sale.unitPrice || 0).toLocaleString() }}</div>
              </td>
              <td class="px-6 py-4 whitespace-nowrap">
                <div class="font-medium text-gray-900">${{ (sale.totalAmount || 0).toLocaleString() }}</div>
              </td>
            </tr>
          </tbody>
        </table>
      </div>
    </div>

 
    <BaseModal
      :is-open="showModal"
      title="Agregar nueva venta"
      :loading="saving"
      :on-close="closeModal"
      :on-confirm="saveSale"
    >
      <form @submit.prevent="saveSale" class="space-y-4">
        <div>
          <label class="block text-sm font-medium text-gray-700 mb-1">Cliente</label>
          <select
            v-model="form.clientId"
            required
            class="w-full p-2 border rounded focus:ring-primary-500 focus:border-primary-500"
          >
            <option value="">Seleccione un cliente</option>
            <option v-for="c in customers" :key="c.id" :value="c.id">
              {{ c.name }}
            </option>
          </select>
        </div>

        <div>
          <label class="block text-sm font-medium text-gray-700 mb-1">Producto</label>
          <select
            v-model="form.productId"
            required
            @change="updateSelectedProduct"
            class="w-full p-2 border rounded focus:ring-primary-500 focus:border-primary-500"
          >
            <option value="">Seleccione un producto</option>
            <option v-for="p in products" :key="p.id" :value="p.id">
              {{ p.name }} — ${{ p.price}} (Stock: {{ p.stock }})
            </option>
          </select>
        </div>

        <div>
          <label class="block text-sm font-medium text-gray-700 mb-1">Cantidad</label>
          <input
            v-model.number="form.quantity"
            type="number"
            min="1"
            :max="selectedProduct?.stock || 1"
            required
            class="w-full p-2 border rounded focus:ring-primary-500 focus:border-primary-500"
          />
          <p v-if="selectedProduct" class="text-sm text-gray-500 mt-1">
            Disponible: {{ selectedProduct.stock }}
          </p>
        </div>

        <div v-if="selectedProduct && form.quantity" class="bg-gray-50 p-4 rounded-lg">
          <div class="flex justify-between">
            <span>Precio unitario:</span>
            <span class="font-medium">${{ (selectedProduct?.price || 0).toLocaleString() }}</span>
          </div>
          <div class="flex justify-between mt-2">
            <span>Cantidad:</span>
            <span class="font-medium">{{ form.quantity }}</span>
          </div>
          <hr class="my-2" />
          <div class="flex justify-between">
            <span>Total:</span>
            <span class="text-lg font-semibold text-primary-600">
              ${{ (selectedProduct.price * form.quantity) }}
            </span>
          </div>
        </div>
      </form>
    </BaseModal>
  </div>
</template>

<script setup lang="ts">import { ref, onMounted, computed } from 'vue';
import { Plus } from 'lucide-vue-next';
import * as ventasService from '../Services/Ventas/ventasService';
import * as productosService from '../Services/Productos/productosService';
import * as clientesService from '../Services/Clientes/clientesService';
import type { Sale, Product, Customer } from '../types';
import BaseModal from '../components/UI/BaseModal.vue';
import LoadingSpinner from '../components/UI/LoadingSpinner.vue';

const sales     = ref<Sale[]>([]);
const products  = ref<Product[]>([]);
const customers = ref<Customer[]>([]);
const loading   = ref(false);
const saving    = ref(false);
const showModal = ref(false);


const form = ref({
  clientId: '' as string,
  productId: '' as string,
  quantity: 1
});

const selectedProduct = ref<Product | null>(null);

const totalRevenue = computed(() =>
  sales.value.reduce((sum, s) => sum + s.totalAmount, 0)
);
const averageSale = computed(() =>
  sales.value.length ? totalRevenue.value / sales.value.length : 0
);
const todaySales = computed(() => {
  const today = new Date().toISOString().split('T')[0];
  return sales.value.filter(s => s.date.startsWith(today)).length;
});

async function loadData() {
  loading.value = true;
  try {
    // Trae datos crudos
    const [sv, pr, cl] = await Promise.all([
      ventasService.getAllVentas(),
      productosService.getAllProductos(),
      clientesService.getAllClientes()
    ]);

    sales.value = sv.map(v => ({
      id: v.id,
      date: v.date,
      customerName: v.nombreCliente,
      productName: v.nombreProducto,
      quantity: v.cantidad,
      unitPrice: v.precioUnico,
      totalAmount: v.totalAmount
    }));

    products.value  = pr;
    customers.value = cl;
  } catch (e) {
    console.error(e);
  } finally {
    loading.value = false;
  }
}

function openCreateModal() {
  form.value = { clientId: '', productId: '', quantity: 1 };
  selectedProduct.value = null;
  showModal.value = true;
}

function closeModal() {
  showModal.value = false;
}

function updateSelectedProduct() {
  selectedProduct.value =
    products.value.find(p => p.id === form.value.productId) || null;
}

async function saveSale() {
  if (!form.value.clientId || !form.value.productId) return;
  saving.value = true;
  try {
    await ventasService.createVenta({
      clienteId: form.value.clientId,
      productoId: form.value.productId,
      cantidad: form.value.quantity,
      precioUnico: selectedProduct.value?.price || 0
    });
    await loadData();
    closeModal();
  } catch (err) {
    console.error(err);
  } finally {
    saving.value = false;
  }
}
function formatDate(iso: string) {
  return new Date(iso).toLocaleDateString();
}

onMounted(loadData);
</script>