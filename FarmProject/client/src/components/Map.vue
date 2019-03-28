<template>
    <GmapMap
        :center="center"
        :zoom="3"
        style="width: 100%; height: 600px"
    >
    <GmapMarker
    :key="index"
    v-for="(m, index) in markets"
    :position="{ lat: m.lat, lng: m.lng }"
    :clickable="true"
    :draggable="true"
    @click="center={ lat: m.lat, lng: m.lng }"
  />
    </GmapMap>
</template>

<script>
    export default {
        name: "Map",
        props: {
            markets: Array
        },
        data() {
            return {
                center: { lat: 45.508, lng: -73.587 }
            }
        },
        mounted() {
            this.geolocate();
        },
        methods: {
            geolocate() {
                navigator.geolocation.getCurrentPosition(position => {
                    this.center = {
                        lat: position.coords.latitude,
                        lng: position.coords.longitude
                    };
                });
            }
        }
    }
</script>

<style scoped>

</style>