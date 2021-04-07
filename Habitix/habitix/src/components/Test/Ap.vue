<template>
  <div id="ap">
    <ClickCountButton></ClickCountButton>
    <Message/>
  </div>
</template>

<script>
import { EventBus } from './event-bus';
import ClickCountButton from './ClickCountButton'
import Message from './Events/Message.vue';

export default {
  name: 'Ap',
  components: {
    ClickCountButton,
    Message
  }
}


const clickHandler = function(clickCount) {
  console.log(`The button has been clicked ${clickCount} times!`)
}

EventBus.$on('clicked', clickHandler);

EventBus.$off('clicked', clickHandler);
</script>