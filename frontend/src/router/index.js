import { createRouter, createWebHistory } from 'vue-router';
import Dashboard from '../Views/Dashboard.vue';
import Products from '../Views/Products.vue';
import Customers from '../views/Customers.vue';
import Sales from '../Views/Sales.vue';

const routes = [
  {
    path: '/',
    name: 'Dashboard',
    component: Dashboard
  },
  {
    path: '/products',
    name: 'Products',
    component: Products
  },
  {
    path: '/customers',
    name: 'Customers',
    component: Customers
  },
  {
    path: '/sales',
    name: 'Sales',
    component: Sales
  }
];

const router = createRouter({
  history: createWebHistory(),
  routes
});

export default router;