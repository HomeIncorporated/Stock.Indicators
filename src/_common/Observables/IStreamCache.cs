namespace Skender.Stock.Indicators;

// STREAM CACHE INTERFACES

/// <summary>
/// Stored value cache for streaming hubs
/// </summary>
public interface IStreamCache<out T>
    where T : ISeries
{
    /// <summary>
    /// Read-only list of the stored values cache.
    /// </summary>
    IReadOnlyList<T> Results { get; }

    /// <summary>
    /// The cache and provider failed and is no longer operational.
    /// </summary>
    /// <remarks>
    /// This occurs when there is an overflow condition
    /// from a circular chain or
    /// when there were too many sequential duplicates.
    /// <para>
    /// Use <see cref="IStreamCache{T}.ResetFault()"/>
    /// to remove this flag.
    /// </para>
    /// </remarks>
    bool IsFaulted { get; }

    /// <summary>
    /// Resets the <see cref="IsFaulted"/> flag and
    /// overflow counter.  Use this after recovering
    /// from an error.
    /// </summary>
    /// <remarks>
    /// You may also need to
    /// <see cref="IStreamObserver{T}.Reinitialize()"/>, or
    /// <see cref="IStreamObserver{T}.RebuildCache()"/>.
    /// </remarks>
    void ResetFault();

    /// <summary>
    /// Deletes newer cached records from point in time.
    /// </summary>
    /// <remarks>
    /// For observers, if your intention is to rebuild from a provider,
    /// use alternate <see cref="IStreamObserver{T}.RebuildCache(DateTime)"/>.
    /// </remarks>
    /// <param name="fromTimestamp">
    /// All periods (inclusive) after this DateTime will be removed.
    /// </param>
    void ClearCache(DateTime fromTimestamp);

    /// <summary>
    /// Deletes newer cached records from an index position (inclusive).
    /// </summary>
    /// <remarks>
    /// For observers, if your intention is to rebuild from a provider,
    /// use alternate <see cref="IStreamObserver{T}.RebuildCache(int)"/>.
    /// </remarks>
    /// <param name="fromIndex">From index, inclusive</param>
    void ClearCache(int fromIndex);
}
