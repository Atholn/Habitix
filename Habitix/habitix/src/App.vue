<template>
  <v-app>  
    <v-main>
      <Nav/>
      <router-view />
      <Fot/>
    </v-main>
  </v-app>
</template>



<script>
import Nav from "./views/Nav.vue"
import Fot from "./views/Fot.vue"

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
