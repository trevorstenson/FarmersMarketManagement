<template>
<div id="navigation">
    <v-navigation-drawer :clipped="clipped" v-model="drawer" enable-resize-watcher app temporary absolute class="grey lighten-3">
            <v-list>
                <v-list-tile to="/">
                    <v-list-tile-action>
                        <v-icon>home</v-icon>
                    </v-list-tile-action>
                    <v-list-tile-title class="title">Home</v-list-tile-title>
                </v-list-tile>

                <v-list-tile to="/markets">
                    <v-list-tile-action>
                        <v-icon>location_on</v-icon>
                    </v-list-tile-action>
                    <v-list-tile-title class="title">Markets</v-list-tile-title>
                </v-list-tile>

                <v-list-tile to="/farms">
                    <v-list-tile-action>
                        <v-icon>local_florist</v-icon>
                    </v-list-tile-action>
                    <v-list-tile-title class="title">Farms</v-list-tile-title>
                </v-list-tile>
                <v-list-tile to="/vendors">
                    <v-list-tile-action>
                        <v-icon>shopping_cart</v-icon>
                    </v-list-tile-action>
                    <v-list-tile-title class="title">Vendors</v-list-tile-title>
                </v-list-tile>
            </v-list>
    </v-navigation-drawer>
        <v-toolbar fixed app :clipped-left="clipped" class="blue darken-2">
            <v-toolbar-side-icon @click.stop="drawer = !drawer"></v-toolbar-side-icon>
            <v-toolbar-title class="white--text">Farmer's Market Database</v-toolbar-title>
            <v-spacer/>
            <v-toolbar-items>
                <v-btn to="/" flat dark>Home</v-btn>
                <v-btn to="/markets" flat dark>Markets</v-btn>
                <v-btn to="/farms" flat dark>Farms</v-btn>
                <v-btn to="/vendors" flat dark>Vendors</v-btn>
      </v-toolbar-items>
        </v-toolbar>
    </div>
</template>

<script>
    export default {
        name: "NavigationDrawer",
        components: {

        },
        data() {
            return {
                drawer: false,
                clipped: false,
                farmFunctions: [
                    ['Add Farm', 'add'],
                    ['Delete Farm', 'delete']
                ] 
            }
        }
    }
</script>

<style scoped>
    
</style>