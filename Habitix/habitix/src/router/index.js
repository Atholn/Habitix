import Vue from "vue";
import VueRouter from "vue-router";
import Home from "../views/Home.vue"
import Dashboard from "../components/Dashboard.vue"
import Profile from "../views/Profile.vue"
import Habitix from "../views/Habitix.vue"
//  import login from "../components/Auth/Login.vue"
// import axios from 'axios'
// import RegisterPage from "../register/RegisterPage.vue"


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
    },
    {
        path: "/habitix",
        name: "Habitix",
        component: Habitix,
    },
    // {
    //     path: "/login",
    //     name: "Login",
    //     component: login,
    // },
    // {
    //     path: "/Register",
    //     name: "Register",
    //     component: RegisterPage,
    // }, 

       // otherwise redirect to home
    { path: '*', redirect: '/' }
];

const router = new VueRouter({
    routes
  });
  
export default router;
  