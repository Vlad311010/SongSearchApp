namespace SongSearchApp.Models.Application;

public sealed class ArtistData
{
    public required string Name { get; init; }
    public string? ArtistUrl { get; init; }
    public string? PrimaryGenre { get; init; }
    public string? Country { get; init; }
}
