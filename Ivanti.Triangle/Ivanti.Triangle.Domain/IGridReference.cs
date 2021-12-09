namespace Ivanti.Triangle.Domain
{
    public interface IGridReference
    {
        char Row { get; set; }
        int Column { get; set; }

        int GetNumericRow();
    }
}
