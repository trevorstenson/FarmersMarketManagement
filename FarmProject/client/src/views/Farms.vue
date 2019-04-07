<template xmlns:v-slot="http://www.w3.org/1999/XSL/Transform">
    <div id="farms">
        <v-container class="my-1">
            <v-layout row wrap justify-center>
                <v-flex xs8 md6 lg6>
                <v-dialog v-model="dialog1" persistent max-width="600px">
      <template v-slot:activator="{ on }">
        <v-btn color="blue darken-2" dark v-on="on">Add Farm</v-btn>
      </template>
      <v-card>
        <v-card-title>
          <span class="headline">New Farm</span>
        </v-card-title>
        <v-card-text>
          <v-container grid-list-md>
            <v-layout justify-center wrap>
              <v-flex xs12 sm6 md4>
                <v-text-field label="Farm Name*" required v-model="newName"></v-text-field>
              </v-flex>
              <v-flex xs12 sm6 md4>
                <v-text-field label="State*" required v-model="newState"></v-text-field>
              </v-flex>
              <v-flex xs12 sm6>
                  <v-text-field label="Main Product*" required v-model="newMainProduct"></v-text-field>
              </v-flex>
            </v-layout>
          </v-container>
          <small>*indicates required field</small>
        </v-card-text>
        <v-card-actions>
          <v-spacer></v-spacer>
          <v-btn color="blue darken-1" flat @click="dialog1 = false">Close</v-btn>
          <v-btn color="blue darken-1" flat @click="addFarm()">Submit</v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>
    </v-flex>
     <v-flex xs8 md6 lg6>
                <v-dialog v-model="dialog2" persistent max-width="600px">
      <template v-slot:activator="{ on }">
        <v-btn color="blue darken-2" dark v-on="on">Delete Farm</v-btn>
      </template>
      <v-card>
        <v-card-title>
          <span class="headline">Delete Farm</span>
        </v-card-title>
        <v-card-text>
          <v-container>
            <v-layout justify-center wrap>
              <v-flex xs12 sm6 md4>
                <v-text-field label="Farm ID*" required v-model="deleteId"></v-text-field>
              </v-flex>
            </v-layout>
          </v-container>
          <small>*indicates required field</small>
        </v-card-text>
        <v-card-actions>
          <v-spacer></v-spacer>
          <v-btn color="blue darken-1" flat @click="dialog2 = false">Close</v-btn>
          <v-btn color="blue darken-1" flat @click="deleteFarm()">Delete</v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>
     </v-flex>
            </v-layout>
            <v-layout row wrap justify-center>
            <template>
                <v-flex xs10 md6 lg5>
                <v-data-table
                    :headers="headers"
                    :items="farms"
                    class="elevation-1"
                >
                <template v-slot:items="props">
                    <td>{{ props.item.name }}</td>
                    <td class="text-xs-center">{{ props.item.state }}</td>
                    <td class="text-xs-center">{{ props.item.mainProduct }}</td>
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
        name: "Farms",
        data() {
            return {
                newName: "",
                newState: "",
                newMainProduct: "",
                deleteId: "",
                dialog1: false,
                dialog2: false,
                farms: [],
                headers: [
          {
            text: 'Farm',
            align: 'left',
            sortable: false,
            value: 'name'
          },
          { text: 'State', value: 'state', sortable: false },
          { text: 'Main Product', value: 'mainProduct', sortable: false },
          { text: 'Farm ID', value: 'farmId' }
        ]
            }
        },
        mounted() {
            this.fetchAllFarms();
        },
        methods: {
            fetchAllFarms() {
                MarketApi.getAllFarms()
                    .then(farms => {
                        this.farms = farms;
                    })
            },
            addFarm() {
                MarketApi.createFarm(this.newName, this.newState, this.newMainProduct)
                    .then(response => {
                        this.dialog1 = false;
                        this.newName = "";
                        this.newState = "";
                        this.newMainProduct = "";
                        this.fetchAllFarms();
                    })
            },
            deleteFarm() {
                MarketApi.removeFarm(this.deleteId)
                    .then(response => {
                        this.dialog2 = false;
                        this.deleteId = "";
                        this.fetchAllFarms();
                    })
            }
        }
    }
</script>

<style scoped>
#farms {
    margin-top: 100px;
}
</style>