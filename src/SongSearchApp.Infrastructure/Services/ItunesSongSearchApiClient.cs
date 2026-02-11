using Microsoft.AspNetCore.WebUtilities;
using SongSearchApp.Models.Itunes;
using SongSearchApp.Services.Interfaces;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SongSearchApp.Services;

public class ItunesSongSearchApiClient : ISongSearchApiClient
{
    private readonly HttpClient _httpClient;

    public ItunesSongSearchApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<ItunesSearchResponse> SearchAsync(string term, int limit = 25, int offset = 0, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(term))
        {
            return new ItunesSearchResponse
            {
                ResultCount = 0,
                Results = Array.Empty<ItunesResult>()
            };
        }

        var query = new Dictionary<string, string?>
        {
            ["term"] = term,
            ["entity"] = "song",
            ["limit"] = (limit + offset).ToString(CultureInfo.InvariantCulture),
        };

        var requestUri = QueryHelpers.AddQueryString("search", query);
        using var response = await _httpClient.GetAsync(requestUri, cancellationToken);

        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync(cancellationToken);
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            Converters = { new JsonStringEnumConverter(JsonNamingPolicy.CamelCase) }
        };

        var result = JsonSerializer.Deserialize<ItunesSearchResponse>(json, options);
        result ??= new ItunesSearchResponse{ ResultCount = 0, Results = Array.Empty<ItunesResult>() };
        result.Results = result.Results.Skip(Math.Min(offset, result.ResultCount)).ToArray();

        return result;
    }

    public async Task<ItunesSearchResponse> LookupAlbumTracksAsync(long collectionId, CancellationToken cancellationToken = default)
    {
        if (collectionId <= 0)
        {
            return new ItunesSearchResponse
            {
                ResultCount = 0,
                Results = Array.Empty<ItunesResult>()
            };
        }

        var query = new Dictionary<string, string?>
        {
            ["id"] = collectionId.ToString(CultureInfo.InvariantCulture),
            ["entity"] = "song"
        };

        var requestUri = QueryHelpers.AddQueryString("lookup", query);
        using var response = await _httpClient.GetAsync(requestUri, cancellationToken);

        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync(cancellationToken);
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            Converters = { new JsonStringEnumConverter(JsonNamingPolicy.CamelCase) }
        };

        return JsonSerializer.Deserialize<ItunesSearchResponse>(json, options) ?? new ItunesSearchResponse
        {
            ResultCount = 0,
            Results = Array.Empty<ItunesResult>()
        };
    }
}
