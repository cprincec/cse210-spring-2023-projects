public class PromptGenerator
{
     private List<String> _prompts = new List<string> {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?"
    };

    public string GetRandomPrompt()
    {   
        if (_prompts.Count > 0) {
            Random randomGen = new Random();
            int _randomNum = randomGen.Next(0, _prompts.Count);
            string prompt = _prompts[_randomNum];
            _prompts.RemoveAt(_randomNum);
            return prompt;
        } 
        else {
            return null;
        }        
    }

    public void AddPrompt(string prompt)
    {
        _prompts.Add(prompt);
    }
}