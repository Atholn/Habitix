<template>
  <div class="home">
    <v-container fluid fill-height>
     <div style="width: 100%; text-align: center;"> Hello in Habitix!</div>
     <div style="width: 100%; text-align: center;"> 
       <example/>
     </div>
     <div style="width: 100%; text-align: center;">
          <transition
          enter-active-class="animate__animated animate__fadeInDown"
          leave-active-class="animate__animated animate__fadeOutUp"
          >
            <img v-if="showImage" alt="Vue logo" src="../assets/logo.png" />
          </transition>
     </div>
     
    </v-container>
  </div>
</template>

<script>
import example from "../Animations/example"
import 'animate.css';

export default {
  name: "Home",
  components: {
    example,
  },
  data() {
    return {
      icons: ["mdi-facebook", "mdi-twitter", "mdi-linkedin", "mdi-instagram"],
      loading: false,
      showImage: false
    };
  },
  mounted() {
    this.activate();
  },
  methods: {
     activate() {
    setTimeout(() => this.showImage = true, 500);
  }
  }
};
</script>



