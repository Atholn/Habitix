<template>
<div>
  <div id="Habitix">
        <habitix/>
    </div>
  <div>
  <h3> 
    <ul v-for="( user , id) in Users" :key="`${id}`">  <br>{{user.id}} {{user.name}} {{user.lastName}}  <br></ul>
 </h3>
 </div>
  </div>
</template>


<script>
export default {

  name: 'Habitix',
  props: {
    msg: String
  },
  data ()
  {
        return {
      Users: [],
    };
  },

mounted() {
  this.getUsers();
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
</style>