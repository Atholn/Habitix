<template>

  <div class="home">
    <v-container fluid fill-height>
     Hello in Habitix!
    </v-container>


  </div>
</template>

<script>


//import Nav from './Nav.vue';

export default {
  name: "Home",
  components: {
    // Nav

  },
  data() {
    return {
      icons: ["mdi-facebook", "mdi-twitter", "mdi-linkedin", "mdi-instagram"],
      loading: false
    };
  },
  mounted: {
  },
  methods: {
  }

};
</script>



