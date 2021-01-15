<template>
  <div class="home">
    <v-toolbar dark>
      <h1 class="orange--text">habitix</h1>
      <v-spacer />
      <v-btn color="pink" rounded x-large to="Login">Login</v-btn>
    </v-toolbar>
    <v-container fluid fill-height>
      habitix
    </v-container>
  </div>
</template>

<script>


export default {
  name: "Home",
  components: {
   
  },
  data() {
    return {
      icons: ["mdi-facebook", "mdi-twitter", "mdi-linkedin", "mdi-instagram"]
    };
  }
};
</script>