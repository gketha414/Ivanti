using Ivanti.Triangle.API.RequestBodies;
using Ivanti.Triangle.Domain;
using Ivanti.Triangle.Domain.Calculators.GridReferenceCalculators;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Ivanti.Triangle.API.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class GridTriangleReferenceCalculationController : Controller
    {
        private readonly GridReferenceByTriangleCalculator Calculator;

        public GridTriangleReferenceCalculationController(GridReferenceByTriangleCalculator calculator)
        {
            this.Calculator = calculator;
        }

        // POST: api/GridTriangleReferenceCalculation
        [HttpPost]
        public JsonResult Post([FromBody] CreateGridTriangleReferenceCalculationRequestBody request)
        {
            Grid grid = new Grid(request.GridHeight, request.GridWidth, request.CellSize);

            Domain.Triangle triangle = new Domain.Triangle()
                .AddAngleCoordinate(new Coordinate(request.V1X, request.V1Y))
                .AddTopLeftCoordinate(new Coordinate(request.V2X, request.V2Y))
                .AddBottomRightCoordinate(new Coordinate(request.V3X, request.V3Y));

            IGridReference gridReference = this.Calculator.Calculate(grid, triangle);

            return Json(gridReference);
        }
    }
}
