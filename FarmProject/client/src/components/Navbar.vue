<template>
    <div id="navbar">
        <v-toolbar class="blue darken-2">
            <v-toolbar-title class="white--text">Farmer's Market Database</v-toolbar-title>
            <v-spacer/>
            <v-toolbar-items>
                <v-btn to="/" flat dark>Home</v-btn>
                <v-btn to="/markets" flat dark>Markets</v-btn>
      </v-toolbar-items>
        </v-toolbar>
    </div>
</template>

<script>
    export default {
        name: "Navbar",
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