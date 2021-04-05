<template>
    <div class="CreateNewHabit-item">

        <v-text-field
                    name="habitName"
                    label="Nazwa nawyku"
                    hint="At least 8 characters"
                    min="8"
                    outlined
                    required
                    v-model="habit.habitDescription"
                  />
                  <v-text-field
                    name="habitDescription"
                    label="Opis nawyku"
                    hint="At least 8 characters"
                    min="8"
                    outlined
                    required
                    v-model="habit.habitName"
                  />

                <v-btn
                  color="indigo darken-1"
                  @click="AddHabit()"
                  large
                >
                  
                  <v-icon>mdi-plus</v-icon>
                </v-btn>
        hakuna matata!
    </div>
</template>

<script>
export default {
    name: "CreateNewHabit",
    data() {
        return {
            habit: {
                    habitName: "",
                    habitDescription: "",
                    startDateHabit: "2021-04-05T21:13:35.191Z",
                    habitixUserId: 2,
                    habitDates: [ ]
            }
            
        }
    },
    methods: {
        AddHabit() {
                this.$axios({
                    method: "post",
                    url: "https://localhost:44312/api/Habit",
                    data: this.habit,
                     headers: {
                                    "Content-Type": "application/json",
                                    // Authorization: `${localStorage.getItem('user-token')}`
                                    'Authorization': 'Bearer ' + localStorage.getItem('user-token'),
                                }
                }).then(res => {
                        console.info("success")
                        })
                         .catch(err => {
                        console.error(err);




                //   this.$axios
                //         .post(`https://localhost:44312/api/Habit`,  {   
                //                 //  habitName: this.habit.habitName,
                //                 //  habitDescription: this.habit.habitDescription,  
                //                 //  startDateHabit: this.habit.startDateHabit,    
                                 


                //                 headers: {
                //                     "Content-Type": "application/json",
                //                     // Authorization: `${localStorage.getItem('user-token')}`
                //                     'Authorization': 'Bearer ' + localStorage.getItem('user-token'),
                //                 }}
                //                 )
                //         .then(res => {
                //         console.info("success")
                //         })
                //          .catch(err => {
                //         console.error(err);
        });
        }
    }

};
</script>

<style lang ="scss" scoped>
    .user-habit {
        display: grid;
        grid-template-columns: 1fr 3fr;
        width: 100%;
        padding: 50px 5%;

     .user-habit__user-panel {
        display: flex;
        flex-direction: column;
        margin-right: 50px;
        padding: 20px;
        background-color: white;
        border-radius: 5px;
        border: 1px solid #DFE3E8;
        
        h1 {
            margin: 0;
        }

        .user-habit_admin-badge{
            background-color: blue;
            color:white;
            border-radius: 5px;
            margin-right: auto;
            padding: 0 10px;
            font-weight: bold;
        }
        
        .user-habit_user-badge{
            background-color: black;
            color:white;
            border-radius: 5px;
            margin-right: auto;
            padding: 0 10px;
            font-weight: bold;
        }

        .user-habit__create-message { 
            padding-top: 20px;
            display: flex;
            flex-direction: column;

            &.--exceeded{
                color: red;
                border-color: red;

                button {
                    background-color: red;
                    border: none;
                    color: white;
                }
            }
          }
        }  

        .user-habit__messeges-wrapper {
            display: grid;
            grid-gap: 10px;
        }
    }
</style>