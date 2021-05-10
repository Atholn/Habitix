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
            <div class="user-habit__follower-count">
                <strong>Followers: </strong>{{ followers }}
            </div>
            <v-switch  v-model="hs" @click="getHabits()">
            </v-switch>
        </div>
            
        <div class ="user-habit__habits" > 
                <div v-if="hs" >            
                    <div v-if="h === []"> Lista pusta !  </div>
                    <div v-else>                        
                        <HabitItem    
                          
                        v-for="item in h" 
                        :key="item.id"                   
                        :habit="item" 
                        :hide=hs
                        :check="hs"
                        :imp="imp"
                        />                   
                    </div>
                </div> 

                <div v-else>
                    <div v-if="h === []"> Lista pusta !  </div>
                    <div v-else> 
                    <HabitItem  
                    v-for="item in h" 
                    
                    :key="item.id"                   
                    :habit="item" 
                    :hide=hs
                    :check="hs"
                    :imp="imp"                   
                    /> 
                    </div>
                </div>
                
        </div>

       
     
    </div> 
    <div class="create_new"> <CreateNewHabit/></div>
    <div> </div>
  </div> 
</v-container> 
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
      title: "Child to parent data",
      icons: ["mdi-facebook", "mdi-twitter", "mdi-linkedin", "mdi-instagram"],
      h:[],
      imp: "test",
      followers: 0,
            hs: false,
            
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
        h(val, old) {
             {
               console.log("sada" + val + "asdas");
             //  this.h : [];
             this.h = val;
               
            }
        }

        

    },
    computed: {
        newMessageCharacterCount() {
            return this.newMessageContent.length;
        },
       
    },

  mounted() {
     this.getHabits();
                ///----
     this.getHabitixUserInfo();
  },

  methods: {
      updateTitleText(title){
          this.title=title;
      },
      testEventEvent(title){
          console.log("test bichys "+ title );
           this.getHabits();
      },
      changeTitle (){
          this.$emit('asd', 'dsa');
      },
      hideShow() {
            console.log(this.hss)
            this.hss = !this.hss;
            console.log(this.hss)
      },
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
                .get(`https://localhost:44312/api/Habit/UserHabits/${this.hs}`
                , {                  
                      headers: {
                          "Content-Type": "application/json",
                          'Authorization': 'Bearer ' +localStorage.getItem('user-token'),
                      }
                    })
                .then((res) => {
                
                this.h = res.data;
                //console.info(res.data); 
                console.info(this.$store.getters.authStatus);
                })
                .catch((err) => {
                console.error(err);
                }); 
                
                // console.info(this.h);   
                console.info(localStorage.getItem('user-token'));              
            },

        followUser() {
            this.followers++
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
        

        .user-habit__habits {
            display: grid;
            grid-gap: 10px;
            grid-template-columns: 2fr 2fr 2fr;
        }
        h1 {
            margin: 0;
        }
        }  


    }
    .create_new{
            width: 100%; 
             margin-right: 50px;
             padding: 50px 5%;
        }

</style>