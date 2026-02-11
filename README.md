# SongSearchApp

## Overview
SongSearchApp is a small Razor Pages web app that searches songs and artists using the iTunes Search API. It displays results with artwork, artist name, album name, and preview links, with list/grid views and paging.

## Tech Stack
- .NET 8
- ASP.NET Core Razor Pages
- Bootstrap 5
- iTunes Search API

## Build and Launch
From the repository root:

```bash
# Restore and build
cd src/SongSearchApp.Web
dotnet restore
dotnet build

# Run the web app
cd src/SongSearchApp.Web
dotnet run
```

Then open the app in your browser at the URL shown in the console (typically https://localhost:7xxx or http://localhost:5xxx).

## Project Structure
- src/SongSearchApp.Web: Razor Pages UI
- src/SongSearchApp.Application: application models and services
- src/SongSearchApp.Infrastructure: iTunes API client and models
- docs/: development notes
