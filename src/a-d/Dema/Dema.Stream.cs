namespace Skender.Stock.Indicators;

// DOUBLE EXPONENTIAL MOVING AVERAGE (STREAMING)

public partial class Dema : ChainProvider
{
    // TBD constructor
    public Dema()
    {
        Initialize();
    }

    // TBD PROPERTIES

    // STATIC METHODS

    // parameter validation
    internal static void Validate(
        int lookbackPeriods)
    {
        // check parameter arguments
        if (lookbackPeriods <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(lookbackPeriods), lookbackPeriods,
                "Lookback periods must be greater than 0 for DEMA.");
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