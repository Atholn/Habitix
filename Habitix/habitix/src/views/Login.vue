<template>
  <div>
    <div class="login-container">
      <v-row align="center" justify="center">
      <v-col cols="12" md="4">
        <v-row justify="center">
        <v-col cols="12" md="9">          
          <v-text-field
          name="name"
          label="Login"       
          min="8"
          outlined
          required
          v-model="userName"
          />
          <!-- hint="At least 8 characters" -->
          <!-- hint="At least 8 characters" -->
          <v-text-field
          name="name"
          label="Password"        
          min="8"
          type="password"
          outlined
          required
          v-model="password"
          />

          <v-row  align="center">
          <v-col>
            <v-btn
              @click="Login()"
              color="primary"
              depressed
              medium
              outlined
              small
              >Login!
            </v-btn>
          </v-col>

          <v-col  class="subtitle-2 text-center">
            <v-row >
              You don't have an account in habitix yet?
            </v-row>
             <v-row >             
            
            <v-btn 
              to="Register"
              color="primary"
              depressed
              medium
              outlined
              small
              >Register!
            </v-btn>
            </v-row>
          </v-col>
          </v-row>


        </v-col>

      </v-row>
          
      </v-col>
      </v-row>
    </div>

      <!-- <v-btn 
      elevation="24"
      to="dashboard"  
      >
        <v-icon>mdi-widgets</v-icon>
      </v-btn>
      <v-btn 
      elevation="24"
      to="home"  
      >
        home
      </v-btn> -->
  </div>
</template>


<script>
import { AUTH_REQUEST } from "@/store/actions/auth";

export default {
  name: 'Login',

  data() {
      return {
    
      userName: "",
      password: "",

      // user: {            
      //     userName: "",
      //     password: ""
      // },
      // user1: {            
      //       userName: "wafel",
      //       password: "qazwsx1Q!"
      // },
    };
  },

  mounted() {
  },

  methods: {
    Login() {
      const { userName, password } = this;
      this.$store.dispatch(AUTH_REQUEST, { userName, password }).then(() => {
        this.$router.push("/dashboard/");
      });
    },

    clearFields() {
      this.username = "";
      this.password = "";
    },

    // Login() {
    //   console.log(this.$store.getters.isAuthenticated)
    //   },
    // Login1() {
    //     this.$axios
    //         .post(`https://localhost:44312/api/Identity/Login`, this.user1)
    //         .then(res => {
    //             this.$router.push("Login");
    //         })
    //          .catch(err => {
    //       console.error(err);
    //     });
    // },
    }
}
</script>