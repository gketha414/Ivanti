window._ = require('lodash');

window.axios = require('axios');

import Vue from 'vue';
import TriangleCalculator from './components/TriangleCalculator.vue';

Vue.http.headers.common['Access-Control-Allow-Origin'] = true;
Vue.http.headers.common['Access-Control-Allow-Origin'] = '*';
Vue.http.options.emulateJSON = true;
Vue.http.options.credentials = true;
Vue.http.options.emulateHTTP = true;

new Vue({
    el: '#app',
    components: { TriangleCalculator }
});