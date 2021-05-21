<template>
    <div>
        <div class="login-container">
                <v-row align="center" justify="center">
                <v-col cols="12" md="4">

                    <v-row justify="center">
                    <v-col cols="12" md="9">
                    
                                    <v-text-field
                                    name="email"
                                    label="E-mail"
                                    outlined
                                    required
                                    v-model="user.email"
                                    />

                                    <v-text-field label="Test" > </v-text-field>
                                    

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
                    @click="Register()"
                    color="primary"
                    depressed
                    medium
                    outlined
                    small
                    > Register!</v-btn>
                </v-col>
                </v-row>
        </div>
    </div>
</template>


<script>
export default {
     name: 'CreateNewAccount',
    data() {
        return {
                user: {            
            userName: "",
            email: "",
            password: ""
      },
       
      habit : {
          habitName: "nauka prog",
            habitDescription: "Nauka programowania 30 k .NET ",
  startDateHabit: "2021-01-22T19:36:26.101Z",
  habitixUserId: 2,
  habitDates: [
    {
      instanceData: "2021-03-22T19:36:26.102Z"
    }]
      }
    };
  },

methods: {
    Register() {
        // console.log("Register!")
        this.$axios
            .post(`https://localhost:44312/api/Identity/RegisterUser`, this.user)
            .then(res => {
                this.$router.push("Login");
            })
             .catch(err => {
          console.error(err);
        });
        // console.log("Register2!")
        // this.$axios
        //     .post(`https://localhost:44312/api/Habit`, this.habit)
        //     .then(res => {
        //         this.$router.push("Login");
        //     })
        //      .catch(err => {
        //   console.error(err);
        // });
console.log("Register3!")

    },
    
    }
}
</script>