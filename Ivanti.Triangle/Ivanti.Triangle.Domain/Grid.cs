namespace Ivanti.Triangle.Domain
{
    public class Grid : IGrid
    {
        public int Height { get; set; }
        public int Width { get; set; }
        public int CellSize { get; set; }

        public Grid(int height, int width, int cellSize)
        {
            this.Height = height;
            this.Width = width;
            this.CellSize = cellSize;
        }

        public virtual int GetRowCount()
        {
            return this.Height / this.CellSize;
        }

        public virtual int GetColumnCount()
        {
            return this.Width / this.CellSize;
        }
    }
}