import Vue from 'vue'
import App from './App.vue'
import VueRouter from 'vue-router'
import axios from 'axios'

axios.defaults.baseURL = 'https://localhost:5001/api'

import * as VueGoogleMaps from 'vue2-google-maps'

import Vuetify from 'vuetify'
import 'vuetify/dist/vuetify.min.css'
import 'material-design-icons-iconfont/dist/material-design-icons.css'

Vue.use(Vuetify);

Vue.use(VueGoogleMaps, {
  load: {
    key: 'AIzaSyCMT5haqRL9FLLw-CvdxmhbPuZLCu7WLR8',
    libraries: 'places'
  }
})

Vue.config.productionTip = false;

Vue.use(VueRouter);

import Markets from './views/Markets.vue'
import Home from './views/Home.vue'
import Farms from './views/Farms.vue'
import Vendors from './views/Vendors.vue'

const router = new VueRouter({
    routes: [
      { path: "/", component: Home },
      { path: "/markets", component: Markets },
      { path: "/farms", component: Farms },
      { path: "/vendors", component: Vendors }
    ]
});

new Vue({
  router,
  render: h => h(App)
}).$mount('#app');