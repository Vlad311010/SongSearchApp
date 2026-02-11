# Copilot instructions for SongSearchApp

## Project intent (PoC)
- Small demo/proof-of-concept web app for searching songs and artists.
- Goal: type a search term → show a list of songs with album art, artist name, and preview link.

## Planned architecture
- Frontend: Razor Pages (.cshtml + C# PageModel).
- Backend: ASP.NET Core Web App (server-side pages + API calls).
- External API: iTunes Search API (optionally more sources later).

## UI expectations
- Use Bootstrap for the layout and styling.
- Provide a few switchable layout variants (e.g., list vs grid) for search results.

## Planning docs
- Development plan and roadmap: [docs/development-plan.md](docs/development-plan.md)

## Pending details to capture once code exists
- Project entry point and directory layout (e.g., Pages/, wwwroot/, Services/).
- How API calls are organized (e.g., HttpClient usage, typed client, or service class).
- Result model mapping from iTunes API responses.
- Any caching, pagination, or rate-limit handling.
- Build/test/debug commands from README or solution settings.

## In case of questions regarding api usage
In case of questions regarding api usage reference the official documentation for the iTunes Search API:  https://performance-partners.apple.com/search-api

