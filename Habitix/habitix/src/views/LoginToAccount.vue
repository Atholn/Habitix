




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
                                    v-model="user.userName"
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
                    </v-col>
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
    };
  },

methods: {
    Login() {
        console.log("Login!")
        this.$axios
            .post(`https://localhost:44381/api/Identity/Login`, this.user1)
            .then(res => {
                this.$router.push("LoginToAccount");
            })
             .catch(err => {
          console.error(err);
        });
        console.log("Login!")
        // this.$axios
        //     .post(`https://localhost:44312/api/Habit`, this.habit)
        //     .then(res => {
        //         this.$router.push("Login");
        //     })
        //      .catch(err => {
        //   console.error(err);
        // });
console.log("Login!")

    },
    
    }
}
</script>