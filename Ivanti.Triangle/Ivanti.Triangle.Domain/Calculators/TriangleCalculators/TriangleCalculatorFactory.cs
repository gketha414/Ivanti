namespace Ivanti.Triangle.Domain.Calculators.TriangleCalculators
{
    public class TriangleCalculatorFactory : ITriangleCalculatorFactory
    {
        public ITriangleCalculator Make(IGridReference gridReference)
        {
            if(gridReference.Column % 2 == 0)
            {
                return new RightTriangleCalculator();
            }
            else
            {
                return new LeftTriangleCalculator();
            }
        }
    }
}
