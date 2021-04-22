<template>

    <div class="habit-item" @click="favoriteMessage(habit.id)">
        <div class="user-profile__habit_pro"  v-if="habit.id == favoriteMessageId" >
            <div class="habit-item__user">
                {{habit.id}}
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
            {{hide}}
        </div>

        
        <div v-else class="user-profile__habit_pro" >
            <div class="habit-item__user">
                   {{habit.id}}
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
    <v-checkbox
        v-model="checkbox"
        
        :label="`Checkbox 1: ${checkbox.toString()}`"
        @click="updateDateInfo(habitDateInfo.id, checkbox.toString())"
      ></v-checkbox>

      {{this.check}}
        {{this.habitDateInfo}}
      <!--  -->
        <!-- <div v-for="date in hD" :key="date.id"> 
            <v-checkbox

                v-model="checkbox"
                :label="`Checkbox 1: ${checkbox.toString()}`"
              
              color="yellow"
              value="yellow"
              @click="dateInfo(date.id)"
              hide-details
              
            /> 
           id: {{date.id}}, habitID : {{date.habitId}}, date: {{date.dateOfHabit}}     
            <v-checkbox
        v-model="checkbox"
        
        :label="`Checkbox 1: ${checkbox.toString()}`"
        @click="updateDateInfo(date.id, checkbox.toString())"
      ></v-checkbox>
      </div>  -->

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
        habitDateInfo: [],
        checkbox: false,
        }
    },
    props: {
        hide: {
            type: Boolean
        },
        check: {
            type: Boolean
        },
        imp: {
            type: String,
        },
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
                          'Authorization': 'Bearer ' + localStorage.getItem('user-token'),
                      }
                    })
                .then((res) => {
                
                this.hD = res.data;
                //console.log( this.hD)
                
                })
                .catch((err) => {
                console.error(err);
                });           
            },
           
            updateDateInfo(id, isClicked ){
                  this.$emit('testEvent');
            this.habitDateInfo.ifHabitDone = ! this.habitDateInfo.ifHabitDone;

             this.$axios
            .put(`https://localhost:44312/api/HabitDate`, this.habitDateInfo)
            .then(res => {
                // console.log("Update!")
                // console.log(res.data)
            })
             .catch(err => {
                console.error(err);
             });

            console.log(id + isClicked)
            //  this.$parent.getHabits();
            
            },

            getLast(id){
                console.log(id);
                this.habitDateInfo = [];   
                this.$axios
                .get(`https://localhost:44312/api/HabitDate/Last/${id}`
                , {                  
                      headers: {
                          "Content-Type": "application/json",
                          'Authorization': 'Bearer ' + localStorage.getItem('user-token'),
                      }
                    })
                .then((res) => {           
                this.habitDateInfo = res.data;
                //console.log( this.habitDateInfo)
                })
                .catch((err) => {
                console.error(err);
                });            
            },

            //--------------------
            dateInfo(id){
                console.log("you clicked date about id:" + id)
            },
            
        },
    mounted(){
        this.checkbox = this.check;
        this.getHabitDate(this.habit.id);
        this.getLast(this.habit.id);
    },
    watch: {

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
        background-color: white;
    }
        .user-profile__habit {
        background-color: yellow;
                    .habit-item__user {
             font-weight: bold;
         }
    }

    .habit-item_content{
        margin-top: 5px;
    }
</style>