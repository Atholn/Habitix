<template>
  <v-app>
    <v-main>
      <nav>
      <div class="navigation__logo">    
        Habitix
         </div>

         <div class="navigation__user">    
        Habitix
         </div>
      </nav>
      <!-- <div id="nav">
        <router-link to="/">Home </router-link>
        <router-link to="/profile">Profile </router-link>             
      </div> -->
      <router-view/>
     
    </v-main>
    
      <img alt="Vue logo" src="./assets/logo.png">
  </v-app>
      
</template>

<script>
export default {
  name: "App",

  data: () => ({
    //
  })
};
</script>

<style>
 .navigation__logo {
   background-color: blue;
 }
</style>




