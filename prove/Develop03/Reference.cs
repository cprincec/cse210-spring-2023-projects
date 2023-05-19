using System;
using System.Collections.Generic;
using System.Globalization;

public class Reference
{
    private string _book;
    private string _chapter;
    private string _verse;
    private string _endVerse;

    public Reference(string book, string chapter, string verse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
    }

    public Reference(string book, string chapter, string verse, string endVerse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
        _endVerse = endVerse;
    }

    public string GetReference()
    {   
        TextInfo ti = CultureInfo.CurrentCulture.TextInfo;
        string book = ti.ToTitleCase(_book);
        if (_endVerse == null)
        {
            return $"{book} {_chapter}:{_verse}:";
        }
        return $"{book} {_chapter}:{_verse}-{_endVerse}:";
    }
}