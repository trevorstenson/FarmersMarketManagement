<template>
    <div id="vendor">
        <div>
            <v-container class="my-1">
                <v-layout row wrap justify-space-around>
                    <v-flex sm2 lg3>
                        <v-card hover>
                            <v-card-title>
                                    <h3 class="headline mb-3 mt-3 ma-auto">Product Categories</h3>
                            </v-card-title>
                            <v-divider></v-divider>
                            <v-checkbox class="ml-4" v-for="p in allCategories" v-model="selected" :key="p.categoryId" :label="p.categoryName" :value="p.categoryId"></v-checkbox>
                            <v-btn flat class="blue darken-2 white--text" @click="updateCategories()">Update categories</v-btn>
                        </v-card>
                    </v-flex>
                    <v-flex sm2 lg4>
                        <v-card elevation="2">
                            <v-card-title>
                                <h3 class="headline mb-3 mt-3 ma-auto">{{ clickedVendor.name }}</h3>
                            </v-card-title>
                            <v-divider></v-divider>
                            <v-list>
                                <template v-for="(p, index) in vendorCategories">
                                    <v-list-tile avatar ripple :key="index">
                                        <v-list-tile-content>
                                            {{ p.categoryName }}
                                        </v-list-tile-content>
                                    </v-list-tile>
                                    <v-divider v-if="index + 1 < vendorCategories.length" :key="`divider-${index}`"></v-divider>
                                </template>
                            </v-list>
                        </v-card>
                    </v-flex>
                </v-layout>
            </v-container>
        </div>
    </div>
</template>

<script>
    import MarketApi from '../api/markets'

    export default {
        name: "Vendor",
        data() {
            return {
                clickedVendor: null,
                vendorCategories: [],
                allCategories: [],
                selected: []
            }
        },
        created() {
            this.clickedVendor = this.$route.params.vendor;
        },
        mounted() {
            this.getVendorCategories();
            this.getAllCategories();
        },
        methods: {
            getVendorCategories() {
                MarketApi.getVendorCategories(this.clickedVendor.vendorId)
                    .then(response => {
                        this.vendorCategories = response;
                    })
            },
            getAllCategories() {
                MarketApi.getAllCategories()
                    .then(response => {
                        this.allCategories = response;
                    })
            },
            updateCategories() {
                console.log(this.selected.toString());
                MarketApi.updateProductCategories(this.clickedVendor.vendorId, this.selected)
                    .then(response => {
                        this.selected = [];
                        this.getVendorCategories();
                    })
            }
        }
    }
</script>

<style scoped>
    #vendor {
        margin-top: 100px;
    }

    .v-list {
        height: 200px;
        overflow-y: auto;
    }
</style>