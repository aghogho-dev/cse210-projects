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
            Console.WriteLine($"Saved to {fileName} successfully");
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
            Console.WriteLine($"Loaded from {fileName} successfully");

        }

        public void DeleteFile(string fileName)
        {
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
                Console.WriteLine($"{fileName} deleted successfully");
            }
            else Console.WriteLine($"{fileName} does not exists");
        }

        private string QuoteAndEscape(string field)
        {
            if (field.Contains("\"") || field.Contains(","))
            {
                string escapeField = field.Replace("\"", "\"\"");
                
                return $"\"{escapeField}\"";
            }
            return field;
        }

        public void SaveToCSV(string fileName)
        {
            using (StreamWriter outFile = new StreamWriter(fileName))
            {
                foreach (Entry entry in _entries)
                {
                    string date = QuoteAndEscape(entry._date);
                    string prompt = QuoteAndEscape(entry._promptText);
                    string entry_ = QuoteAndEscape(entry._entryText);

                    string line = $"{date},{prompt},{entry_}";

                    outFile.WriteLine(line);
                }
            }
            Console.WriteLine($"Saved to {fileName} successfully");
        }
    }
}