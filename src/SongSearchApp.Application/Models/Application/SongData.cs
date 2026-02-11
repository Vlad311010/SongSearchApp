namespace SongSearchApp.Models.Application;

public sealed class SongData
{
    public required string Title { get; init; }
    public string? ArtistName { get; init; }
    public string? AlbumName { get; init; }
    public long? CollectionId { get; init; }
    public string? PreviewUrl { get; init; }
    public string? ArtworkUrl { get; init; }
    public string? Genre { get; init; }
    public int TrackNumber { get; init; }
    public int? TrackCount { get; init; }
    public int? DurationMs { get; init; }
    public double? DurationMinutes { get; init; }
}
