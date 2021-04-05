import Vue from "vue";
import VueRouter from "vue-router";
import Home from "../views/Home.vue";
import Dashboard from "../components/Dashboard.vue";
import Profile from "../views/Test/Profile.vue";
import Habitix from "../views/Habitix.vue";
import Login from "../views/Login.vue";
import Register from "../views/Register.vue";
import store from "../store/index"
import CreateNewAccount from "../views/CreateNewAccount.vue";
import LoginToAccount from "../views/LoginToAccount.vue"

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
        path: "/profile",
        name: "Profile",
        component: Profile,
    },
    {
        path: "/habitix",
        name: "Habitix",
        component: Habitix,
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
    // {
    //   path: "/CreateNewAccount",
    //   name: "CreateNewAccount",
    //   component: CreateNewAccount,
    // },
    // {
    //   path: "/LoginToAccount",
    //   name: "LoginToAccount",
    //   component: LoginToAccount,
    // },

    // otherwise redirect to home
    { path: '*', redirect: '/' }
];

const router = new VueRouter({
    routes
  });
  
export default router;
  