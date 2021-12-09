namespace Ivanti.Triangle.Domain.Calculators.TriangleCalculators
{
    public class TriangleByGridReferenceCalculator
    {
        private readonly ITriangleCalculatorFactory CalculatorFactory;

        public TriangleByGridReferenceCalculator(ITriangleCalculatorFactory calculatorFactory)
        {
            this.CalculatorFactory = calculatorFactory;
        }

        public IGridShape Calculate(IGrid grid, IGridReference gridReference)
        {
            ITriangleCalculator triangleCalculator = this.CalculatorFactory.Make(gridReference);

            return triangleCalculator.Calculate(grid, gridReference);
        }
    }
}
