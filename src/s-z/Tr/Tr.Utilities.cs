namespace Skender.Stock.Indicators;

// TRUE RANGE (UTILITIES)

/// <summary>See the <see href = "https://dotnet.stockindicators.dev/indicators/Tr/">
///  Stock Indicators for .NET online guide</see> for more information.</summary>
public static partial class Tr
{
    // increment calculation
    /// <include file='./info.xml' path='info/type[@name="increment"]/*' />
    ///
    public static double Increment(
        double high,
        double low,
        double prevClose)
    {
        double hmpc = Math.Abs(high - prevClose);
        double lmpc = Math.Abs(low - prevClose);

        return Math.Max(high - low, Math.Max(hmpc, lmpc));
    }
}