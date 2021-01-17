import Vue from "vue";
import VueRouter from "vue-router";
import Home from "../views/Home.vue"
import Dashboard from "../components/Dashboard.vue"
import Profile from "../views/Profile.vue"

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
    },
    {
        path: "/profile",
        name: "Profile",
        component: Profile,
    }
];


const router = new VueRouter({
    routes
  });
  
  export default router;
  