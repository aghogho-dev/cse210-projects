using System;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Develop03.Assets;

class Reference
{
    private string _book;
    private int _chapter;
    private int _verseFrom;
    private int? _verseTo;

    public Reference(string book, int chapter, int verseFrom)
    {
        _book = book;
        _chapter = chapter;
        _verseFrom = verseFrom;
    }

    public Reference(string book, int chapter, int verseFrom, int verseTo)
    {
        _book = book;
        _chapter = chapter;
        _verseFrom = verseFrom;
        _verseTo = verseTo;
    }

    public string GetDisplayText()
    {
        BibleAPI bibleAPI = _verseTo.HasValue ?
            new BibleAPI(_book, _chapter, _verseFrom, _verseTo):
            new BibleAPI(_book, _chapter, _verseFrom);

            try 
            {
                string verses = bibleAPI.FetchVersesAsync().Result;

                JObject json = JObject.Parse(verses);
                string text = (string)json["text"];
                text = text.Replace("\n\n", "").Replace("\n", " ");
                // Console.WriteLine(text);

                return text;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error fetching verses: {e.Message}");

                return string.Empty;
            }
    }
}
