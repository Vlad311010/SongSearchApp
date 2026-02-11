using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using SongSearchApp.Mapping;
using SongSearchApp.Models.Application;
using SongSearchApp.Models.Itunes;
using SongSearchApp.Services.Interfaces;

namespace SongSearchApp.Services;

public sealed class SongSearchService : ISongSearchService
{
    private readonly ISongSearchApiClient _apiClient;

    public SongSearchService(ISongSearchApiClient apiClient)
    {
        _apiClient = apiClient;
    }

    public async Task<IReadOnlyList<SongData>> SearchSongsAsync(string term, int limit = 25, int offset = 0, CancellationToken cancellationToken = default)
    {
        var response = await _apiClient.SearchAsync(term, limit, offset, cancellationToken);
        if (response.Results is null || response.Results.Count == 0)
        {
            return Array.Empty<SongData>();
        }

        var results = new List<SongData>(response.Results.Count);
        foreach (var result in response.Results)
        {
            if (string.IsNullOrWhiteSpace(result.TrackName) && string.IsNullOrWhiteSpace(result.CollectionName))
            {
                continue;
            }

            results.Add(ItunesResultMapper.MapSong(result));
        }

        return results;
    }
}
