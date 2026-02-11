using SongSearchApp.Services;
using SongSearchApp.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages(options =>
{
    options.Conventions.AddPageRoute("/Index", "search");
    options.Conventions.AddPageRoute("/Album", "album/{collectionId:long}");
});
builder.Services.AddScoped<ISongSearchService, SongSearchService>();
builder.Services.AddScoped<IAlbumService, AlbumService>();
builder.Services.AddHttpClient<ISongSearchApiClient, ItunesSongSearchApiClient>(client =>
{
    client.BaseAddress = new Uri("https://itunes.apple.com/");
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.MapRazorPages();

app.Run();
