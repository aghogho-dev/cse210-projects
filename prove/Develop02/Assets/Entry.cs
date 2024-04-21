using System;

namespace Develop02.Assets
{
    public class Entry
    {
        public string _date;
        public string _promptText;
        public string _entryText;

        public Entry()
        {
            DateTime currentDate = DateTime.Now;
            _date = currentDate.ToShortDateString();
        }

        public void Display()
        {
            Console.WriteLine($"Date: {_date} - Prompt: {_promptText}\n{_entryText}");
        }

    }
}