using System.Collections.Generic;

namespace Ivanti.Triangle.Domain
{
    public interface IGridShape
    {
        IList<Coordinate> Coordinates { get; }

        IGridShape AddCoordinate(Coordinate coordinate);
    }
}
