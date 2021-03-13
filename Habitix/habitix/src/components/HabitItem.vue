<template>
    <div class="habit-item" @click="favoriteMessage(habit.id)">
        <div class="user-profile__habitix_pro"  v-if="habit.id == favoriteMessageId" >
            <div class="habitix-item__user">
                {{ habit.habitDescription }}
            </div>
            <div class="habitix-item_content">
                {{ habit.habitName }}
            </div>
                                             <v-checkbox
              v-model="ex4"
              label="yellow"
              color="yellow"
              value="yellow"
              hide-details
            />
        </div>
        <div v-else class="user-profile__habitix" >
            <div class="habitix-item__user">
               {{ habit.habitDescriptsion }}
            </div>
            <div class="habitix-item_content">
                {{ habit.habitName }}
            </div>
                                 <v-checkbox
              v-model="ex4"
              label="yellow"
              color="yellow"
              value="yellow"
              hide-details
            />
        </div>
    </div>
</template>

<script>
export default {
    name: "HabitItem",
    data() {
        return {
        favoriteMessageId: 0,
        }
    },
    props: {
        username: {
            type: String,
            required: true
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


        }
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


        &:hover{
             transform: scale(1.1, 1.1);
         }
        .habit-item__user {
             font-weight: bold;
         }

    }

    .user-profile__habitix_pro {
        background-color: blue;
    }

    .habitix-item_content{
        margin-top: 5px;
    }
</style>