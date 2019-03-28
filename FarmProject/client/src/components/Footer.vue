<template>
    <v-footer height="auto" app>
        <v-flex
        class="blue darken-2"
        py-3
        text-xs-center
        white--text
        xs12
      >
        {{ new Date().getFullYear() }} — <strong>Trevor Stenson and Samantha Hoch</strong>
      </v-flex>
  </v-footer>
</template>

<script>
    export default {
        name: "Footer",
        components: {

        },
        data() {
            return {
                
            }
        }
    }
</script>

<style scoped>

</style>