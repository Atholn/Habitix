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
                <button @click="adminChange()"> ChangeRole </button>
        </div>
        <div class ="user-profile__messeges-wrapper"> 
                <!-- {{user.twoots[0]}} -->
                <HabitixItem  v-for="item in user.messeges " :key="item.id" :username="user.username" :message="item"/> 
                
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
        fullName() {
            return `${this.user.firstName} ${this.user.lastName}`;
        }
    },
    methods: {
        followUser() {
            this.followers++
        },
        adminChange() {
            this.user.isAdmin = false;
        }
    },

        
    mounted() {
        this.followUser();
    },
}
</script>

<style>
    .user-profile {
        display: grid;
        grid-template-columns: 1fr 3fr;
        width: 100%;
        padding: 50px 5%;
    }

    .user-profile__user-panel {
        display: flex;
        flex-direction: column;
        margin-right: 50px;
        padding: 20px;
        background-color: white;
        border-radius: 5px;
        border: 1px solid #DFE3E8;
    }  

    .user-profile_admin-badge{
        background-color: blue;
        color:white;
        border-radius: 5px;
        margin-right: auto;
        padding: 0 10px;
        font-weight: bold;
    }

    h1 {
        margin: 0;
    }
</style>