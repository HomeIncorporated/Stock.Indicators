namespace Skender.Stock.Indicators;

// ACCUMULATION/DISTRIBUTION LINE (API)

public static partial class Indicator
{
    // SERIES, from TQuote
    /// <include file='./info.xml' path='info/type[@name="standard"]/*' />
    ///
    public static IEnumerable<AdlResult> GetAdl<TQuote>(
        this IEnumerable<TQuote> quotes)
        where TQuote : IQuote => quotes
            .ToQuoteD()
            .CalcAdl();
}
