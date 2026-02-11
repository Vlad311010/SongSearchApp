using SongSearchApp.Models.Application;
using SongSearchApp.Models.Itunes;

namespace SongSearchApp.Mapping;

public static class ItunesResultMapper
{
    public static SongData MapSong(ItunesResult result)
    {
        return new SongData
        {
            Title = result.TrackName ?? result.CollectionName ?? string.Empty,
            ArtistName = result.ArtistName,
            AlbumName = result.CollectionName,
            CollectionId = result.CollectionId,
            PreviewUrl = result.PreviewUrl,
            ArtworkUrl = result.ArtworkUrl100 ?? result.ArtworkUrl60 ?? result.ArtworkUrl30,
            Genre = result.PrimaryGenreName,
            TrackNumber = result.TrackNumber ?? 0,
            TrackCount = result.TrackCount,
            DurationMs = result.TrackTimeMillis,
            DurationMinutes = result.TrackTimeMillis.HasValue
                ? Math.Round(result.TrackTimeMillis.Value / 60000d, 2)
                : null
        };
    }

    public static ArtistData MapArtist(ItunesResult result)
    {
        return new ArtistData
        {
            Name = result.ArtistName ?? string.Empty,
            ArtistUrl = result.ArtistViewUrl ?? result.ArtistLinkUrl,
            PrimaryGenre = result.PrimaryGenreName,
            Country = result.Country
        };
    }
}
