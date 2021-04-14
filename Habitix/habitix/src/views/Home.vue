<template>
  <div class="home">
    <v-container fluid fill-height>
     <div style="width: 100%; text-align: center;"> Hello in Habitix!</div>
     <div>
       <example/>
     </div>
     
    </v-container>
  </div>
</template>

<script>
import example from "../Animations/example"

export default {
  name: "Home",
  components: {
    example,
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



