<template>
<v-container fluid>
  <div>  
    <div class="user-habit">
        <div class ="user-habit__user-panel">
            <h1 class="user-habit__username">@{{ habitixUserInfo.userName }}</h1>
            <div class="user-habit_admin-badge" v-if="habitixUserInfo.userRole === 'Admin'">{{ habitixUserInfo.userRole }}
            </div>
            <div class="user-habit_user-badge" v-else>{{ habitixUserInfo.userRole }}
            </div>
            <v-switch  v-model="habitsHS" @click="getHabits()">
            </v-switch>
        </div>
            
        <div class ="user-habit__habits" > 
                <div v-if="habitsHS" >            
                    <div v-if="habits === []"> Lista pusta !  </div>
                    <div v-else>                        
                        <HabitItem                             
                        v-for="item in habits" 
                        :key="item.id"                   
                        :habit="item" 
                        :check="habitsHS"
                        />                   
                    </div>
                </div> 

                <div v-else>
                    <div v-if="habits === []"> Lista pusta !  </div>
                    <div v-else> 
                        <HabitItem  
                        v-for="item in habits"           
                        :key="item.id"                   
                        :habit="item" 
                        :check="habitsHS"                      
                        /> 
                    </div>
                </div>           
        </div>
    </div> 
    
    <div class="create_new"> <CreateNewHabit/></div>

  </div> 
</v-container> 
</template>


<script>
import HabitItem from './HabitItem.vue';
import CreateNewHabit from './CreateNewHabit.vue';

export default {
  components: { HabitItem , CreateNewHabit},
  name: 'Dashboard',

    data() {
    return {
            icons: ["mdi-facebook", "mdi-twitter", "mdi-linkedin", "mdi-instagram"],
            habits:[],
            habitsHS: false, 
            habitixUserInfo: {
            userName: "",
            userRole: ""
            },     
        };
    },

    watch: {
    },

    computed: {       
    },

    mounted() {
     this.getHabits();
     this.getHabitixUserInfo();
    },

    methods: {
        getHabits() {    
            this.habits = [];     
            this.$axios
                .get(`https://localhost:44312/api/Habit/UserHabits/${this.habitsHS}`
                , {                  
                        headers: {
                            "Content-Type": "application/json",
                            'Authorization': 'Bearer ' +localStorage.getItem('user-token'),
                        }
                    })
                .then((res) => {           
                this.habits = res.data;
                })
                .catch((err) => {
                console.error(err);
                });         
        },

        getHabitixUserInfo() {
            this.$axios   
            .get(`https://localhost:44312/api/HabitixUser/UserInfo`, {
                    headers: {
                        "Content-Type": "application/json",
                        'Authorization': 'Bearer ' + localStorage.getItem('user-token'),
                    }
                })
            .then((res) => {
            this.habitixUserInfo = res.data;
            })
            .catch((err) => {
            console.error(err);
            });       
        }            
  },
}

</script>

<style lang="scss" scoped>
   
    .user-habit {
        display: grid;
        grid-template-columns: 1fr 3fr ;
        width: 100%;
        padding: 50px 5%;
        background-color: black;

        .user-habit__user-panel {
        display: flex;
        flex-direction: column;
        margin-right: 30px;
        padding: 20px;
        background-color: white;
        border-radius: 5px;
        border: 1px solid #DFE3E8;
        }

        .user-habit__habits {
            display: grid;
            grid-gap: 10px;
            grid-template-columns: 2fr 2fr 2fr;
        }

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

    }

    .create_new{
            width: 100%; 
            margin-right: 50px;
            padding: 50px 5%;
    }

</style>