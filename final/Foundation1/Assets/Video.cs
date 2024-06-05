using System;

namespace Foundation1.Assets;

class Video 
{
    private string _author = "";
    private string _title = "";
    private int _length = 0;
    private List<Comment> _comments = new List<Comment>();

    public Video() {

    }

    public string GetAuthor()
    {
        return _author;
    }

    public void SetAuthor(string author)
    {
        _author = author;
    }

    public string GetTitle()
    {
        return _title;
    }

    public void SetTitle(string title)
    {
        _title = title;
    }

    public int GetLength()
    {
        return _length;
    }

    public void SetLength(int length)
    {
        _length = length;
    }

    public void SetComment(Comment comment)
    {
        _comments.Add(comment);
    }

    public Comment GetComment(int index)
    {
        return _comments.ElementAt(index);
    }

    public int GetNumberComment()
    {
        return _comments.Count;
    }

    public void DisplayComments()
    {
        foreach (Comment comment in _comments)
        {
            Console.WriteLine($"{comment.GetName()}: {comment.GetText()}");
        }
    }

    public void DisplayVideoInfo()
    {
        Console.WriteLine($"Title: {_title}");
        Console.WriteLine($"Author: {_author}");
        Console.WriteLine($"Length: {_length}");
        Console.WriteLine($"Number of comments: {GetNumberComment()}");
    }

}