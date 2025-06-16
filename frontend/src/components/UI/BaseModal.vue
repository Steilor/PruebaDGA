<template>

<Teleport to="body">
    <div
      v-if="isOpen"
      class="fixed inset-0 bg-black bg-opacity-50 flex items-center justify-center z-50"
      @click="closeModal"
    >
      <div
        class="bg-white rounded-lg p-6 max-w-md w-full mx-4 transform transition-all duration-300 scale-100"
        @click.stop
      >
        <div class="flex justify-between items-center mb-4">
          <h3 class="text-lg font-semibold text-gray-900">{{ title }}</h3>
          <button
            @click="closeModal"
            class="text-gray-400 hover:text-gray-600 transition-colors"
          >
            <X class="w-6 h-6" />
          </button>
        </div>
        
        <slot></slot>
        
        <div class="flex justify-end space-x-3 mt-6">
          <button
            @click="closeModal"
            class="px-4 py-2 text-gray-600 hover:text-gray-800 transition-colors"
          >
            Cancel
          </button>
          <button
            @click="$emit('confirm')"
            class="px-4 py-2 bg-primary-600 text-white rounded-md hover:bg-primary-700 transition-colors"
            :disabled="loading"
          >
            <span v-if="loading" class="flex items-center">
              <div class="animate-spin rounded-full h-4 w-4 border-b-2 border-white mr-2"></div>
              Loading...
            </span>
            <span v-else>{{ confirmText }}</span>
          </button>
        </div>
      </div>
    </div>
  </Teleport>
</template>

<script setup lang="ts">
import { X } from 'lucide-vue-next';

interface Props {
  isOpen: boolean;
  title: string;
  confirmText?: string;
  loading?: boolean;
}

withDefaults(defineProps<Props>(), {
  confirmText: 'Confirm',
  loading: false
});

const emit = defineEmits<{
  close: [];
  confirm: [];
}>();

const closeModal = () => {
  emit('close');
};
</script>