<template>
    <div id="vendor">
        <div>
            <v-container class="my-1">
                <v-layout row wrap justify-center>
                    <v-flex sm2 lg3>
                        <v-card hover="true">
                            <v-card-title>
                                    <h3 class="headline mb-0">Product Categories</h3>
                            </v-card-title>
                            <v-layout column id="thin">hii</v-layout>
                            <v-checkbox class="" v-for="p in allCategories" v-model="selected" :label="p.categoryName" :value="p.categoryId"></v-checkbox>
                            <v-btn flat class="blue darken-2 white--text">Update categories</v-btn>
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
                productCategories: [],
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
                        this.productCategories = response;
                    })
            },
            getAllCategories() {
                MarketApi.getAllCategories()
                    .then(response => {
                        console.log(response);
                        this.allCategories = response;
                    })
            }
        }
    }
</script>

<style scoped>
    #vendor {
        margin-top: 100px;
    }
    
    #thin {
        min-width: 30px;
        max-width: 30px;
    }
</style>