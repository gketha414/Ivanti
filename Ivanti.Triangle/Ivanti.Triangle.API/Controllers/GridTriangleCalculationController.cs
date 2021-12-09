using Ivanti.Triangle.API.RequestBodies;
using Ivanti.Triangle.Domain;
using Ivanti.Triangle.Domain.Calculators.TriangleCalculators;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Ivanti.Triangle.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class GridTriangleCalculationController : Controller
    {
        private readonly TriangleByGridReferenceCalculator Calculator;

        public GridTriangleCalculationController(TriangleByGridReferenceCalculator calculator)
        {
            this.Calculator = calculator;
        }

        // POST: api/GridTriangleCalculation
        [HttpPost]
        public JsonResult Post([FromBody] CreateGridTriangleCalculationRequestBody request)
        {
            Grid grid = new Grid(request.GridHeight, request.GridWidth, request.CellSize);

            GridReference gridReference = new GridReference(request.GridReference);

            return Json(this.Calculator.Calculate(grid, gridReference).Coordinates);
        }
    }
}
