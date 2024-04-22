using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

// Run `dotnet add package Newtonsoft.Json` to use this package

namespace Develop03.Assets;

class BibleAPI
{
    private readonly string _book;
    private readonly int _chapter;
    private readonly int _verseFrom;
    private readonly int? _verseTo;

    public BibleAPI(string book, int chapter, int verseFrom, int? verseTo = null)
    {
        _book = book;
        _chapter = chapter;
        _verseFrom = verseFrom;
        _verseTo = verseTo;
    }

    public async Task<string> FetchVersesAsync()
    {
        string apiUrl = $"https://bible-api.com/{_book}+{_chapter}:{_verseFrom}";

        if (_verseTo.HasValue) apiUrl += $"-{_verseTo}";

        using (var httpClient = new HttpClient())
        {
            try
            {
                await Task.Delay(3000);

                HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

                response.EnsureSuccessStatusCode();

                await Task.Delay(2000);

                return await response.Content.ReadAsStringAsync();
            }
            catch (HttpRequestException e)
            {
                throw new Exception($"Error fetching verses: {e.Message}");
            }
        }
    }
}