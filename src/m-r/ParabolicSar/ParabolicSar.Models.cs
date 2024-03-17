namespace Skender.Stock.Indicators;

public sealed record class ParabolicSarResult : IReusableResult
{
    public DateTime Timestamp { get; set; }
    public double? Sar { get; set; }
    public bool? IsReversal { get; set; }

    double IReusableResult.Value => Sar.Null2NaN();
}
