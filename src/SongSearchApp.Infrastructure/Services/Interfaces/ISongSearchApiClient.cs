using System.Threading;
using System.Threading.Tasks;
using SongSearchApp.Models.Itunes;

namespace SongSearchApp.Services.Interfaces;

public interface ISongSearchApiClient
{
    Task<ItunesSearchResponse> SearchAsync(string term, int limit = 25, int offset = 0, CancellationToken cancellationToken = default);
    Task<ItunesSearchResponse> LookupAlbumTracksAsync(long collectionId, CancellationToken cancellationToken = default);
}
