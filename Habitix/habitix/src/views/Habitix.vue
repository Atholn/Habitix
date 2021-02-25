<template>
<div>
  <nav> <v-btn
  elevation="24"
  fab
><v-icon> mdi-access-point </v-icon></v-btn>
<unicon name="uniAirplay" fill="deeppink" icon-style="monochrome" />
<unicon name="uniAirplay" fill="royalblue" />

<v-icon aria-hidden="false">
  mdi-account
</v-icon>


</nav>
  <div id="habitixx">
        <user-habitix/>
    </div>
  <div>
  <h3> 
    <ul v-for="( user , id) in Users" :key="`${id}`">  <br>{{user.id}} {{user.name}} {{user.lastName}}  <br></ul>
 </h3>
 </div>
  </div>
</template>


<script>
import UserHabitix from '../components/UserHabitix';
import Unicon from 'vue-unicons'



export default {

  name: 'Habitix',
  props: {
    msg: String
  },
  data (){
        return {
      Users: [],
    };
  },

mounted() {
  this.getUsers();
},
components: {
        UserHabitix
    },
methods: {
  getUsers() {
      this.Users = [];     
      this.$axios
        .get(`https://localhost:44312/api/HabitixUser`)
        .then((res) => {
          this.Users = res.data;
        console.log(res.data);
        })
        .catch((err) => {
          console.error(err);
        });       
  },
  }
};

</script>
<style scoped>
.left
{
  background-color: chocolate;
  size: 50%;

}
.habitix
{
  background-color: chartreuse;
}
h3 {
  margin-left: 100px ;
}
ul {
  list-style-type: none;
  padding: 0;
}
li {
  display: inline-block;
  margin: 0 10px;
}
a {
  color: #42b983;
}

 #habitixx
    {
         font-family: Avenir, Arial, Helvetica, sans-serif;
         -webkit-font-smoothing: antialiased;
         -moz-osx-font-smoothing: grayscale;
         color: #2c3e50;
         min-height: 100vh;
        background-color: #F3F3FA;    
    }
</style>