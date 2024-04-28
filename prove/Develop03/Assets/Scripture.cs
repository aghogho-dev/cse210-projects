using System;

namespace Develop03.Assets;

class Scripture 
{
    private Reference _reference;
    private List<Word> _words = new List<Word>();
    private string[] _splitString;

    public Scripture(Reference reference)
    {
        _reference = reference;
        _splitString = _reference.GetDisplayText().Trim().Split(" ", StringSplitOptions.RemoveEmptyEntries);
        
        foreach (string oneString in _splitString)
        {
            _words.Add(new Word(oneString));
        }
    }

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _splitString = text.Trim().Split(" ", StringSplitOptions.RemoveEmptyEntries);
        
        foreach (string oneString in _splitString)
        {
            _words.Add(new Word(oneString));
        }
    }

    public void HideRandomWords(int numberToHide = 3)
    {
        Random random = new Random();

        int notHidden = 0;

        foreach (Word oneWord in _words)
        {
            if (!oneWord.IsHidden()) notHidden += 1;
        }

        numberToHide = Math.Min(numberToHide, notHidden);

        int i = 0;

        while (i < numberToHide)
        {
            int index = random.Next(0, _words.Count);

            if (!_words[index].IsHidden())
            {
                _words[index].Hide();

                i += 1;
            }
        }
    }

    public string GetDisplayText()
    {
        string display = "";

        foreach (Word word in _words)
        {
            display += $"{word.GetDisplayText()} ";
        }
        return display.Trim();
    }

    public bool IsCompletelyHidden()
    {
        bool isTrue = true;

        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                isTrue = false;
                break;
            }  
        }

        return isTrue;
    }

}