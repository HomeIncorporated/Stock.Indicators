namespace Utilities;
/**
<summary>
Geometric Brownian Motion (GMB) is a random simulator of market movement.
GBM can be used for testing indicators, validation and Monte Carlo simulations of strategies.

Sample usage:
RandomGbm data = new(); // generates 1 year (252) list of bars
RandomGbm data = new(Bars: 1000); // generates 1,000 bars
RandomGbm data = new(Bars: 252, Volatility: 0.05, Drift: 0.0005, Seed: 100.0)

Parameters
Bars:       number of bars (quotes) requested
Volatility: how dymamic/volatile the series should be; default is 1
Drift:      incremental drift due to annual interest rate; default is 5%
Seed:       starting value of the random series; should not be 0.
</summary>
**/
internal class RandomGbm : List<Quote>
{
    private readonly double _volatility;
    private readonly double _drift;
    private double _seed;

    public RandomGbm(
        int bars = 250,
        double volatility = 1.0,
        double drift = 0.01,
        double seed = 1000.0)
    {
        _seed = seed;
        _volatility = volatility * 0.01;
        _drift = drift * 0.001;
        for (int i = 0; i < bars; i++)
        {
            DateTime date = DateTime.Today.AddMinutes(i - bars);
            Add(date);
        }
    }

    public void Add(DateTime timestamp)
    {
        double open = Price(_seed, _volatility * _volatility, _drift);
        double close = Price(open, _volatility, _drift);

        double ocMax = Math.Max(open, close);
        double high = Price(_seed, _volatility * 0.5, 0);
        high = high < ocMax ? (2 * ocMax) - high : high;

        double ocMin = Math.Min(open, close);
        double low = Price(_seed, _volatility * 0.5, 0);
        low = low > ocMin ? (2 * ocMin) - low : low;

        double volume = Price(_seed * 10, _volatility * 2, drift: 0);

        Quote quote = new(
            Timestamp: timestamp,
            Open: (decimal)open,
            High: (decimal)high,
            Low: (decimal)low,
            Close: (decimal)close,
            Volume: (decimal)volume);

        Add(quote);
        _seed = close;
    }

    private static double Price(double seed, double volatility, double drift)
    {
        Random rnd = new((int)DateTime.UtcNow.Ticks);
        double u1 = 1.0 - rnd.NextDouble();
        double u2 = 1.0 - rnd.NextDouble();
        double z = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Sin(2.0 * Math.PI * u2);
        return seed * Math.Exp(drift - (volatility * volatility * 0.5) + (volatility * z));
    }
}
