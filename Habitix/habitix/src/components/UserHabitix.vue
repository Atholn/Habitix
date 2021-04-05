<template>
    <v-container fluid>
     
    <div class="user-habitix">
        <div class ="user-habitix__user-panel">
            <h1 class="user-habitix__username">@{{ user.username }}</h1>
            <div class="user-habitix_admin-badge" v-if="!user.Admin">
                Admin
            </div>
            <div class="user-habitix__follower-count">
                <strong>Followers: </strong>{{ followers }}
            </div>
        </div>

        <div class ="user-habitix__messeges-wrapper "> 
                <HabitItem  
                    v-for="item in hab" 
                    :key="item.id"                   
                    :habit="item" 
                    
                />             
                 <!-- @favorite="toggleFavorite"   -->
                <!--                               -->
        </div>
    {{ hab }}
    </div>
     </v-container>
</template>

<script>
import HabitItem from './HabitItem.vue';

export default {
    components: { HabitItem },
    name: "HabitixUser",
        data() {
        return {
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
            //------

        }
    },
    watch: {
        followers(newFollowerCunt, oldFollowerCount){
           if(oldFollowerCount  < newFollowerCunt) {
               console.log(`${this.user.username} has gainted a follower!`)
           } 
        }
    },
    computed: {
        newMessageCharacterCount() {
            return this.newMessageContent.length;
        }
    },
    methods: {
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
         getHab() {
            this.hab = [];     
            this.$axios
                .get(`https://localhost:44312/api/Habit/userId?userId=1`)
                .then((res) => {
                this.hab = res.data;
                console.log(res.data);
                })
                .catch((err) => {
                console.error(err);
                });       
            }, 
            

            
            
            
            },      
            mounted() {
                this.followUser();
                this.getHab();
    },
}
</script>

<style lang="scss" scoped>
   
    .user-habitix {
        display: grid;
        grid-template-columns: 1fr 3fr;
        width: 100%;
        padding: 50px 5%;

     .user-habitix__user-panel {
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

        .user-habitix_admin-badge{
            background-color: blue;
            color:white;
            border-radius: 5px;
            margin-right: auto;
            padding: 0 10px;
            font-weight: bold;
        }

        .user-habitix__create-message { 
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

        .user-habitix__messeges-wrapper {
            display: grid;
            grid-gap: 10px;
        }
    }

</style>