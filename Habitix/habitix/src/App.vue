<template>
  <v-app>  
    <v-main>
      <Nav/>
      <transition
 mode="out-in"
 enter-active-class="animate__animated animate__fadeIn"
 leave-active-class="animate__animated animate__fadeOut"
>
  <router-view />
</transition>
      <Fot/>
    </v-main>
  </v-app>
</template>



<script>
import Nav from "./views/Nav.vue"
import Fot from "./views/Fot.vue"
import 'animate.css';
export default {
  name: "App",
  data: () => ({
    //
  }),
   components: {
    Nav,
    Fot

  },
};
</script>

