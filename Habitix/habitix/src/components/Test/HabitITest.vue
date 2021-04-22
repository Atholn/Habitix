<template>
    <div >
       <button v-on:click="updateTitle"> up </button>
    </div>
</template>

<script>
export default {

    name: 'HabitITest',
    methods: {
          updateTitle(){
             this.$emit('changeTitle', 'Props has beed paassed');
          }  
        }

    

};
</script>

