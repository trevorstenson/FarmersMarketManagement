<template>
    <div id="home">
        <v-container>
            <v-layout row justify-around-center>
                <v-flex lg6>
                    <v-img class="elevation-3" width="512px" :src="require('../assets/diagram.png')"></v-img>
                    <br>
                    <v-img class="elevation-3" width="512px" :src="require('../assets/architecture.png')"></v-img>
                </v-flex>
                <v-flex lg6>
                    <v-card class="elevation-3">
                        <v-card-text>
                            <span class="headline text-md-center">Our Project</span>
                        </v-card-text>
                        <v-divider></v-divider>
                        <v-card-text>
                            <span class="title"><u>Purpose</u></span>
                            <br><br>
                            <div>
                                <ul class="subheading text-md-left">
                                    <li>A system for managing a network of farmer's markets that models relationships
                                        between specific farms, vendors, and markets.
                                    </li>
                                    <br>
                                    <li>Users can quickly locate markets, see participating vendors, and view the available product categories.
                                    </li>
                                </ul>
                            </div>
                        </v-card-text>
                        <v-divider></v-divider>
                        <v-card-text>
                            <span class="title"><u>Supported Functionality</u></span>
                            <br><br>
                            <ul class="subheading text-md-left">
                                <li>Displaying all markets with their locations</li>
                                <br>
                                <li>Creating and deleting farms from the database</li>
                                <br>
                                <li>Creating and deleting vendors for a specific farm</li>
                                <br>
                                <li>Modifying the product categories sold by a vendor</li>
                            </ul>
                        </v-card-text>
                        <v-divider></v-divider>
                        <v-card-text>
                            <span class="title"><u>Technologies used</u></span>
                            <br>
                            <br>
                            <span class="font-weight-bold">MySQL | .NET Core | VueJS | Azure | C# | JavaScript</span>
                        </v-card-text>
                        <v-divider></v-divider>
                    </v-card>
                </v-flex>
            </v-layout>
        </v-container>
    </div>
</template>

<script>

    export default {
        name: "Home",
    }
</script>

<style scoped>
    #home {
        margin-top: 100px;
    }

    #projectInfo {
        display: flex;
    }
</style>