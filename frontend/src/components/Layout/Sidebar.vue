<template>
   <div class="w-64 bg-white shadow-lg h-screen fixed left-0 top-0 z-30 flex flex-col">
    <div class="p-6 border-b border-gray-200">
      <h1 class="text-2xl font-bold text-gray-800 mb-2">Panel del admin</h1>
      <div class="w-12 h-0.5 bg-primary-600 rounded-full"></div>
      <p class="text-sm text-gray-500 mt-2">Panel de gestión</p>
    </div>
    
    <nav class="mt-6 flex-1">
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

    <div class="border-t border-gray-200 p-4 bg-gray-50">
      <div class="space-y-3">
        <div class="flex items-center justify-center space-x-8">
          <a 
            href="https://github.com/Steilor" 
            target="_blank" 
            rel="noopener noreferrer"
            class="flex items-center text-gray-600 hover:text-gray-800 transition-colors duration-200 transform hover:scale-110"
            title="GitHub Profile"
          >
            <Github class="w-7 h-7" />
          </a>
          <a 
            href="https://www.linkedin.com/in/esteilor-paniagua-mateo-4772b2267" 
            target="_blank" 
            rel="noopener noreferrer"
            class="flex items-center text-gray-600 hover:text-blue-600 transition-colors duration-200 transform hover:scale-110"
            title="LinkedIn Profile"
          >
            <Linkedin class="w-7 h-7" />
          </a>
        </div>

        <div class="pt-2 border-t border-gray-200">
          <p class="text-xs text-gray-400 text-center">Version 1.0.0 © 2024 Panel de gestión</p>
        </div>
      </div>
    </div>
  </div>
</template>

<script setup lang="ts">
import { LayoutDashboard, Package, Users, ShoppingCart, Github, Linkedin } from 'lucide-vue-next';

const menuItems = [
  { name: 'Dashboard', path: '/', icon: LayoutDashboard },
  { name: 'Productos', path: '/products', icon: Package },
  { name: 'Clientes', path: '/customers', icon: Users },
  { name: 'Ventas', path: '/sales', icon: ShoppingCart }
];
</script>