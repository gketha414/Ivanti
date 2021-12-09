using System.Collections.Generic;

namespace Ivanti.Triangle.Domain
{
    public class GridShape : IGridShape
    {
        public List<Coordinate> Coordinates = new List<Coordinate>();

        IList<Coordinate> IGridShape.Coordinates { get => Coordinates; }

        public IGridShape AddCoordinate(Coordinate coordinate)
        {
            this.Coordinates.Add(coordinate);

            return this;
        }
    }
}
