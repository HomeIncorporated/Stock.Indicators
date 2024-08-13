namespace Skender.Stock.Indicators;

// CANDLESTICK MODELS

public record CandleProperties
(
    DateTime Timestamp,
    decimal Open,
    decimal High,
    decimal Low,
    decimal Close,
    decimal Volume
) : Quote(Timestamp, Open, High, Low, Close, Volume)
{
    // raw sizes
    public decimal? Size => High - Low;
    public decimal? Body => Open > Close ? Open - Close : Close - Open;
    public decimal? UpperWick => High - (Open > Close ? Open : Close);
    public decimal? LowerWick => (Open > Close ? Close : Open) - Low;

    // percent sizes
    public double? BodyPct => Size != 0 ? (double?)(Body / Size) : 1;
    public double? UpperWickPct => Size != 0 ? (double?)(UpperWick / Size) : 1;
    public double? LowerWickPct => Size != 0 ? (double?)(LowerWick / Size) : 1;

    // directional info
    public bool IsBullish => Close > Open;
    public bool IsBearish => Close < Open;
}

public record CandleResult : ISeries
{
    public CandleResult(
        DateTime timestamp,
        IQuote quote,
        Match match,
        decimal? price)
    {
        Timestamp = timestamp;
        Price = price;
        Match = match;
        Candle = quote.ToCandle();
    }

    public CandleResult(
        DateTime timestamp,
        CandleProperties candle,
        Match match,
        decimal? price)
    {
        Timestamp = timestamp;
        Price = price;
        Match = match;
        Candle = candle;
    }

    public DateTime Timestamp { get; init; }
    public decimal? Price { get; init; }
    public Match Match { get; init; }
    public CandleProperties Candle { get; init; }
}