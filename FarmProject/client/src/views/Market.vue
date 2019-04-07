<template>
    <div id="market">
      <v-container class="my-1">
        <v-layout row wrap justify-center class="marketInfo mb-3 elevation-2">
          <v-flex xs6 md6 lg6>
              Market:  {{ clickedMarket.name }}
          </v-flex>
          <v-flex>
              State: {{ clickedMarket.state }}
          </v-flex>
          <v-flex>
            Credit: {{ clickedMarket.credit }}
          </v-flex>
        </v-layout>
        <v-layout row wrap justify-space-around>
          <v-flex xs1 md3 lg3>
            <v-card>
              <v-card-title primary-title>
                <div>
                  <h3 class="headline mb-0">Add a Vendor</h3>
                </div>
              </v-card-title>
              <v-text-field label="Name*" required v-model="newName"></v-text-field>
              <v-text-field label="Stall Count*" required v-model="newStallcount"></v-text-field>
              <v-text-field label="Farm ID*" required v-model="newFarmId"></v-text-field>
              <v-card-actions>
                <v-btn color="blue darken-1" flat @click="addVendor()">Submit</v-btn>
              </v-card-actions>
            </v-card>
          </v-flex>
            <template>
                <v-flex xs10 md6 lg4>
                <v-data-table
                    :headers="headers"
                    :items="vendors"
                    class="elevation-1"
                >
                <template v-slot:items="props">
                  <tr @click="toSpecificVendor(props.item)">
                    <td>{{ props.item.name }}</td>
                    <td class="text-xs-center">{{ props.item.stallcount }}</td>
                    <td class="text-xs-center">{{ props.item.vendorId }}</td>
                  </tr>
                </template>
                </v-data-table>
                </v-flex>
            </template>
            <v-flex lg2>
                <div class="headline mb-2">Delete Vendor</div>
                <v-text-field v-model="deleteVendorId"
                              label="Vendor ID"
                              solo
                ></v-text-field>
                <v-btn class="blue darken-2 white--text" @click="deleteVendor()">Delete</v-btn>
            </v-flex>
            </v-layout>
      </v-container>
    </div>
</template>

<script>
    import MarketApi from '../api/markets'

    export default {
        name: "Market",
        data() {
            return {
                deleteVendorId: "",
                newName: "",
                newStallcount: "",
                newFarmId: "",
                clickedMarket: null,
                vendors: [],
                headers: [
          {
            text: 'Vendor',
            align: 'left',
            sortable: false,
            value: 'name'
          },
          { text: 'Stall Count', value: 'stallcount', sortable: false },
          { text: 'Vendor ID', value: 'vendorId' }
        ]
            }
        },
        created() {
          this.clickedMarket = this.$route.params.market;
        },
        mounted() {
          this.getMarketVendors();
        },
        methods: {
          getMarketVendors() {
            MarketApi.getVendorsForMarket(this.clickedMarket.marketId)
                .then(response => {
                  this.vendors = response;
                })
          },
          toSpecificVendor(vendor) {
            this.$router.push({ name: 'Vendor', params: { vendor } })
          },
          addVendor() {
            MarketApi.createVendor(this.newName, this.newStallcount, this.newFarmId, this.clickedMarket.marketId)
                .then(response => {
                  this.newName = "";
                  this.newStallcount = "";
                  this.newFarmId = "";
                  this.getMarketVendors();
                })
          },
            deleteVendor() {
              MarketApi.deleteVendor(this.deleteVendorId)
                  .then(response => {
                      this.getMarketVendors();
                  })
            }
        }
    }
</script>

<style scoped>
#market {
    margin-top: 100px;
}

.marketInfo {
  background-color: lightgray;
  font-size: 30px;
}
</style>