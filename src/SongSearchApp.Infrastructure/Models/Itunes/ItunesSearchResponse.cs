namespace SongSearchApp.Models.Itunes;

public sealed class ItunesSearchResponse
{
    public int ResultCount { get; init; }

    public IReadOnlyList<ItunesResult> Results { get; set; } = new List<ItunesResult>();
}
