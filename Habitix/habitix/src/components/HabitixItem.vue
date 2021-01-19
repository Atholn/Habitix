<template>
    <div class="habitix-item">
        <div class="user-profile__habitix">
            <div class="habitix-item__user">
                @{{ username }}
            </div>
            <div class="habitix-item_content">
                {{ message.content }}
            </div>
        </div>
    </div>
</template>

<script>
export default {
    name: "HabitixItem",
    props: {
        username: {
            type: String,
            required: true
        },
        message: {
            type: Object,
            required: true,
        }
    }
};
</script>

<style>
    .habitix-item {
        padding: 20px;
        background-color: white;
        border-radius: 5px;
        border: 1px solid #DFE3E8;
        box-sizing: border-box;
        cursor: pointer;
        transition: all 0.25s ease;
    }
    
    .habitix-item:hover{
        transform: scale(1.1, 1.1);
    }
    .habitix-item_content{
        margin-top: 5px;
    }
    .habitix-item__user {
        font-weight: bold;
    }
</style>