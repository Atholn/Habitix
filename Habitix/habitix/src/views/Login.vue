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
                                    hint="At least 8 characters"
                                    min="8"
                                    outlined
                                    required
                                    v-model="userName"
                                    />

                                    <v-text-field
                                    name="name"
                                    label="Password"
                                    hint="At least 8 characters"
                                    min="8"
                                    type="password"
                                    outlined
                                    required
                                    v-model="password"
                                    />
                  </v-col>

        <v-btn 
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
        </v-btn>
                </v-row>
                    <v-btn
                    @click="Login()"
                    color="primary"
                    depressed
                    medium
                    outlined
                    small
                    > Login!</v-btn>
                </v-col>
                </v-row>
        </div>
    </div>
</template>


<script>

import { AUTH_REQUEST } from "@/store/actions/auth";


export default {
     name: 'LoginToAccount',
    data() {
        return {
                user: {            
            userName: "",
            password: ""
      },
      user1: {            
            userName: "wafel",
            password: "qazwsx1Q!"
      },
      userName: "",
      password: "",
    };
  },
mounted() {
},
methods: {
    // Login() {
    //   console.log(this.$store.getters.isAuthenticated)
    //   },
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

    Login1() {
        this.$axios
            .post(`https://localhost:44312/api/Identity/Login`, this.user1)
            .then(res => {
                this.$router.push("Login");
            })
             .catch(err => {
          console.error(err);
        });
    },
    }
}
</script>