import { createRouter, createWebHistory } from 'vue-router'
import Home from '../views/Home.vue'

import ProductDetails from '../components/ProductDetails.vue'
import CreateProduct from '../components/CreateProduct.vue'


const routes =[
  {
    path: '/',
    name: 'Home',
    component: Home
  },
  {
    path: '/login',
    name: 'Login',
    component: function () {
      return import(/* webpackChunkName: "about" */ '../views/Login.vue')}
  },
  {
    path: '/register',
    name: 'Register',
    component: function () {
      return import(/* webpackChunkName: "about" */ '../views/Register.vue')}
  },
  {
    path: '/about',
    name: 'About',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import(/* webpackChunkName: "about" */ '../views/About.vue')
  },
  {
    path: '/products',
    name: 'Products',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import(/* webpackChunkName: "about" */ '../views/ProductsOverview.vue')
  },
  {
    path: "/products/:id",
    name: "ProductDetails",
    props: true,
    component: ProductDetails
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    // component: () => import(/* webpackChunkName: "about" */ '../components/ProductInfo.vue')
  },
  {
    path: '/product/create',
    name: 'CreateProduct',
    component: CreateProduct
  },
  {
    path: '/shoppingcart',
    name: 'Shoppingcart',
    component: function () {
      return import(/* webpackChunkName: "about" */ '../views/ShoppingCartView.vue')},
    props: true
  },
  {
    path: '/order',
    name: 'Order',
    component: function () {
      return import(/* webpackChunkName: "about" */ '../views/Order.vue')},
    props: true
  },
  {
    path: '/ordersucceed',
    name: 'Order Succeed',
    component: function () {
      return import(/* webpackChunkName: "about" */ '../views/OrderSucceed.vue')},
    props: true
  },
  {
    path: '/userorders',
    name: 'Personal Orders',
    component: function () {
      return import(/* webpackChunkName: "about" */ '../views/UserOrder.vue')},
    props: true
  }
]

const router = createRouter({
  history: createWebHistory(),
  routes
})

export default router
