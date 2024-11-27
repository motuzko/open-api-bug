namespace Demo.Models.Models;

public sealed record CurrencyValuesWithUsd(IEnumerable<CurrencyValue> CurrencyValues, decimal? UsdEquivalent)
    : CurrencyValuesOnly(
        CurrencyValues)
{
    #region <<< Public methods >>>

    public static CurrencyValuesWithUsd operator +(CurrencyValuesWithUsd inItem1,
        CurrencyValuesWithUsd inItem2)
    {
        return new CurrencyValuesWithUsd(
            inItem1
                .CurrencyValues.Concat(inItem2.CurrencyValues)
                .GroupBy(inValue => inValue.Currency)
                .Select(
                    inValues => new CurrencyValue(
                        inValues.Key,
                        inValues
                            .Where(inValue => inValue.Value != null)
                            .Sum(inValue => inValue.Value)))
                .ToList(),
            inItem1.UsdEquivalent == null && inItem2.UsdEquivalent == null
                ? null
                : inItem1.UsdEquivalent.GetValueOrDefault() + inItem2.UsdEquivalent.GetValueOrDefault());
    }

    public static CurrencyValuesWithUsd operator -(CurrencyValuesWithUsd inItem1,
        CurrencyValuesWithUsd inItem2)
    {
        return inItem1 + -inItem2;
    }

    public static CurrencyValuesWithUsd operator -(CurrencyValuesWithUsd inItem)
    {
        return new CurrencyValuesWithUsd(
            inItem.CurrencyValues.Select(
                inValue => inValue with
                {
                    Value = -inValue.Value
                }),
            -inItem.UsdEquivalent);
    }

    #endregion
}

public record CurrencyValuesOnly(IEnumerable<CurrencyValue> CurrencyValues)
{
    #region <<< Public methods >>>

    public static CurrencyValuesOnly operator +(CurrencyValuesOnly inItem1,
        CurrencyValuesOnly inItem2)
    {
        return new CurrencyValuesOnly(
            inItem1
                .CurrencyValues.Concat(inItem2.CurrencyValues)
                .GroupBy(inValue => inValue.Currency)
                .Select(
                    inValues => new CurrencyValue(
                        inValues.Key,
                        inValues
                            .Where(inValue => inValue.Value != null)
                            .Sum(inValue => inValue.Value)))
                .ToList());
    }

    public static CurrencyValuesOnly operator -(CurrencyValuesOnly inItem1,
        CurrencyValuesOnly inItem2)
    {
        return inItem1 + -inItem2;
    }

    public static CurrencyValuesOnly operator -(CurrencyValuesOnly inItem)
    {
        return new CurrencyValuesOnly(
            inItem.CurrencyValues.Select(
                inValue => inValue with
                {
                    Value = -inValue.Value
                }));
    }

    #endregion
}