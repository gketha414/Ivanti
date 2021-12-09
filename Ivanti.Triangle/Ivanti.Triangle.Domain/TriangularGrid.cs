namespace Ivanti.Triangle.Domain
{
    public class TriangularGrid : Grid
    {
        public TriangularGrid(int height, int width, int cellSize) : base(height, width, cellSize)
        {
        }

        public override int GetColumnCount()
        {
            return (this.Width / this.CellSize) * 2;
        }
    }
}