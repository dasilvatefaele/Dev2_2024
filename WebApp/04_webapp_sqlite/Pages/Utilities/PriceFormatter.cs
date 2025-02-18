/// <summary>
///  Formatta un valore double come valuta.
/// </summary>
/// <param name="price">Il prezzo da formattare.</param>
/// <returns>Una stringa formattata come valuta.</returns
public static class PriceFormatter
{
    public static string Format (double price)
    {
        return price.ToString("C", CultureInfo.CurrentCulture);
    }
}

/*

esempio di utilizzo
<td>@PriceFormatter.Format(prodotto.Prezzo)</td>

*/