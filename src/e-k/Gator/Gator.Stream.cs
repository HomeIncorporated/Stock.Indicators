namespace Skender.Stock.Indicators;

// GATOR OSCILLATOR (STREAMING)

public partial class Gator : ChainProvider
{
    // TBD constructor
    public Gator()
    {
        Initialize();
    }

    // TBD PROPERTIES

    // STATIC METHODS

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