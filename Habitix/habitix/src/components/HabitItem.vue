<template>
    <div class="habit-item" @click="favoriteMessage(habit.id)">
        <div class="user-profile__habit_pro"  v-if="habit.id == favoriteMessageId" >
            <div class="habit-item__user">
                {{ habit.habitDescription }}
            </div>
            <div class="habit-item_content">
                {{ habit.habitName }}
            </div>
             <v-checkbox            
              label="yellow"
              color="yellow"
              value="yellow"
              hide-details
            />
        </div>

        
        <div v-else class="user-profile__habit" >
            <div class="habit-item__user">
               {{ habit.habitDescriptsion }}
            </div>
            <div class="habit-item_content">
                {{ habit.habitName }}
            </div>
            <v-checkbox
              label="yellow"
              color="yellow"
              value="yellow"
              hide-details
            />
        </div>

        <div v-for="date in hD" :key="date.id"> 
            <v-checkbox


              label="yellow"
              color="yellow"
              value="yellow"
              @click="dateInfo(date.id)"
              hide-details
              
            /> {{date.id}}, {{date.habitId}}, {{date.instanceData}}      
            <v-checkbox
        v-model="checkbox"
        :label="`Checkbox 1: ${checkbox.toString()}`"
        @click="updateDateInfo(date.id, checkbox.toString())"
      ></v-checkbox>
      </div>

                        <!-- <v-btn
                  color="indigo darken-1"
                  @click="getHabitDate(habit.id)"
                  large>
                  <v-icon>mdi-plus</v-icon>
                </v-btn> -->
    </div>
</template>

<script>
export default {
    name: "HabitItem",
    data() {
        return {
        favoriteMessageId: 0,
        hD :[],
        checkbox: false,
        }
    },
    props: {
        
        habit: {
            type: Object,
            required: true,
        }
    },
    methods: {
        favoriteMessage(id) {
            this.$emit('favorite', id);          
            this.favoriteMessageId = id;
        },
        getHabitDate(id) {
            this.hD = [];     
            this.$axios
                .get(`https://localhost:44312/api/HabitDate/${id}`
                , {                  
                      headers: {
                          "Content-Type": "application/json",
                          'Authorization': 'Bearer ' +localStorage.getItem('user-token'),
                      }
                    })
                .then((res) => {
                this.hD = res.data;
                })
                .catch((err) => {
                console.error(err);
                });           
            },
            dateInfo(id){
                console.log("you clicked date about id:" + id)
            },
            updateDateInfo(id, isClicked ){
                    // this.hDUpdate = 
                    console.log(id + isClicked)
            }
            
        },
    mounted(){
    this.getHabitDate(this.habit.id);
    }
    

};
</script>

<style lang ="scss" scoped>
    .habit-item {
        padding: 20px;
        background-color: white;
        border-radius: 5px;
        border: 1px solid #DFE3E8;
        box-sizing: border-box;
        cursor: pointer;
        transition: all 0.25s ease;
        width: 50%;

        &:hover{
             transform: scale(1.1, 1.1);
         }


    }
            .habit-item__user {
             font-weight: bold;
         }

         .user-profile__habit_pro {
        background-color: blue;
    }
        .user-profile__habit {
        background-color: red;
                    .habit-item__user {
             font-weight: bold;
         }
    }

    .habit-item_content{
        margin-top: 5px;
    }
</style>