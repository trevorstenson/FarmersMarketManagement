<template>
    <div id="markets">
        <v-container class="my-1">
            <v-layout row wrap justify-center>
                <v-flex xs6 md4 lg2>
                    <v-text-field v-model="searchTerm"
                        label="State"
                        solo
                    ></v-text-field>
                </v-flex>
                <v-flex xs6 md1 lg1>
                    <v-btn class="blue darken-2 white--text" @click="getMarketsByState(searchTerm)">Search</v-btn>
                </v-flex>
            </v-layout>
            <v-layout row wrap justify-center justify-space-around>
                <v-flex md3>
                    <v-card>
                        <v-card-title><div class="headline mb-0">Markets</div></v-card-title>
                        <v-divider></v-divider>
                    <v-list two-line>
                        <template v-for="(market, index) in markets">
                        <v-list-tile avatar ripple :key="index" @click="">
                            <v-list-tile-content>
                                <v-list-tile-title v-text="market.name" class="text--primary"></v-list-tile-title>
                                <v-list-tile-sub-title v-text="market.state"></v-list-tile-sub-title>
                            <v-list-tile-sub-title>Credit: {{ market.credit }}</v-list-tile-sub-title>
                            </v-list-tile-content>
                        </v-list-tile>
                        <v-divider v-if="index + 1 < markets.length" :key="`divider-${index}`"></v-divider>
                        </template>
                    </v-list>
                    </v-card>
                </v-flex>
                <v-flex md7>
                    <Map id="map" :markets="markets"/>
                </v-flex>
            </v-layout>
        </v-container>
    </div>
</template>

<script>
    import Map from '../components/Map.vue'

    import MarketApi from '../api/markets'

    export default {
        name: "Markets",
        components: {
            Map
        },
        data() {
            return {
                markets: [],
                searchTerm: ""
            }
        },
        mounted() {
            this.fetchAllMarkets();
        },
        methods: {
            fetchAllMarkets() {
                MarketApi.getAllMarkets()
                    .then(markets => {
                        console.log(markets);
                        this.markets = markets;
                    })
            },
            getMarketsByState(state) {
                MarketApi.getMarketsByState(state)
                    .then(markets => {
                        this.markets = markets;
                    })
            }
        }
    }
</script>

<style scoped>
#markets {
    margin-top: 100px;
}

.v-list {
    height: 533px;
    overflow-y: auto;
}
</style>