import { defineConfig } from 'vite'
import vue from '@vitejs/plugin-vue'


export default defineConfig({
  plugins: [vue()],
    server: {
    port: 5173,
    proxy: {
      //backend
      '/api': {
        target: 'https://localhost:5001',
        changeOrigin: true,
        secure: false
      }
    },
    css: {
    postcss: './postcss.config.js',
  }
  }
})
