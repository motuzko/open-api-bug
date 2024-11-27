namespace Demo.Models.Models;

public sealed record RiskArraySourceMarginBreakdown(
    RiskArraySource RiskArraySource,
    string Bucket,
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
    CurrencyValuesWithUsd NnovFuture,
    IEnumerable<CombinedContractMarginBreakdown> CombinedContractMarginBreakdowns);