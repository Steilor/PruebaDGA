<template>
  <div class="min-h-screen bg-gray-100">
    <Sidebar />
    <div class="ml-64">
      <router-view />
    </div>
  </div>
</template>

<script setup lang="ts">
import Sidebar from './components/Layout/Sidebar.vue';
</script>