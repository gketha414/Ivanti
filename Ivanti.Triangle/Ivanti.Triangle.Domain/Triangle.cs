using System;
using System.Collections.Generic;
using System.Text;

namespace Ivanti.Triangle.Domain
{
    public class Triangle : GridShape
    {
        public Coordinate AngleCoordinate { get; set; }
        public Coordinate TopLeftCoordinate { get; set; }
        public Coordinate BottomRightCoordinate { get; set; }

        public Triangle AddAngleCoordinate(Coordinate angleCoordinate)
        {
            this.AngleCoordinate = angleCoordinate;
            this.Coordinates.Add(angleCoordinate);

            return this;
        }

        public Triangle AddTopLeftCoordinate(Coordinate topLeftCoordinate)
        {
            this.TopLeftCoordinate = topLeftCoordinate;
            this.Coordinates.Add(topLeftCoordinate);

            return this;
        }

        public Triangle AddBottomRightCoordinate(Coordinate bottomRightCoordinate)
        {
            this.BottomRightCoordinate = bottomRightCoordinate;
            this.Coordinates.Add(bottomRightCoordinate);

            return this;
        }
    }
}
