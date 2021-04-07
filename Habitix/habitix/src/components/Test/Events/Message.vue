<template>
    <div>
        <h1>{{message}}</h1>
        <app-input :msg="message" @messageChanged="message = $event"></app-input>
        
    </div>
</template>

<script>
    import Input from './Input.vue';

    export default {
        name: 'Message',
        data() {
            return {
                message: 'This is a great message!'
            }
        },
        components: {
            'app-input': Input
        },
        methods: {
                    Ref() {
                    console.log("ref");
            }
        },
        mounted() {
            this.Ref();
        }
    }
</script>