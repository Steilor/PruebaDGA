<template>
  <div class="p-6">
    <div class="flex justify-between items-center mb-6">
      <h1 class="text-3xl font-bold text-gray-900">Clientes</h1>
      <button
        @click="openCreateModal"
        class="bg-primary-600 text-white px-4 py-2 rounded-lg hover:bg-primary-700 transition-colors flex items-center"
      >
        <Plus class="w-4 h-4 mr-2" />
        Agregar clientes
      </button>
    </div>
    
    <div v-if="loading">
      <LoadingSpinner />
    </div>
    
    <div v-else class="bg-white rounded-lg shadow-md overflow-hidden">
      <div class="overflow-x-auto">
        <table class="min-w-full divide-y divide-gray-200">
          <thead class="bg-gray-50">
            <tr>
              <th class="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">Nombre</th>
              <th class="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">Email</th>
              <th class="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">Telefono</th>
              <th class="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">Direccion</th>
              <th class="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">Creado</th>
              <th class="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">Acciones</th>
            </tr>
          </thead>
          <tbody class="bg-white divide-y divide-gray-200">
            <tr v-for="customer in customers" :key="customer.id" class="hover:bg-gray-50">
              <td class="px-6 py-4 whitespace-nowrap">
                <div class="font-medium text-gray-900">{{ customer.name }}</div>
              </td>
              <td class="px-6 py-4 whitespace-nowrap">
                <div class="text-gray-600">{{ customer.email }}</div>
              </td>
              <td class="px-6 py-4 whitespace-nowrap">
                <div class="text-gray-600">{{ customer.phone }}</div>
              </td>
              <td class="px-6 py-4 whitespace-nowrap">
                <div class="text-gray-600 max-w-xs truncate">{{ customer.address }}</div>
              </td>
              <td class="px-6 py-4 whitespace-nowrap">
                <div class="text-gray-600">{{ formatDate(customer.createdAt) }}</div>
              </td>
              <td class="px-6 py-4 whitespace-nowrap text-sm font-medium">
                <button
                  @click="editCustomer(customer)"
                  class="text-secondary-600 hover:text-secondary-900 mr-3"
                >
                  Edit
                </button>
                <button
                  @click="deleteCustomer(customer.id)"
                  class="text-red-600 hover:text-red-900"
                >
                  Delete
                </button>
              </td>
            </tr>
          </tbody>
        </table>
      </div>
    </div>
    
    <!-- Create/Edit Modal -->
    <BaseModal
      :is-open="showModal"
      :title="editingCustomer ? 'Edit Customer' : 'Create Customer'"
      :loading="saving"
      @close="closeModal"
      @confirm="saveCustomer"
    >
      <form @submit.prevent="saveCustomer" class="space-y-4">
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
          <label class="block text-sm font-medium text-gray-700 mb-1">Email</label>
          <input
            v-model="form.email"
            type="email"
            required
            class="w-full p-2 border border-gray-300 rounded-md focus:ring-primary-500 focus:border-primary-500"
          />
        </div>
        
        <div>
          <label class="block text-sm font-medium text-gray-700 mb-1">Telefono</label>
          <input
            v-model="form.phone"
            type="tel"
            required
            class="w-full p-2 border border-gray-300 rounded-md focus:ring-primary-500 focus:border-primary-500"
          />
        </div>
        
        <div>
          <label class="block text-sm font-medium text-gray-700 mb-1">Direccion</label>
          <textarea
            v-model="form.address"
            required
            rows="3"
            class="w-full p-2 border border-gray-300 rounded-md focus:ring-primary-500 focus:border-primary-500"
          ></textarea>
        </div>
      </form>
    </BaseModal>
  </div>
</template>

<script setup lang="ts">
import { ref, onMounted } from 'vue';
import { Plus } from 'lucide-vue-next';
import { customersApi } from '../Services/api';
import type { Customer } from '../types';
import BaseModal from '../components/UI/BaseModal.vue';
import LoadingSpinner from '../components/UI/LoadingSpinner.vue';

const customers = ref<Customer[]>([]);
const loading = ref(false);
const saving = ref(false);
const showModal = ref(false);
const editingCustomer = ref<Customer | null>(null);

const form = ref({
  name: '',
  email: '',
  phone: '',
  address: ''
});

const loadCustomers = async () => {
  loading.value = true;
  try {
    customers.value = await customersApi.getAll();
  } catch (error) {
    console.error('Error loading customers:', error);
  } finally {
    loading.value = false;
  }
};

const openCreateModal = () => {
  editingCustomer.value = null;
  form.value = { name: '', email: '', phone: '', address: '' };
  showModal.value = true;
};

const editCustomer = (customer: Customer) => {
  editingCustomer.value = customer;
  form.value = { ...customer };
  showModal.value = true;
};

const closeModal = () => {
  showModal.value = false;
  editingCustomer.value = null;
};

const saveCustomer = async () => {
  saving.value = true;
  try {
    if (editingCustomer.value) {
      await customersApi.update(editingCustomer.value.id, form.value);
    } else {
      await customersApi.create(form.value);
    }
    await loadCustomers();
    closeModal();
  } catch (error) {
    console.error('Error saving customer:', error);
  } finally {
    saving.value = false;
  }
};

const deleteCustomer = async (id: string) => {
  if (confirm('Are you sure you want to delete this customer?')) {
    try {
      await customersApi.delete(id);
      await loadCustomers();
    } catch (error) {
      console.error('Error deleting customer:', error);
    }
  }
};

const formatDate = (dateString: string) => {
  return new Date(dateString).toLocaleDateString();
};

onMounted(loadCustomers);
</script>