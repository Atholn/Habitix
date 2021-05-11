<template>
    <div class="habit-item">
        <div class="user-profile__habit_pro"   >
            <div class="habit-item__user">
                {{ habit.id}}
                {{ habit.habitName }}             
            </div>
            <div class="habit-item_content">
                 {{ habit.habitDescription }}   
            </div>
        </div>
        <v-checkbox
            v-model="checkbox"
            :label="`${checkbox.toString()}`"
            @click="updateDateInfo(habitDateInfo.id, checkbox.toString())"
        ></v-checkbox>
    </div>
</template>

<script>
export default {

    name: "HabitItem",
    data() {
        return {
        habitDateInfo: [],
        checkbox: false,

        //habitDates :[],
        }
    },

    props: {
        check: {
            type: Boolean
        }, 
        habit: {
            type: Object,
            required: true,
        }
    },

    methods: {        
        updateDateInfo(id, isClicked ){         
        this.habitDateInfo.ifHabitDone = ! this.habitDateInfo.ifHabitDone;
        this.$axios
        .put(`https://localhost:44312/api/HabitDate`, this.habitDateInfo)
        .then(res => {
        })
            .catch(err => {
            console.error(err);
            }); 
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
            })
            .catch((err) => {
            console.error(err);
            });            
        },
        
        getHabitDates(id) {
            this.habitDates = [];     
            this.$axios
                .get(`https://localhost:44312/api/HabitDate/${id}`
                , {                  
                      headers: {
                          "Content-Type": "application/json",
                          'Authorization': 'Bearer ' + localStorage.getItem('user-token'),
                      }
                    })
                .then((res) => {              
                this.habitDates = res.data;
                })
                .catch((err) => {
                console.error(err);
                });           
            },
    },
    mounted(){
        this.checkbox = this.check;
        this.getLast(this.habit.id);
        //this.getHabitDate(this.habit.id);
    },
    
    watch: {
    }
};
</script>

<style lang ="scss" scoped>
    .habit-item {
        width: 100%;
        height: 100%;
        padding: 20px;
        background-color: white;
        border-radius: 5px;
        border: 1px solid #0073ff;
        box-sizing: border-box;
        cursor: pointer;
        transition: all 0.25s ease;

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