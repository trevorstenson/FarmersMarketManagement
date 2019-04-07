<template>
    <div id="market">
      <v-container class="my-1">
        <v-layout row wrap justify-center class="marketInfo">
          <v-flex xs6 md6 lg6>
              Market #{{ clickedMarket.marketId }}:  {{ clickedMarket.name }}
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
                    <td class="text-xs-center">{{ props.item.farmId }}</td>
                  </tr>
                </template>
                </v-data-table>
                </v-flex>
            </template>
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
          }
        }
    }
</script>

<style scoped>
#market {
    margin-top: 100px;
}

.marketInfo {
  background-color: lightblue;
  font-size: 30px;
}
</style>