<template>
  <div class="stats">
    <div><v-btn 
        elevation="24"
        
         @click="logout()"
        >
           <v-icon>mdi-logout</v-icon>
        </v-btn>

    Helloł 
               <div v-for="habit in h" :key="habit.id">
              {{habit.habitName}}  {{habit.habitDescription}}  {{habit.startDateHabit}}  {{habit.habitixUserId}}
               </div>
                    
                    <!-- <div v-for="item in hab1" :key="item.id">  
                      <div v-for="post in item.data1" :key="post.id" >{{post.id}} - {{post.title}} - {{post.content}} - {{post.creationDate}} </div> 
                      </div> 

                       <div v-for="item in this.posts.data" :key="item.id">  {{item.id}} - {{item.title}} - {{item.content}} - {{item.creationDate}} </div> -->
           <!-- {{this.posts}} -->
  </div> 
  
  <div> 

 <v-container fluid>
     
    <div class="user-habit">
        <div class ="user-habit__user-panel">
            <h1 class="user-habit__username">@{{ habitixUserInfo.userName }}</h1>
            <div class="user-habit_admin-badge" v-if="habitixUserInfo.userRole === 'Admin'">{{ habitixUserInfo.userRole }}
            </div>
            <div class="user-habit_user-badge" v-else>{{ habitixUserInfo.userRole }}
            </div>
            <div class="user-habit__follower-count">
                <strong>Followers: </strong>{{ followers }}
            </div>
        </div>

        <div class ="user-habit__messeges-wrapper "> 


                    <div v-if="h === []"> 
                Lista pusta !  </div>
          <div v-else> 
                <HabitItem  
                    v-for="item in h" 
                    :key="item.id"                   
                    :habit="item" 
                                    
                /> 
                </div>


                 <!-- @favorite="toggleFavorite"   -->
                <!--                               -->
        </div>
        {{ h }}

        <CreateNewHabit/>
         </div>
      
     </v-container>


  </div>
  </div>   
</template>


<script>
import { AUTH_LOGOUT } from '../store/actions/auth';
import HabitItem from './HabitItem.vue';
import CreateNewHabit from './CreateNewHabit.vue';

export default {
  components: { HabitItem , CreateNewHabit},
  name: 'Dashboard',

    data() {
    return {
      icons: ["mdi-facebook", "mdi-twitter", "mdi-linkedin", "mdi-instagram"],
      // habits: [],
      //     data1: [
      //         {
      //           id: 27,
      //           title: "post1",
      //           content: "content1",
      //           creationDate: "2021-03-29T21:23:54.8592929"
      //         },
      //         {
      //           id: 28,
      //           title: "post2",
      //           content: "content2",
      //           creationDate: "2021-03-29T21:24:01.1085022"
      //         },
      //         {
      //           id: 29,
      //           title: "post3",
      //           content: "content3",
      //           creationDate: "2021-03-29T21:24:06.0869964"
      //         }],
      h:[],

           newMessageContent: '',
            selectetMessageType: 'instant',

            messageTypes: [
                { value: 'draft', name: 'Draft'},
                { value: 'instant', name: 'Instant Mess'} 
            ],
            isLoading: false,
            followers: 0,
            user: {
                id:1,
                username: '_MATEUSZ',
                firstName: 'Mati',
                lastName: 'Atcholn',
                email: 'mateuszzydzik@gmail.com',
                isAdmin: true,
                habits: [ 
                        { id : 1,  content:'Habitix info'},
                        { id : 2,  content:'InfoInfoInfoInfo'}
                ]
            },
                
            hab: [],
            ///------------
          habitixUserInfo: {
            userName: "",
            userRole: ""
              },     
    };
  },

  watch: {
        followers(newFollowerCunt, oldFollowerCount){
           if(oldFollowerCount  < newFollowerCunt) {
               console.log(`${this.user.username} has gainted a follower!`)
           } 
        },

    },
    computed: {
        newMessageCharacterCount() {
            return this.newMessageContent.length;
        },
       
    },

  mounted() {
     this.getHabits();
      this.followUser();
                ///----
                this.getHabitixUserInfo();
  },

  methods: {
      Login11() {
      console.log(this.$store.getters.isAuthenticated)
      },
    logout() {
      this.$store.dispatch(AUTH_LOGOUT);
       this.$router.push("Login");
    },
     getHabits() {

            this.h = [];     
            this.$axios
                .get(`https://localhost:44312/UserHabits`
                , {                  
                      headers: {

                          "Content-Type": "application/json",
                         // Authorization: `${localStorage.getItem('user-token')}`
                          'Authorization': 'Bearer ' +localStorage.getItem('user-token'),
                      }
                    })
                .then((res) => {
                
                this.h = res.data;
                // console.info(res.data); 
                console.info(this.$store.getters.authStatus);
                })
                .catch((err) => {
                console.error(err);
                }); 
                
                // console.info("info");   
                console.info(localStorage.getItem('user-token'));              
            },

        followUser() {
            this.followers++
        },
        adminChange() {
            this.user.isAdmin = false;
        },
        toggleFavorite(id) {
            console.log(`Favourited mess #${id}`);
        },
        createNewMessage() {
            if (this.newMessageContent && this.messageTypes !== 'draft') {
                this.user.messeges.unshift({
                    id: this.user.messeges.length +1,
                    content: this.newMessageContent,
                })
                this.newMessageContent = '';
            }
        },

            //--------------
            getHabitixUserInfo() {

                this.$axios   
                .get(`https://localhost:44312/api/HabitixUser/UserInfo`, {        

                      headers: {
                          "Content-Type": "application/json",
                         // Authorization: `${localStorage.getItem('user-token')}`
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