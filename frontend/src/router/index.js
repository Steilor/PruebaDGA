import { createRouter, createWebHistory } from 'vue-router';
import ProductList from '../views/ProductList.vue';
import ProductForm from '../views/ProductForm.vue';
import ProductDetail from '../views/ProductDetail.vue';

const routes = [
  { path: '/', component: ProductList },
  { path: '/new', component: ProductForm },
  { path: '/edit/:id', component: ProductForm, props: true },
  { path: '/detail/:id', component: ProductDetail, props: true },
];

const router = createRouter({
  history: createWebHistory(),
  routes,
});

export default router;