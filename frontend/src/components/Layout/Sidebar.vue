<template>
  <div class="w-64 bg-white shadow-lg h-screen fixed left-0 top-0 z-30">
    <div class="p-6">
      <h1 class="text-2xl font-bold text-gray-800">Panel del admin</h1>
    </div>
    
    <nav class="mt-6">
      <router-link
        v-for="item in menuItems"
        :key="item.name"
        :to="item.path"
        class="flex items-center px-6 py-3 text-gray-700 hover:bg-primary-50 hover:text-primary-600 transition-colors duration-200 border-r-4 border-transparent hover:border-primary-500"
        :class="{ 'bg-primary-50 text-primary-600 border-primary-500': $route.path === item.path }"
      >
        <component :is="item.icon" class="w-5 h-5 mr-3" />
        {{ item.name }}
      </router-link>
    </nav>
  </div>
</template>

<script setup lang="ts">
import { LayoutDashboard, Package, Users, ShoppingCart } from 'lucide-vue-next';

const menuItems = [
  { name: 'Dashboard', path: '/', icon: LayoutDashboard },
  { name: 'Productos', path: '/products', icon: Package },
  { name: 'Clientes', path: '/customers', icon: Users },
  { name: 'Ventas', path: '/sales', icon: ShoppingCart }
];
</script>