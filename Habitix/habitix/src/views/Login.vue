<template>
<div>
        <div class="login-container">
        <v-row align="center" justify="center">
        <v-col cols="12" md="4">
            <v-card dark>
            <v-card-text>
                <v-form>
                <v-row justify="center">
                    <v-col cols="12" md="9">
                    <v-text-field
                        name="name"
                        label="Login"
                        hint="At least 8 characters"
                        min="8"
                        outlined
                        required
                        v-model="username"
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
                </v-row>
                <v-card-actions>
                    <v-btn
                    color="orange darken-3"
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
                    <v-icon>mdi-exit</v-icon>
                    </v-btn>
                    <v-btn
                    color="indigo darken-1"
                    @click="Login()"
                    :loading="loading"
                    large
                    >
                    Login
                    <v-icon>mdi-login</v-icon>
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
            <v-checkbox
                    label="Do you read and accept our terms of service"
                  />
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
import Vue from 'vue'
import {
  Vuetify,
  VApp,
  VNavigationDrawer,
  VFooter,
  VList,
  VBtn,
  VIcon,
  VGrid,
  VToolbar,
  VCard,
  transitions
} from 'vuetify'

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