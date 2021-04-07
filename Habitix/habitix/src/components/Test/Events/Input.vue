<template>
    <div>     
        <input type="text" :value="msg" @input="changeMessage">
        <p> {{message}} </p>
        <v-btn        
        @click="Add()"
        >{{message}}</v-btn>
    </div>
</template>

<script>
export default {
    props: ['msg'],
    data() {
        return {
            message: '',
        }
    },
    methods: {
        changeMessage(event) {
            this.message = event.target.value;
            this.$emit('messageChanged', this.message);
        },
        Add(event) {
            this.message = event.target.value;
            this.$emit('messageChanged', this.message);
        },

    }

}
</script>