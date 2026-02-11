namespace SongSearchApp.Models.Application;

public sealed class AlbumData
{
    public required string Name { get; init; }
    public required ArtistData Artist { get; init; }
    public required string AlbumUrl { get; init; }
    public string? ArtworkUrl { get; init; }
    public string? Genre { get; init; }
    public int? TrackCount { get; init; }
    public int? DiscCount { get; init; }
    public int? ReleaseYear { get; init; }
}
