<template>
    <div class="user-profile">
        <div class ="user-profile__user-panel">
            <h1 class="user-profile__username">@{{ user.username }}</h1>
            <div class="user-profile__follower-count">
                <strong>Followers: </strong>{{ followers }}
            </div>
        </div>
    </div>
</template>

<script>

export default {
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
                isAdmin: true
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
    components: {

    },
    methods: {
        followUser() {
            this.followers++
        }
    },
    mounted() {
        this.followUser();
        
    },

}
</script>

<style>
    #profile
    {
         font-family: Avenir, Arial, Helvetica, sans-serif;
         -webkit-font-smoothing: antialiased;
         -moz-osx-font-smoothing: grayscale;
         text-align: center;
         color: #2c3e50;
         margin-top: 60px;
         display: flex;
         flex-direction: column;
         text-align: center;       
    }
  
</style>