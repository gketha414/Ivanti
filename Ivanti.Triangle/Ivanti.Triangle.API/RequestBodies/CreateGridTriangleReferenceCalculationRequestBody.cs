using System.ComponentModel.DataAnnotations;

namespace Ivanti.Triangle.API.RequestBodies
{
    public class CreateGridTriangleReferenceCalculationRequestBody
    {
        [Required]
        [Range(0, 100)]
        public int V1X { get; set; }

        [Required]
        [Range(0, 100)]
        public int V1Y { get; set; }

        [Required]
        [Range(0, 100)]
        public int V2X { get; set; }

        [Required]
        [Range(0, 100)]
        public int V2Y { get; set; }

        [Required]
        [Range(0, 100)]
        public int V3X { get; set; }

        [Required]
        [Range(0, 100)]
        public int V3Y { get; set; }

        [Required]
        [Range(1, 100)]
        public int GridHeight { get; set; }

        [Required]
        [Range(1, 100)]
        public int GridWidth { get; set; }

        [Required]
        [Range(1, 100)]
        public int CellSize { get; set; }
    }
}
