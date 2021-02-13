<template>
<div>
        <div class="login-container">
        <v-row align="center" justify="center">
        <v-col cols="12" md="4">
            <v-card >
            <v-card-text>
                <v-form>
                 <h2 class="naglowek"> Login </h2>

                <v-row justify="center">
                    <v-col cols="12" md="9">
                    UserName
                    <v-text-field
                        name="name"
                        min="3"
                        outlined
                        required
                        v-model="username"
                    />
                    Password
                    <v-text-field
                        name="name"
                        min="5"
                        type="password"
                        outlined
                        required
                        v-model="password"
                    />
                    </v-col>
                </v-row>
                <v-card-actions>
                    <v-btn
                    color="blue"
                    to="Register"
                    :loading="loading"
                    text
                    large
                    >
                    Register
                    <v-icon>mdi-exit</v-icon>
                    </v-btn>
                    <v-spacer />
                    <v-btn
                    color="blue-grey lighten-3"
                    to="/"
                    :loading="loading"
                    large
                    >
                    Back
                    
                    </v-btn>
                    <v-btn
                    color="indigo"
                    @click="Login()"
                    :loading="loading"
                    large
                    >
                    Login

                    </v-btn>
                </v-card-actions>
                </v-form>
            </v-card-text>
            </v-card>
        </v-col>
        </v-row>
        </div>
           
        <div>
          <div>
          TestTest <br>
          If you dont have account, create it! 
          </div>
          <div>
                      <v-btn
                    color="orange darken-3"
                    to="Register"
                    
                    text
                    large
                  >
                  Register
                    
                  </v-btn>
          </div>
        </div>
    </div>
</template>

<script>
import { AUTH_REQUEST } from "../store/actions/auth";


export default {
     name: 'Login',
     data() {
    return {
      username: "",
      password: "",
      loading: false
    };
    },
    mounted() {
        console.log();
    },
     methods: {
    Login() {
      console.log("hakuna");
      const { username, password } = this;
      this.$store.dispatch(AUTH_REQUEST, { username, password }).then(() => {
        
        this.$router.push("/dashboard/");
      });
    },

    clearFields() {
      this.username = "";
      this.password = "";
    }
  }
};

</script>

<style scoped>
.login-container {
  height: 100vh;
  display: flex;
}

</style>