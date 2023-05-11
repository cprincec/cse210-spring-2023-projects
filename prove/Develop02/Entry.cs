public class Entry
{
    public string _question;
    public string _answer;
    public string _date;
    public string _time;


    public void SetEntry(string question, string answer, string date = null, string time = null)
    {
        // check if date and time is provided, if so use it
        // if not, use the current date and time
        if (date != null)
        {
            _date = date;
            _time = time;
        }
        else
        {
            SetDateTime();
        }
        // Initialize the question and answer attributes.
        _question = question;
        _answer = answer;
        
    }

    // This function generates the current date and time,
    // parses it and stores the date and time seperately.
    public void SetDateTime()
    {
        DateTime newDate = DateTime.Now;
        _date = newDate.ToString("dddd, dd MMM yyyy");
        _time = newDate.ToString("h:mm:ss tt");
    }
}