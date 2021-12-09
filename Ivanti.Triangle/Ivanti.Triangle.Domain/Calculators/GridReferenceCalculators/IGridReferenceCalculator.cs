namespace Ivanti.Triangle.Domain.Calculators.GridReferenceCalculators
{
    public interface IGridReferenceCalculator
    {
        IGridShape Calculate(IGrid grid, IGridShape gridShape);
    }
}
