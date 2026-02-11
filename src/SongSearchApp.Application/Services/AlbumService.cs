using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using SongSearchApp.Mapping;
using SongSearchApp.Models.Application;
using SongSearchApp.Models.Itunes;
using SongSearchApp.Services.Interfaces;

namespace SongSearchApp.Services;

public sealed class AlbumService : IAlbumService
{
    private readonly ISongSearchApiClient _apiClient;

    public AlbumService(ISongSearchApiClient apiClient)
    {
        _apiClient = apiClient;
    }

    public async Task<IReadOnlyList<SongData>> GetAlbumTracksAsync(long collectionId, CancellationToken cancellationToken = default)
    {
        var response = await _apiClient.LookupAlbumTracksAsync(collectionId, cancellationToken);
        if (response.Results is null || response.Results.Count == 0)
        {
            return Array.Empty<SongData>();
        }

        var tracks = response.Results
            .Where(result => result.WrapperType == WrapperType.Track)
            .Where(result => !string.IsNullOrWhiteSpace(result.TrackName) || !string.IsNullOrWhiteSpace(result.CollectionName))
            .Select(ItunesResultMapper.MapSong)
            .ToList();

        return tracks;
    }
}
