<template>
  <v-container fluid style="min-height: 100vh">
    <v-row class="pa-2" justify="center" align="center">
      <v-col cols="12" sm="5">
        <v-card dark>
          <v-card-title primary-title>
            Create your account!
          </v-card-title>
          <v-form class="pa-2">
            <v-row justify="center">
              <v-col cols="12" md="8">
                <v-text-field
                  name="email"
                  label="E-mail"
                  outlined
                  required
                  v-model="user.email"
                />
                <v-text-field
                  name="email"
                  label="Repeat E-mail"
                  outlined
                  required
                  v-model="checkUser.email"
                />
                <v-text-field
                  name="name"
                  label="Login"
                  hint="At least 8 characters"
                  min="8"
                  outlined
                  required
                  v-model="user.username"
                />
                <v-text-field
                  name="name"
                  label="Password"
                  hint="At least 8 characters"
                  min="8"
                  type="password"
                  outlined
                  required
                  v-model="user.password"
                />
                <v-text-field
                  name="name"
                  label="Repeat Password"
                  hint="At least 8 characters"
                  min="8"
                  type="password"
                  outlined
                  required
                  v-model="checkUser.password"
                />
                <v-checkbox
                  label="Do you read and accept our terms of service"
                />
                <v-checkbox label="Do you want to sign in to our newsletter" />
              </v-col>
            </v-row>
            <v-card-actions>
              <v-spacer />
              <v-btn color="blue-grey lighten-3" to="Login" large>
                Back
                <v-icon>mdi-exit</v-icon>
              </v-btn>
              <v-btn
                color="indigo darken-1"
                @click="Register()"
                :loading="loading"
                :disabled="!isValid"
                large
              >
                Register account
              </v-btn>
            </v-card-actions>
          </v-form>
        </v-card>
      </v-col>
    </v-row>
  </v-container>
</template>

<script>
export default {
  data() {
    return {
      user: {
        email: "",
        username: "",
        password: ""
      },
      checkUser: {
        email: "",
        password: ""
      },
      isValid: false
    };
  },

  watch: {
    "user.email": function() {
      this.isValid = this.IsValid();
    },
    "user.username": function() {
      this.isValid = this.IsValid();
    },
    "user.password": function() {
      this.isValid = this.IsValid();
    },
    "checkUser.email": function() {
      this.isValid = this.IsValid();
    },
    "checkUser.username": function() {
      this.isValid = this.IsValid();
    },
    "checkUser.password": function() {
      this.isValid = this.IsValid();
    }
  },

  methods: {
    Register() {
      console.log(process.env.VUE_APP_BASE_URL_API)
      if (!this.IsValid()) return;
      this.$axios
        .post(`${process.env.VUE_APP_BASE_URL_API}/User/register`, this.user)
        .then(res => {
          this.$router.push("Login");
        })
        .catch(err => {
          console.error(err);
        });
    },

    IsValid() {
      return (
        this.checkUser.email &&
        this.checkUser.password &&
        this.user.email &&
        this.user.username &&
        this.user.password &&
        this.checkUser.email == this.user.email &&
        this.checkUser.password == this.user.password
      );
    }
  }
};
</script>