<template>
  <div class="footer">     
    <footer> footer </footer>
  </div>
</template>

<script>
export default {
  name: "Fot",
  components: {

  },
  data() {
    return {
      icons: ["mdi-facebook", "mdi-twitter", "mdi-linkedin", "mdi-instagram"],
      loading: false
    };
  },
};
</script>

<style lang ="scss" scoped>
  .footer {
    background-color: black;
    font-size: 40px;
    color: blue;
    text-align: center;
  }
</style>



