using System;
using System.IO;

namespace Develop02.Assets
{
    public class Journal
    {
        List<Entry> _entries;

        public Journal()
        {
            _entries = new List<Entry>();
        }

        public void AddEntry(Entry newEntry)
        {
            _entries.Add(newEntry);
        }

        public void DisplayAll()
        {
            foreach (Entry entry in _entries) entry.Display();
        }

        public void SaveToFile(string fileName)
        {
            using (StreamWriter outFile = new StreamWriter(fileName))
            {
                foreach (Entry entry in _entries)
                {
                    outFile.WriteLine($"{entry._date}~|~{entry._promptText}~|~{entry._entryText}");
                }
            }
        }

        public void LoadFromFile(string fileName)
        {
            if (_entries.Count != 0) _entries = new List<Entry>();
            

            string[] lines = File.ReadAllLines(fileName);

            foreach (string line in lines)
            {
                string[] parts = line.Split("~|~");

                string date = parts[0], promptText = parts[1], entryText = parts[2];

                Entry newEntry = new Entry();

                newEntry._date = date;
                newEntry._promptText = promptText;
                newEntry._entryText = entryText;

                AddEntry(newEntry);
            }

        }
    }
}