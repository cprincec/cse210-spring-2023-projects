using System;
public class Word
{
    private string _word;
    private bool _isHidden;

    public Word(string word)
    {
        _word = word;
        _isHidden = false;
    }

    public bool IsHidden()
    {
        return _isHidden;
    }

    public void HideWord()
    {
        _isHidden = true;
    }

    public string GetWord()
    {
        return _word;
    }
}
