import Vue from 'vue';
import App from './App.vue';
import router from "./router/index.js";
import store from "./store";
import axios from "./plugins/axios"
import vuetify from "./plugins/vuetify";
import Unicon from 'vue-unicons';
import { uniAirplay } from './icons.js'

Vue.config.productionTip = false


Unicon.add([uniAirplay])
Vue.use(Unicon)


new Vue({
  router,
  store,
  vuetify,
  axios,
  render: h => h(App)
}).$mount('#app')
