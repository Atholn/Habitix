<template>
    <div id="profile">
        <user-profile/>
    </div>
</template>

<script>
import UserProfile from '../components/UserProfile.vue';

export default {
    name: "Profile",
    components: {
        UserProfile
    },
}
</script>

<style>
    #profile
    {
         font-family: Avenir, Arial, Helvetica, sans-serif;
         -webkit-font-smoothing: antialiased;
         -moz-osx-font-smoothing: grayscale;
         color: #2c3e50;
         min-height: 100vh;
        background-color: #F3F3FA;    
    }
  
</style>