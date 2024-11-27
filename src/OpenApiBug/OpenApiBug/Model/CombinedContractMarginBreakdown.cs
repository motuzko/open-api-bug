namespace Demo.Models.Models;

public sealed record CombinedContractMarginBreakdown(
    string CombinedContract,
    IEnumerable<ProductDefinitionKey> ProductDefinitionKeys,
    MarginType MarginType,
    CurrencyValuesWithUsd Margin,
    CurrencyValuesWithUsd InitialMargin,
    CurrencyValuesWithUsd MaintenanceMargin,
    CurrencyValuesWithUsd ScanningRisk,
    CurrencyValuesWithUsd InterCommodityCredit,
    CurrencyValuesWithUsd SpreadCharge,
    CurrencyValuesWithUsd NovPremium,
    CurrencyValuesWithUsd NovFuture,
    CurrencyValuesWithUsd NnovPremium,
    CurrencyValuesWithUsd NnovFuture);