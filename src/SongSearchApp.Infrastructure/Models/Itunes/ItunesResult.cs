using System;

namespace SongSearchApp.Models.Itunes;

public sealed class ItunesResult
{
    public WrapperType WrapperType { get; init; }

    public string? Kind { get; init; }

    public long? ArtistId { get; init; }

    public long? CollectionId { get; init; }

    public long? TrackId { get; init; }

    public string? ArtistName { get; init; }

    public string? CollectionName { get; init; }

    public string? TrackName { get; init; }

    public string? CollectionCensoredName { get; init; }

    public string? TrackCensoredName { get; init; }

    public string? ArtistViewUrl { get; init; }

    public string? CollectionViewUrl { get; init; }

    public string? TrackViewUrl { get; init; }

    public string? PreviewUrl { get; init; }

    public string? ArtworkUrl30 { get; init; }

    public string? ArtworkUrl60 { get; init; }

    public string? ArtworkUrl100 { get; init; }

    public decimal? CollectionPrice { get; init; }

    public decimal? TrackPrice { get; init; }

    public decimal? TrackRentalPrice { get; init; }

    public decimal? CollectionHdPrice { get; init; }

    public decimal? TrackHdPrice { get; init; }

    public decimal? TrackHdRentalPrice { get; init; }

    public DateTimeOffset? ReleaseDate { get; init; }

    public string? CollectionExplicitness { get; init; }

    public string? TrackExplicitness { get; init; }

    public int? DiscCount { get; init; }

    public int? DiscNumber { get; init; }

    public int? TrackCount { get; init; }

    public int? TrackNumber { get; init; }

    public int? TrackTimeMillis { get; init; }

    public string? Country { get; init; }

    public string? Currency { get; init; }

    public string? PrimaryGenreName { get; init; }

    public bool? IsStreamable { get; init; }

    public string? ContentAdvisoryRating { get; init; }

    public bool? HasITunesExtras { get; init; }

    public string? ArtistType { get; init; }

    public string? ArtistLinkUrl { get; init; }

    public long? AmgArtistId { get; init; }

    public int? PrimaryGenreId { get; init; }
}
