namespace Ivanti.Triangle.Domain.Calculators.TriangleCalculators
{
    public interface ITriangleCalculatorFactory
    {
        ITriangleCalculator Make(IGridReference gridReference);
    }
}
