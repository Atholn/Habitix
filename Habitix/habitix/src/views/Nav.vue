<template>
  <div class="home">
      <nav>
          <v-row> 
              <v-col style="text-align: left; color: blue; font-size:30px" >  Habitix     </v-col>
              <v-col style="text-align: right; color: blue;">        
                  
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
      
          <v-btn v-if="!this.$store.getters.isAuthenticated" 
        elevation="24"
        to="Login"
        >
          <v-icon>mdi-login</v-icon>
        </v-btn> 
        

        

        <v-btn  v-else
        elevation="24"
        to="Home" 
        @click="logout()"
        >
          <v-icon>mdi-logout</v-icon>
        </v-btn></v-col>

 </v-row> 
          
    
      </nav>

  </div>
</template>

<script>
import { AUTH_LOGOUT } from '../store/actions/auth';
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
  methods: {
    logout() {
      this.$store.dispatch(AUTH_LOGOUT);
      this.$router.push("Login");
    },
  }
};
</script>



<style lang ="scss" scoped>
  nav {
    /* background-color: black; */
    height: 100;
    margin-left: 50px;
    margin-right: 50px;
    /* text-align: center; */
  }
  v-btn {
      text-align: right;
  }
</style>