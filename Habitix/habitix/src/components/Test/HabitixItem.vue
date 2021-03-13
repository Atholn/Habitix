<template>
 
    <div class="habitix-item" @click="favoriteMessage(message.id)">
        <div class="user-profile__habitix_pro"  v-if="message.id == favoriteMessageId" >
            <div class="habitix-item__user">
                @{{ username }}
            </div>
            <div class="habitix-item_content">
                {{ message.content }}
            </div>
        </div>
        <div v-else class="user-profile__habitix">
            <div class="habitix-item__user">
                @{{ username }}
            </div>
            <div class="habitix-item_content">
                {{ message.content }}
            </div>
            <div class="habitix-item_content">     

    </div>
        </div>
    </div>

</template>

<script>
export default {
    name: "HabitixItem",
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
        message: {
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
    .habitix-item {
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
        .habitix-item__user {
             font-weight: bold;
         }

    }

    .user-profile__habitix_pro {
        background-color: tomato;

    }

    .habitix-item_content{
        margin-top: 5px;
    }
</style>