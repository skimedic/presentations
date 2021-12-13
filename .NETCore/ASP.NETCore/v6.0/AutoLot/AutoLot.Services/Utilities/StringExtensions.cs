namespace AutoLot.Services.Utilities;

public static class StringExtensions
{
    public static string RemoveControllerSuffix(this string original)
        => original.Replace("Controller", "", StringComparison.OrdinalIgnoreCase);
    public static string RemoveAsyncSuffix(this string original)
        => original.Replace("Async", "", StringComparison.OrdinalIgnoreCase);
    public static string RemoveModelSuffix(this string original)
        => original.Replace("Model", "", StringComparison.OrdinalIgnoreCase);
}
