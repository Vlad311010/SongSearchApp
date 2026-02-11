using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using SongSearchApp.Models.Application;

namespace SongSearchApp.Services.Interfaces;

public interface IAlbumService
{
    Task<IReadOnlyList<SongData>> GetAlbumTracksAsync(long collectionId, CancellationToken cancellationToken = default);
}
