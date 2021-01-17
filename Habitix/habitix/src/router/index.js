import Vue from "vue";
import VueRouter from "vue-router";
import Home from "../components/Home.vue"
import Dashboard from "../components/Dashboard.vue"

Vue.use(VueRouter);
const routes = [
    {
      path: "/",
      name: "Home",
      component: Home,
    },
    {
        path: "/",
        name: "Dashboard",
        component: Dashboard,
    }
];


const router = new VueRouter({
    routes
  });
  
  export default router;
  