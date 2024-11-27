namespace Demo.Models.Models;

public sealed record CurrencyValue(string Currency, decimal? Value)
{
    #region <<< Public properties >>>

    public static CurrencyValue Empty { get; } = new(
        "USD",
        null);

    #endregion
}