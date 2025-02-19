///<summary>
/// Restituisce "active" se currentPage è uguale a expectedPage (ignorano il case), altrimenti una stringa vuota.
///</summary>
public static class FrontendUtil
{
    public static string ActiveClass(string currentPage, string expectedPage)
    {
        return currentPage.Equals(expectedPage, StringComparison.OrdinalIgnoreCase) ? "active" : "";
    }
}