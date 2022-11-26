import Vue from "vue";
import VueRouter from "vue-router";
import Home from "../views/Home.vue";
import Dashboard from "../components/Dashboard.vue";
import Habitix from "../views/Habitix.vue";
import Login from "../views/Login.vue";
import Register from "../views/Register.vue";
import HelloWorld from "../components/HelloWorld.vue"
import store from "../store/index"


const ifNotAuthenticated = (to, from, next) => {
    if (!store.getters.isAuthenticated) {
      next();
      return;
    }
    next('/');
  };
  
  const ifAuthenticated = (to, from, next) => {
    if (store.getters.isAuthenticated) {
      next();
      return;
    }
    next('/Login');
  };

Vue.use(VueRouter);

const routes = [
    {
      path: "/",
      name: "Home",
      component: Home,
    },
    {
        path: "/dashboard",
        name: "Dashboard",
        component: Dashboard,
        beforeEnter: ifAuthenticated,
    },
    {
        path: "/login",
        name: "Login",
        component: Login,
    },
    {
        path: "/Register",
        name: "Register",
        component: Register,
    }, 
    //-----
    {
        path: "/habitix",
        name: "Habitix",
        component: Habitix,
    },
    {
      path: "/hello",
      name: "hello",
      component: HelloWorld,
    },

    // otherwise redirect to home
    { path: '*', redirect: '/' }
];

const router = new VueRouter({
    routes
  });
  
export default router;
  