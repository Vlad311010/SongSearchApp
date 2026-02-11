using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using SongSearchApp.Models.Application;

namespace SongSearchApp.Services.Interfaces;

public interface ISongSearchService
{
    Task<IReadOnlyList<SongData>> SearchSongsAsync(string term, int limit = 25, int offset = 0, CancellationToken cancellationToken = default);
}
