import axios from 'axios'

export default {
    getAllMarkets() {
        return axios.get('/market')
            .then(response => {
                return response.data;
            })
            .catch(error => {
                console.log(error.response);
            })
    },
    getMarketsByState(state) {
        return axios.get('/market/' + state)
            .then(response => {
                return response.data;
            })
            .catch(error => {
                console.log(error.response);
            })
    },
    getAllFarms() {
        return axios.get('/farm')
            .then(response => {
                return response.data;
            })
            .catch(error => {
                console.log(error);
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
        .catch(error => {
            console.log(error.response);
        })
    },
    removeFarm(id) {
        return axios.delete('/farm/' + id)
            .then(response => {
                return response.data;
            })
            .catch(error => {
                console.log(error.response);
            })
    },
    createVendor(name, count, id, marketId) {
        return axios.post('/vendor/', {
            Name: name,
            Stallcount: count,
            FarmId: id,
            MarketId: marketId
        }).then(response => {
            return response.data;
        })
        .catch(error => {
            console.log(error.response);
        })
    },
    deleteVendor(id) {
        return axios.delete('/vendor/' + id)
            .then(response => {
                return response.data;
            })
            .catch(error => {
                console.log(error.response);
            })
    },
    getVendorsForMarket(id) {
        return axios.get('/vendor/' + id)
            .then(response => {
                return response.data;
            })
            .catch(error => {
                console.log(error.response);
            })
    },
    updateProductCategories(id, categories) {
        return axios.patch('/vendor/' + id, categories)
            .then(response => {
            return response.data;
        })
        .catch(error => {
            console.log(error.response);
        })
    },
    getAllCategories() {
        return axios.get('/product/')
            .then(response => {
                return response.data;
            })
            .catch(error => {
                console.log(error.response);
            })
    },
    getVendorCategories(id) {
        return axios.get('/product/' + id)
            .then(response => {
                return response.data;
            })
            .catch(error => {
                console.log(error.response);
            })
    }
}