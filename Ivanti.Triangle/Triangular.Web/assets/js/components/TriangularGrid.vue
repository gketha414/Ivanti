<template>
    <div>
        <div class="row">
            <div class="col-6">
                <div class="grid" v-if="canShowGrid">
                    <h2>Select a Triangle</h2>

                    <svg :style="{ width: (Math.ceil(width/10)*10) +'px', height: (Math.ceil(height/10)*10)+'px', cursor: 'pointer' }">
                        <template v-for="row in rows">
                            <template v-for="column in columns">
                                <polygon :class="{ 'leftTriangle': true, 'active': active == getRef(row, (column * 2) - 1)}" :points="getFirstTriangle(row, column)" @click="triangleClicked(row, (column * 2) - 1)"></polygon>
                                <polygon :class="{ 'rightTriangle': true, 'active': active == getRef(row, column * 2)}" :points="getSecondTriangle(row, column)" @click="triangleClicked(row, column * 2)"></polygon>
                            </template>
                        </template>
                    </svg>

                    <hr />

                    <small>{{ width }} x {{ height }} grid, {{ rows }} rows x {{ columns }} columns</small>
                </div>
                <div v-else class="alert alert-warning">
                    <strong>Unable to display grid</strong>

                    Please ensure your cell size is divisible by the height and width of the grid.
                </div>
            </div>
            <div class="col-6">
                <div v-if="triangleLoading">
                    <p>Fetching coordinates for {{ active }}</p>
                </div>
                <div v-else-if="triangleCoordinates.length > 0">
                    <h2>Coordinates for {{ active }}</h2>

                    <ul>
                        <li v-for="triangleCoordinate in triangleCoordinates">X: {{ triangleCoordinate.x }}, Y: {{ triangleCoordinate.y }}</li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
    export default {
        props: ['width', 'height', 'cellSize'],

        data() {
            return {
                active: '',
                triangleLoading: false,
                triangleCoordinates: []
            }
        },

        watch: {
            width() {
                this.active = '';
                this.triangleCoordinates = [];
            },

            height() {
                this.active = '';
                this.triangleCoordinates = [];
            },

            cellSize() {
                this.active = '';
                this.triangleCoordinates = [];
            }
        },

        computed: {
            canShowGrid() {
                if (this.cellSize > this.width || this.cellSize > this.height) {
                    return false;
                }

                if (this.width % this.cellSize > 0 || this.height % this.cellSize > 0) {
                    return false;
                }

                return true;
            },

            rows() {
                let rows = Math.ceil(this.height / this.cellSize);

                if (rows > 26) return 26;

                return rows;
            },

            columns() {
                let columns = Math.ceil(this.width / this.cellSize);

                if (columns > 26) return 26;

                return columns;
            }
        },

        methods: {
            triangleClicked(row, column) {
                let ref = this.getRef(row, column)
                this.triangleLoading = true;

                this.active = ref

                let data = {
                    'GridWidth': (Math.ceil(this.width/10) * 10),
                    'GridHeight': (Math.ceil(this.height/10) * 10),
                    'CellSize': this.cellSize,
                    'GridReference': ref
                }

            window.axios.post('https://localhost:44306/api/GridTriangleCalculation', { withCredentials: true }, data)
              .then(({ data }) => {
                this.triangleCoordinates = data;
                this.triangleLoading = false;
              })


          },

            getRef(row, column) {
                row = String.fromCharCode(row + 64);
                return row + column;
            },

            getFirstTriangle(row, column) {
                let point1X = (column - 1) * this.cellSize;
                let point1Y = (row - 1) * this.cellSize;

                let point2X = (column -1) * this.cellSize;
                let point2Y = row * this.cellSize;

                let point3X = column * this.cellSize;
                let point3Y = row * this.cellSize;

                return `${point1X},${point1Y} ${point2X},${point2Y} ${point3X},${point3Y}`
            },

            getSecondTriangle(row, column) {
                let point1X = (column - 1) * this.cellSize;
                let point1Y = (row - 1) * this.cellSize;

                let point2X = column * this.cellSize;
                let point2Y = (row - 1) * this.cellSize;

                let point3X = column * this.cellSize;
                let point3Y = row * this.cellSize;

                return `${point1X},${point1Y} ${point2X},${point2Y} ${point3X},${point3Y}`
            }
        }
    }
</script>

<style>

</style>