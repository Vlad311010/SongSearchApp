## Notes & Instructions Log

Model: GPT-5.2-Codex
IDE: VS Code

(1)  

generated following instruction file using ChatGpt (providing it a small project description).  
Lately manually added api documentation link.  

# Copilot instructions for SongSearchApp
## Project intent (PoC)
- Small demo/proof-of-concept web app for searching songs and artists.
- Goal: type a search term -> show a list of songs with album art, artist name, and preview link.
## Planned architecture
- Frontend: Razor Pages (.cshtml + C# PageModel).
- Backend: ASP.NET Core Web App (server-side pages + API calls).
- External API: iTunes Search API (optionally more sources later).
## UI expectations
- Use Bootstrap for the layout and styling.
- Provide a few switchable layout variants (e.g., list vs grid) for search results.
## Pending details to capture once code exists
- Project entry point and directory layout (e.g., Pages/, wwwroot/, Services/).
- How API calls are organized (e.g., HttpClient usage, typed client, or service class).
- Result model mapping from iTunes API responses.
- Any caching, pagination, or rate-limit handling.
- Build/test/debug commands from README or solution settings.


(2)  
Road map and main features file was generated. minor manual adjustments (to make objectives clearer)

Result: development-plan.md generated

(3)  
Create project structure (include basic .gitignore file). Use common asp.net projects patterns

Result: Initial folders structures was generated. Required few attempts and some manual adjustments as prompt was rather vague

(4)  
install lastest bootstrap version.

(5)  
Lets start work from backend part.  
Create class that will handle api calls. It should be flexible so start with implementing abstract class or interface

Result: no issue with this step 

(6)  
Define neccessary models that will be used to map json response. Define 'wrapperType' as enum  
Remember to follow response descriptions provided in official api documentation

Result: Some guidens were required. Also had to remind that models should reflect expected api response described in provided link to documentation. 

(7)  
Remove 'JsonPropertyName' attributes. (unnecessary duplication as property names should copy expected json properties).  
Move #file:WrapperType.cs to Enums folder.

(8)  
suggest how should i split solution into smaller .net projects -> updated structure.

Result: required some guidden to move existing files into proper projects. 

(10)  
updated to map to Itunes responce models
context: ItunesSongSerachApiClient

Result: no issues

(11)  
create application models.
Models: song data, artist data

context: Models\Itunes

(12)  
Create application service that fetches song data via infrastructure layer and returns application layer models.  
Context: ISongSearchApiClient.cs

Result: services was created in wrong infrastructure layer, all required models(that were defined in application layer) were moved here as well.  

(13)  
Project structure fixes

(14)  
Web project. Create main page controller.  
should be responsible for searhing songs and diplaying search result

context: SongSearchApp.Web/Pages

(15)  
Update the Razor page markup to render the search box + results list?

context: Index.cshtml

(16)  
Add grid view toggle.  
Move diplaying logic into separate component (two component: list view and grid view)

context: Index.cshtml

Result: required frontend was implemented after multiple itterations 

(17)  
refactor song details display as separate component
context: Index.cshtml

Result:
(18)  
update songResultCard to link to artist details page

context: _SongCard.cshtml

Result:
(19)  
Work on album page. list all songs that belong to album.  
Extend #file:ItunesSongSearchApiClient.cs if needed

context: ItunesSongSearchApiClient.cshtml, SongSearchApp.Web/Pages

Result: ItunesSongSearchApiClient logic and related interface were updated

(20)  
add load more result logic.  
Unlike most modern APIs (like Spotify or YouTube), the iTunes Search API does not provide a true total count of all matching results.  
"resultCount" here means the number of items returned in this page, not the total number of matches.  
So you can't calculate total pages directly (because iTunes doesn't expose it).  
modify request (using offset + limit)  
Stop when the API returns fewer than limit results.

Result: multiple fixes and logic adjustments. Minor manual tweaks.  
Many attempts to explain that iTunes api doesn't have 'offset' query parameter.

(21)  
[Got a suggestion to implement routing]  
Yes, implement rounting as suggested

Result:
(22)  
Asked for sample design improvments for privacy page and to apply suggestions.  

Result: as side effect topbar also was changed.

## Insights

* Prompts that worked well
- Clear scope with file/context pointers (e.g., "Context: Index.cshtml", "Use #file:ISongSearchApiClient.cs").
- Explicit success criteria (e.g., "list all songs that belong to album", "render search box + results list").


* Prompts that did not work well 
- Deviation from standard patters. It took some efforts to explain that iTunes has no real offset. Had to implement 'load more' feature using small step by step prompts.
- Vague prompts. In such cases rather should have asked for initial suggestion and then create more defined prompt (or to apply latest suggestion) 

* Best prompting patterns
- Include target file(s), desired outputs, and what to avoid.
- Include explicit success criteria


## Note
I didn’t define strict project requirements and only had a general idea. As a result, feature prompts were vague, and I accepted most of the suggested solutions. In my experience, achieving a satisfactory implementation with stricter acceptance criteria takes more effort, iteration, and more detailed prompts.