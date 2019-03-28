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
        <v-layout row wrap justify-center>
            <template>
                <v-flex xs10 md6 lg4>
                <v-data-table
                    :headers="headers"
                    :items="vendors"
                    class="elevation-1"
                >
                <template v-slot:items="props">
                    <td>{{ props.item.name }}</td>
                    <td class="text-xs-center">{{ props.item.stallcount }}</td>
                    <td class="text-xs-center">{{ props.item.farmId }}</td>
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
            MarketApi.getVendorsForMarket(clickedMarket.marketId)
                .then(response => {
                  this.vendors = response;
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