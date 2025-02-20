/// <summary>
///  Formatta un valore double come valuta.
/// </summary>
/// <param name="price">Il prezzo da formattare.</param>
/// <returns>Una stringa formattata come valuta.</returns
/// 

// Windows:
// public static class PriceFormatter
// {
//     public static string Format (double price)
//     {
//         return price.ToString("C", CultureInfo.CurrentCulture);
//     }
// }

// Mac:
public static class PriceFormatter
{
    public static string Format(double price)
    {
        var euroCulture = new CultureInfo("it-IT");
        string formattedPrice = price.ToString("N2", euroCulture); // Formatta il numero con 2 decimali
        return "€ " + formattedPrice; // Aggiunge il simbolo dell'euro davanti
    }
}

/*

esempio di utilizzo
<td>@PriceFormatter.Format(prodotto.Prezzo)</td>

*/