using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SongSearchApp.Models.Application;
using SongSearchApp.Services.Interfaces;

namespace SongSearchApp.Web.Pages;

public class AlbumModel : PageModel
{
    private readonly IAlbumService _albumService;

    public AlbumModel(IAlbumService albumService)
    {
        _albumService = albumService;
    }

    [BindProperty(SupportsGet = true)]
    public long? CollectionId { get; set; }

    public IReadOnlyList<SongData> Tracks { get; private set; } = Array.Empty<SongData>();

    public string? AlbumName { get; private set; }

    public async Task OnGetAsync(CancellationToken cancellationToken)
    {
        if (CollectionId is null)
        {
            Tracks = Array.Empty<SongData>();
            return;
        }

        Tracks = await _albumService.GetAlbumTracksAsync(CollectionId.Value, cancellationToken);
        AlbumName = Tracks.FirstOrDefault()?.AlbumName;
    }
}
