<template>
    <div id="vendors">
        <v-container class="my-1">
            <v-layout row wrap justify-center>
                <v-flex xs8 md6 lg6>
                <v-dialog v-model="dialog1" persistent max-width="600px">
      <template v-slot:activator="{ on }">
        <v-btn color="blue darken-2" dark v-on="on">Add Vendor</v-btn>
      </template>
      <v-card>
        <v-card-title>
          <span class="headline">New Vendor</span>
        </v-card-title>
        <v-card-text>
          <v-container grid-list-md>
            <v-layout justify-center wrap>
              <v-flex xs12 sm6 md4>
                <v-text-field label="Vendor Name*" required v-model="newName"></v-text-field>
              </v-flex>
              <v-flex xs12 sm6 md4>
                <v-text-field label="Stall Count*" required v-model="newCount"></v-text-field>
              </v-flex>
              <v-flex xs12 sm6>
                  <v-text-field label="Farm ID*" required v-model="newID"></v-text-field>
              </v-flex>
            </v-layout>
          </v-container>
          <small>*indicates required field</small>
        </v-card-text>
        <v-card-actions>
          <v-spacer></v-spacer>
          <v-btn color="blue darken-1" flat @click="dialog1 = false">Close</v-btn>
          <v-btn color="blue darken-1" flat @click="addVendor()">Submit</v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>
    </v-flex>
            </v-layout>
        </v-container>
    </div>
</template>

<script>
    import MarketApi from '../api/markets'

    export default {
        name: "Vendors",
        data () {
            return {
                newName: "",
                newCount: null,
                newID: "",
                dialog1: false
            }
        },
        methods: {
            addVendor() {
              MarketApi.createVendor(newName, newCount, newID)
                  .then(response => {
                    this.dialog1 = false;
                    this.newName = "";
                    this.newCount = null;
                    this.newID = "";
                  })
            }
        }
    }
</script>

<style scoped>
#vendors {
    margin-top: 100px;
}
</style>