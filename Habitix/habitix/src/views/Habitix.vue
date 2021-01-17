<template>
  <div class="habitix">
    
    <p>
      For a guide and recipes on how to configure / customize this project,<br>
      check out the
      <a href="https://cli.vuejs.org" target="_blank" rel="noopener">vue-cli documentation</a>.
    </p>


    <ul v-for="( user , id) in Users" :key="`${id}`">  <br>{{user.id}} {{user.name}} {{user.lastName}}  <br></ul>


 
    <h3>Installed CLI Plugins</h3>
    
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
      fruits: ['apple', 'banana', 'orange'],
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

}
;

</script>

<style scoped>
h3 {
  margin: 40px 0 0;
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