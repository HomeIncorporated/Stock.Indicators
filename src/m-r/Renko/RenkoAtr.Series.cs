namespace Skender.Stock.Indicators;

// RENKO CHART - ATR (SERIES)

public static partial class Indicator
{
    internal static List<RenkoResult> CalcRenkoAtr<TQuote>(
        this List<TQuote> quotesList,
        int atrPeriods,
        EndType endType = EndType.Close)
        where TQuote : IQuote
    {
        // initialize
        List<AtrResult> atrResults = quotesList
            .ToQuoteD()
            .CalcAtr(atrPeriods);

        double? atr = atrResults.LastOrDefault()?.Atr;
        decimal brickSize = (atr == null) ? 0 : (decimal)atr;

        return brickSize is 0 ?
            []
          : quotesList.CalcRenko(brickSize, endType);
    }
}
