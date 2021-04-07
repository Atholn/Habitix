<template>
  <div><v-btn @click="emitGlobalClickEvent()">{{ clickCount }}</v-btn> </div>
</template>

<script>
import { EventBus } from './event-bus';

export default {
  data() {
    return {
      clickCount: 0
    }
  },

  methods: {
    emitGlobalClickEvent() {
      this.clickCount++;
      EventBus.$emit('clicked', this.clickCount);
    }
  }
}
</script>