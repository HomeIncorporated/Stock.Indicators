namespace Skender.Stock.Indicators;

public static partial class Indicator
{
    // remove recommended periods
    /// <inheritdoc cref="Utility.RemoveWarmupPeriods{T}(IEnumerable{T})"/>
    public static IReadOnlyList<MfiResult> RemoveWarmupPeriods(
        this IEnumerable<MfiResult> results)
    {
        int removePeriods = results
            .ToList()
            .FindIndex(x => x.Mfi != null);

        return results.Remove(removePeriods);
    }
}
