using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using SongSearchApp.Models.Application;
using SongSearchApp.Services.Interfaces;

namespace SongSearchApp.Web.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly ISongSearchService _songSearchService;

    public IndexModel(ILogger<IndexModel> logger, ISongSearchService songSearchService)
    {
        _logger = logger;
        _songSearchService = songSearchService;
    }

    [BindProperty(SupportsGet = true)]
    public string? Query { get; set; }

    [BindProperty(SupportsGet = true)]
    public string ViewMode { get; set; } = "list";

    [BindProperty(SupportsGet = true)]
    public int Limit { get; set; } = 25;

    [BindProperty(SupportsGet = true)]
    public int Offset { get; set; }

    public bool HasMore { get; private set; }

    public IReadOnlyList<SongData> Results { get; private set; } = Array.Empty<SongData>();

    public async Task OnGetAsync(CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(Query))
        {
            Results = Array.Empty<SongData>();
            return;
        }

        if (string.IsNullOrWhiteSpace(ViewMode))
        {
            ViewMode = "list";
        }

        if (Limit <= 0)
        {
            Limit = 25;
        }
 

        if (Offset < 0)
        {
            Offset = 0;
        }

        Results = await _songSearchService.SearchSongsAsync(Query, Limit, Offset, cancellationToken);
        HasMore = Results.Count >= Limit;
    }

    public async Task<PartialViewResult> OnGetMoreAsync(CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(Query))
        {
            Response.Headers["X-Has-More"] = "false";
            return BuildPartial("_SongResultListItems", Array.Empty<SongData>());
        }

        if (string.IsNullOrWhiteSpace(ViewMode) || (ViewMode != "grid" && ViewMode != "list"))
        {
            ViewMode = "list";
        }

        if (Limit <= 0)
        {
            Limit = 25;
        }

        if (Offset < 0)
        {
            Offset = 0;
        }

        var results = await _songSearchService.SearchSongsAsync(Query, Limit, Offset, cancellationToken);
        var hasMore = results.Count >= Limit;

        Response.Headers["X-Has-More"] = hasMore ? "true" : "false";
        Response.Headers["X-Next-Offset"] = (Offset + Limit).ToString();

        return BuildPartial(ViewMode == "grid" ? "_SongResultGridItems" : "_SongResultListItems", results);
    }

    private PartialViewResult BuildPartial(string viewName, IReadOnlyList<SongData> model)
    {
        return new PartialViewResult
        {
            ViewName = viewName,
            ViewData = new ViewDataDictionary<IReadOnlyList<SongData>>(ViewData, model)
        };
    }
}
