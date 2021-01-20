<template>
    <div class="user-profile">
        <div class ="user-profile__user-panel">
            <h1 class="user-profile__username">@{{ user.username }}</h1>
            <div class="user-profile_admin-badge" v-if="!user.Admin">
                Admin
            </div>
            <div class="user-profile__follower-count">
                <strong>Followers: </strong>{{ followers }}
            </div>
               <form class="user-profile__create-message" @submit.prevent="createNewMessage" :class="{ '--exceeded': newMessageCharacterCount > 180}">
               <label for="newMessage"><strong> New messege</strong> ({{ newMessageCharacterCount}}/300)</label>
               <textarea id="newMessege" rows="4" v-model="newMessageContent"/>

               <div class="user-profile__create-message-type">
                   <label for="newMessageType"><strong>Type: </strong></label>
                   <select id="newMessageType" v-model="selectetMessageType">
                       <option :value="option.value" v-for="(option, index) in messageTypes" :key="index">
                           {{ option.name }}
                       </option>
                   </select>
               </div>
               <button>
                   Send!
               </button>
            </form> 
        </div>
        <div class ="user-profile__messeges-wrapper"> 
                <!-- {{user.twoots[0]}} -->
                <HabitixItem  
                    v-for="item in user.messeges " 
                    :key="item.id" 
                    :username="user.username" 
                    :message="item" 
                    @favorite="toggleFavorite"
                                   
                /> 
                
        </div>
    </div>
</template>

<script>
import HabitixItem from './HabitixItem.vue';

export default {
  components: { HabitixItem },
    name: "Profile",
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
                messeges: [
                    { id : 1,  content:'Habitix info'},
                    { id : 2,  content:'InfoInfoInfoInfo'}
                ]
            }
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

        }
    },

        
    mounted() {
        this.followUser();
    },
}
</script>

<style lang="scss" scoped>
    .user-profile {
        display: grid;
        grid-template-columns: 1fr 3fr;
        width: 100%;
        padding: 50px 5%;

     .user-profile__user-panel {
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

        .user-profile_admin-badge{
            background-color: blue;
            color:white;
            border-radius: 5px;
            margin-right: auto;
            padding: 0 10px;
            font-weight: bold;
        }

        .user-profile__create-message { 
            padding-top: 20px;
            display: flex;
            flex-direction: column;

            &.--exceeded{
                color: red;
                border-color: red;

                button {
                    background-color: red;
                    border: none;
                }
            }
          }
        }  

        .user-profile__messeges-wrapper {
            display: grid;
            grid-gap: 10px;
        }
    }
</style>