using System;
using Microsoft.VisualBasic;

namespace Develop02.Assets
{
    public class PromptGenerator
    {
        List<string> _prompts;
        List<int> _usedPromptIndex;

        public PromptGenerator()
        {
            _usedPromptIndex = new List<int>();

            _prompts.Add("What was the most interesting person I interacted with today?");
            _prompts.Add("What was the best part of my day?");
            _prompts.Add("How did I see the hand of the Lord in my life today?");
            _prompts.Add("What was the strongest emotion I felt today?");
            _prompts.Add("If I had one thing I could do over today, what would it be?");
            _prompts.Add("Where are you in the process of achieving your long-term goal?");
            _prompts.Add("What is the best piece of advice you have received yet?");
            _prompts.Add("What's the best experience you've had with your loved ones today?");
        }

        public string GetRandomPrompt()
        {
            Random random = new Random();
            int index;

            while (true)
            {
                index = random.Next(_prompts.Count);

                if (!_usedPromptIndex.Contains(index)) 
                {
                    _usedPromptIndex.Add(index);
                    break;
                }
            }

            return _prompts[index];
        }

    }
}