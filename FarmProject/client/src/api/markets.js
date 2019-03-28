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
    },
    createVendor(name, count, id) {
        return axios.post('/vendor/', {
            Name: name,
            Stallcount: count,
            FarmId: id
        }).then(response => {
            return response.data;
        })
    },
    getVendorsForMarket(id) {
        return axios.get('/vendor/' + id)
            .then(response => {
                return response.data;
            })
    },
    updateProductCategories(id, categories) {
        return axios.patch('/' + id, {
            categories: categories
        }).then(response => {
            return response.data;
        })
    }
}