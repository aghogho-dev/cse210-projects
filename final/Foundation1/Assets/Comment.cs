using System;

namespace Foundation1.Assets;

class Comment 
{
    private string _name = "";
    private string _text = "";

    public Comment()
    {

    }

    public string GetName()
    {
        return _name;
    }

    public void SetName(string name)
    {
        _name = name;
    }

    public string GetText()
    {
        return _text;
    }

    public void SetText(string text)
    {
        _text = text;
    }


}