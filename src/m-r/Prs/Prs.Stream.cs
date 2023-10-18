using System.Globalization;

namespace Skender.Stock.Indicators;

// PRICE RELATIVE STRENGTH (STREAMING)

public partial class Prs : ChainProvider
{
    private static readonly CultureInfo EnglishCulture = new("en-US", false);

    // TBD constructor
    public Prs()
    {
        Initialize();
    }

    // TBD PROPERTIES

    // STATIC METHODS

    // parameter validation
    internal static void Validate(
        List<(DateTime, double)> quotesEval,
        List<(DateTime, double)> quotesBase,
        int? lookbackPeriods,
        int? smaPeriods)
    {
        // check parameter arguments
        if (lookbackPeriods is not null and <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(lookbackPeriods), lookbackPeriods,
                "Lookback periods must be greater than 0 for Price Relative Strength.");
        }

        if (smaPeriods is not null and <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(smaPeriods), smaPeriods,
                "SMA periods must be greater than 0 for Price Relative Strength.");
        }

        // check quotes
        int qtyHistoryEval = quotesEval.Count;
        int qtyHistoryBase = quotesBase.Count;

        int? minHistory = lookbackPeriods;
        if (minHistory != null && qtyHistoryEval < minHistory)
        {
            string message = "Insufficient quotes provided for Price Relative Strength.  " +
                string.Format(
                    EnglishCulture,
                    "You provided {0} periods of quotes when at least {1} are required.",
                    qtyHistoryEval, minHistory);

            throw new InvalidQuotesException(nameof(quotesEval), message);
        }

        if (qtyHistoryBase != qtyHistoryEval)
        {
            throw new InvalidQuotesException(
                nameof(quotesBase),
                "Base quotes should have at least as many records as Eval quotes for PRS.");
        }
    }

    // TBD increment calculation
    internal static double Increment() => throw new NotImplementedException();

    // NON-STATIC METHODS

    // handle quote arrival
    public override void OnNext((DateTime Date, double Value) value) => Add(value);

    // TBD add new tuple quote
    internal void Add((DateTime Date, double Value) tp) => throw new NotImplementedException();

    // TBD initialize with existing quote cache
    private void Initialize() => throw new NotImplementedException();
}