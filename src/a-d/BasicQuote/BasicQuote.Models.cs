namespace Skender.Stock.Indicators;

public sealed record class BasicResult : IReusableResult
{
    public DateTime TickDate { get; set; }
    public double Value { get; set; }
}