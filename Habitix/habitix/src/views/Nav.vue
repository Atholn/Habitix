<template>
  <div class="home">
      <nav> 
        <v-btn 
        elevation="24"
        to="Home" 
        :loading="loading"
        >
          <v-icon>mdi-home</v-icon>
        </v-btn>
        
        <v-btn 
        elevation="24"
        to="dashboard" 
        :loading="loading"
        >
          <v-icon>mdi-widgets</v-icon>
        </v-btn>
      

        <!-- <div   v-if="" > -->
          <v-btn v-if="!this.$store.getters.isAuthenticated" 
        elevation="24"
        to="Login"
        >
          <v-icon>mdi-login</v-icon>
        </v-btn> 
        

        

        <v-btn  v-else
        elevation="24"
        to="Home" 
        >
          <v-icon>mdi-logout</v-icon>
        </v-btn>
      </nav>

  </div>
</template>

<script>
export default {
  name: "Nav",
  components: {

  },
  data() {
    return {
      icons: ["mdi-facebook", "mdi-twitter", "mdi-linkedin", "mdi-instagram"],
      loading: false
    };
  },
};
</script>



