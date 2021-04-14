<template>
  <v-app>  
    <v-main>
      <Nav />
      <router-view />
    </v-main>
  </v-app>
</template>



<script>
import Nav from "./views/Nav.vue"

export default {
  name: "App",
  data: () => ({
    //
  }),
   components: {
    Nav

  },
};
</script>
