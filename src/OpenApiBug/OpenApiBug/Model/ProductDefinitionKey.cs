namespace Demo.Models.Models;

public sealed record ProductDefinitionKey(MicExchange Exchange, string ProductCode, string ProductTypeCode)
    : IComparable<ProductDefinitionKey>
{
    #region <<< Public methods >>>

    public int CompareTo(ProductDefinitionKey? inOther)
    {
        if (this == inOther) return 0;

        if (inOther == null) return 1;

        var tmpNum1 = Exchange.CompareTo(inOther.Exchange);
        if (tmpNum1 != 0) return tmpNum1;

        var tmpNum2 = string.Compare(
            ProductCode,
            inOther.ProductCode,
            StringComparison.Ordinal);
        return tmpNum2 != 0
            ? tmpNum2
            : string.Compare(
                ProductTypeCode,
                inOther.ProductTypeCode,
                StringComparison.Ordinal);
    }

    #endregion
}