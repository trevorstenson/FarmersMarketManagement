import axios from 'axios'

export default {
    getAllMarkets() {
        return axios.get('/market')
            .then(response => {
                return response.data;
            })
    },
    getMarketsByState(state) {
        return axios.get('/market/' + state)
            .then(response => {
                return response.data;
            })
    },
    getAllFarms() {
        return axios.get('/farm')
            .then(response => {
                return response.data;
            })
    },
    createFarm(name, state, mainProduct) {
        return axios.post('/farm', {
            Name: name,
            State: state,
            MainProduct: mainProduct
        }).then(response => {
            return response.data;
        })
    },
    removeFarm(id) {
        return axios.delete('/farm/' + id)
            .then(response => {
                return response.data;
            })
    }
}