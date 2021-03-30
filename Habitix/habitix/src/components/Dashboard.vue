<template>
  <div class="stats">
    <v-btn 
        elevation="24"
        
         @click="logout()"
        >
          <v-icon>mdi-widgets</v-icon>
        </v-btn>

    Helloł 
    
                <!-- <div v-for="item in data1" 
                    :key="item.id"                   
                    > {{item.id}} - {{item.title}} - {{item.content}} - {{item.creationDate}} </div>    -->
    
<!-- 
                    <div v-for="item in hab1.data1" 
                    :key="item.id"                   
                    > {{item.id}} - {{item.title}} - {{item.content}} - {{item.creationDate}} </div>   -->
                    
                    <div v-for="item in hab1" :key="item.id">  
                      <div v-for="post in item.data1" :key="post.id" >{{post.id}} - {{post.title}} - {{post.content}} - {{post.creationDate}} </div> 
                      </div> 

                       <div v-for="item in this.posts.data" :key="item.id">  {{item.id}} - {{item.title}} - {{item.content}} - {{item.creationDate}} </div>
    {{this.posts}}
  </div>
</template>


<script>
import { AUTH_REQUEST } from '../store/actions/auth';
export default {
  name: 'Dashboard',
  components: {
   
  },

    data() {
    return {
      icons: ["mdi-facebook", "mdi-twitter", "mdi-linkedin", "mdi-instagram"],
      posts: [],
          data1: [
              {
                id: 27,
                title: "post1",
                content: "content1",
                creationDate: "2021-03-29T21:23:54.8592929"
              },
              {
                id: 28,
                title: "post2",
                content: "content2",
                creationDate: "2021-03-29T21:24:01.1085022"
              },
              {
                id: 29,
                title: "post3",
                content: "content3",
                creationDate: "2021-03-29T21:24:06.0869964"
              }],
      hab1: [ 
              {
                data1: [
                    {
                      id: 27,
                      title: "post1",
                      content: "content1",
                      creationDate: "2021-03-29T21:23:54.8592929"
                    },
                    {
                      id: 28,
                      title: "post2",
                      content: "content2",
                      creationDate: "2021-03-29T21:24:01.1085022"
                    },
                    {
                      id: 29,
                      title: "post3",
                      content: "content3",
                      creationDate: "2021-03-29T21:24:06.0869964"
                    }
            ],
            succeeded: true,
            message: null,
            errors: null
            }],
          idd: "ce948dd0-38a5-43d4-87d7-27386cd21760",    
    };
  },

  mounted() {
    // this.data2 = this.hab1.data1;
     this.getPosts();
     this.Login11();
  },

  methods: {
      Login11() {
      console.log(this.$store.getters.isAuthenticated)
      },


    // logout1() {
    // this.$store.dispatch(AUTH_LOGOUT)
    // .then(() => {
    //   this.$router.push('/login')
    // })},


    logout() {
      this.$store.dispatch(AUTH_REQUEST);
       this.$router.push("LoginToAccount");
    },
    getPosts() {

            this.posts = [];     
            this.$axios
                .get(`https://localhost:44381/api/Posts/PostsUser/${this.idd}`
                , {                  
                      headers: {

                          "Content-Type": "application/json",
                         // Authorization: `${localStorage.getItem('user-token')}`
                          'Authorization': 'Bearer ' +localStorage.getItem('user-token'),
                      }
                    })
                .then((res) => {
                
                // console.log(res.data);

                this.posts = res.data;
                // console.info(res.data); 
                console.info(this.$store.getters.authStatus);
                })
                .catch((err) => {
                console.error(err);
                }); 
                
                // console.info("info");   
                console.info(localStorage.getItem('user-token'));   
                
                
            },
  },
}


</script>