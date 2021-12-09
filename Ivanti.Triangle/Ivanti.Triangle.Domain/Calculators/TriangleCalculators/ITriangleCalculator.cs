namespace Ivanti.Triangle.Domain.Calculators.TriangleCalculators
{
    public interface ITriangleCalculator
    {
        IGridShape Calculate(IGrid grid, IGridReference gridReference);
    }
}
