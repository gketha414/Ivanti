<template>
    <div>
        <form>
            <div class="form-group">
                <label for="gridHeight">Grid Height:</label>
                <input type="number" class="form-control" id="gridHeight" placeholder="Enter grid height" min="10" max="100" v-model.number="gridHeight">
                <p class="text-muted">Must be between 10 &amp; 100</p>
            </div>
            <div class="form-group">
                <label for="gridWidth">Grid Width:</label>
                <input type="number" class="form-control" id="gridWidth" placeholder="Enter grid width" min="10" max="100" v-model.number="gridWidth">
                <p class="text-muted">Must be between 10 &amp; 100</p>
            </div>
            <div class="form-group">
                <label for="gridWidth">Cell Size:</label>
                <input type="number" class="form-control" id="cellSize" placeholder="Enter cell size" min="10" max="100"  v-model.number="cellSize" @keyup="checkCellSize">
                <p class="text-muted">Must be between 10 &amp; 100</p>
            </div>
        </form>

        <triangular-grid :width="gridWidth" :height="gridHeight" :cellSize="cellSize"></triangular-grid>
    </div>
</template>

<script>
    import TriangularGrid from './TriangularGrid';

    export default {
        data() {
            return {
                gridHeight: 60,
                gridWidth: 60,
                cellSize: 10
            }
        },

        components: {
            'triangular-grid': TriangularGrid
        },

        methods: {
            checkCellSize() {
                if (this.cellSize < 10) {
                    this.cellSize = 10;
                }
            }
        }
    }
</script>

<style>

</style>