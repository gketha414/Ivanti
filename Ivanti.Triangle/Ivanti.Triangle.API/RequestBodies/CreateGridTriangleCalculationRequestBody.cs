using System.ComponentModel.DataAnnotations;

namespace Ivanti.Triangle.API.RequestBodies
{
    public class CreateGridTriangleCalculationRequestBody
    {
        [Required]
        [DataType(DataType.Text)]
        public string GridReference { get; set; }

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
