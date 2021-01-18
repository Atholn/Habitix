<template>
  <div class="home">
    <v-toolbar dark>
      <h1 class="orange--text">habitix </h1>
      <router-link to="/habitix"> Habitix </router-link>
          <router-view />
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



<style scoped>
h3 {
  margin: 40px 0 0;
}
ul {
  list-style-type: none;
  padding: 0;
}
li {
  display: inline-block;
  margin: 0 10px;
}
a {
  color: #42b983;
}
</style>