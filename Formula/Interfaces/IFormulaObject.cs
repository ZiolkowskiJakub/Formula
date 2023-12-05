namespace Formula
{
    public interface IFormulaObject
    {
        bool TryGetValue(string? propertyName, out object? value);
    }
}
