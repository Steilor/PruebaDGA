<template>
  <div class="p-6">
    <h1 class="text-3xl font-bold text-gray-900 mb-8">Panel principal</h1>
    
    <div class="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-4 gap-6 mb-8">
      <div class="bg-white p-6 rounded-lg shadow-md">
        <div class="flex items-center justify-between">
          <div>
            <p class="text-sm text-gray-600">Productos totales</p>
            <p class="text-2xl font-bold text-gray-900">{{ stats.totalProducts }}</p>
          </div>
           <ChartBarIcon  class="w-8 h-8 text-gray-900" />
        </div>
      </div>
      
      <div class="bg-white p-6 rounded-lg shadow-md">
        <div class="flex items-center justify-between">
          <div>
            <p class="text-sm text-gray-600">Clientes totales</p>
            <p class="text-2xl font-bold text-gray-900">{{ stats.totalCustomers }}</p>
          </div>
          <UsersIcon class="w-8 h-8 text-gray-900" />
        </div>
      </div>
      
      <div class="bg-white p-6 rounded-lg shadow-md">
        <div class="flex items-center justify-between">
          <div>
            <p class="text-sm text-gray-600">Ventas totales</p>
            <p class="text-2xl font-bold text-gray-900">{{ stats.totalSales }}</p>
          </div>
           <ShoppingCartIcon class="w-8 h-8 text-gray-900" />
        </div>
      </div>
      
      <div class="bg-white p-6 rounded-lg shadow-md">
        <div class="flex items-center justify-between">
          <div>
            <p class="text-sm text-gray-600">Ingresos totales</p>
            <p class="text-2xl font-bold text-gray-900">${{ stats.totalRevenue.toLocaleString() }}</p>
          </div>
         <CurrencyDollarIcon class="w-8 h-8 text-gray-900" />
        </div>
      </div>
    </div>
    
    <div class="grid grid-cols-1 lg:grid-cols-2 gap-6">
      <div class="bg-white p-6 rounded-lg shadow-md">
        <h2 class="text-xl font-semibold text-gray-900 mb-4">Ventas recientes</h2>
        <div class="space-y-4">
          <div
            v-for="sale in recentSales"
            :key="sale.id"
            class="flex items-center justify-between p-3 bg-gray-50 rounded-lg"
          >
            <div>
              <p class="font-medium text-gray-900">{{ sale.productName }}</p>
              <p class="text-sm text-gray-600">{{ sale.customerName }}</p>
            </div>
            <div class="text-right">
              <p class="font-medium text-gray-900">${{ sale.totalAmount.toLocaleString() }}</p>
              <p class="text-sm text-gray-600">{{ formatDate(sale.date) }}</p>
            </div>
          </div>
        </div>
      </div>
      
      <div class="bg-white p-6 rounded-lg shadow-md">
        <h2 class="text-xl font-semibold text-gray-900 mb-4">Top Selling Products</h2>
        <div class="space-y-4">
          <div
            v-for="(product, index) in topSellingProducts"
            :key="product.productId"
             class="flex items-center justify-between p-3 bg-gray-100 rounded-lg border border-gray-200"
          >
            <div class="flex items-center">
              <div class="flex items-center justify-center w-8 h-8 bg-gray-600 text-gray-200 rounded-full text-sm font-bold mr-3">
                {{ index + 1 }}
              </div>
              <div>
                <p class="font-medium text-gray-900">{{ product.productName }}</p>
                <p class="text-sm text-gray-600">{{ product.totalQuantity }} units sold</p>
              </div>
            </div>
            <div class="text-right">
               <p class="font-medium text-gray-700">${{ product.totalRevenue.toLocaleString() }}</p>
              <p class="text-sm text-gray-600">Revenue</p>
            </div>
          </div>
          <div v-if="topSellingProducts.length === 0" class="text-center py-8 text-gray-500">
            <ShoppingCart class="w-12 h-12 mx-auto mb-2 text-gray-300" />
            <p>No sales data available</p>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script setup lang="ts">
import { ref, onMounted, computed } from 'vue';
import { Package, Users, ShoppingCart, DollarSign } from 'lucide-vue-next';
import {
  ChartBarIcon,
  UsersIcon,
  ShoppingCartIcon,
  CurrencyDollarIcon
} from '@heroicons/vue/24/outline';

import { productsApi, customersApi, salesApi } from '../Services/api';
import type { Product, Customer, Sale } from '../types';


const products = ref<Product[]>([]);
const customers = ref<Customer[]>([]);
const sales = ref<Sale[]>([]);

const stats = computed(() => ({
  totalProducts: products.value.length,
  totalCustomers: customers.value.length,
  totalSales: sales.value.length,
  totalRevenue: sales.value.reduce((sum, sale) => sum + sale.totalAmount, 0)
}));

const recentSales = computed(() => 
  sales.value
    .sort((a, b) => new Date(b.date).getTime() - new Date(a.date).getTime())
    .slice(0, 5)
);

const topSellingProducts = computed(() => {
  const productSales = new Map();
  
  sales.value.forEach(sale => {
    const key = sale.productId;
    if (productSales.has(key)) {
      const existing = productSales.get(key);
      existing.totalQuantity += sale.quantity;
      existing.totalRevenue += sale.totalAmount;
    } else {
      productSales.set(key, {
        productId: sale.productId,
        productName: sale.productName,
        totalQuantity: sale.quantity,
        totalRevenue: sale.totalAmount
      });
    }
  });
  
  return Array.from(productSales.values())
    .sort((a, b) => b.totalRevenue - a.totalRevenue)
    .slice(0, 5);
});

const formatDate = (dateString: string) => {
  return new Date(dateString).toLocaleDateString();
};

onMounted(async () => {
  try {
    products.value = await productsApi.getAll();
    customers.value = await customersApi.getAll();
    sales.value = await salesApi.getAll();
  } catch (error) {
    console.error('Error loading dashboard data:', error);
  }
});
</script>