using System;
using System.Collections.Generic;
using System.IO;

class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("The journal is empty.");
            return;
        }

        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string file)
    {
        using (StreamWriter outputFile = new StreamWriter(file))
        {
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine($"{entry._date}~|~{entry._promptText}~|~{entry._entryText}");
            }
        }
        Console.WriteLine($"Journal saved to {file}.");
    }

    public void WeeklyReflection()
    {
        DateTime weekAgo = DateTime.Now.AddDays(-7);
        List<Entry> weekEntries = new List<Entry>();

        foreach (Entry entry in _entries)
        {
            DateTime entryDate;
            if (DateTime.TryParse(entry._date, out entryDate))
            {
                if (entryDate >= weekAgo)
                {
                    weekEntries.Add(entry);
                }
            }
        }

        Console.WriteLine();
        Console.WriteLine("=== Weekly Reflection ===");
        Console.WriteLine($"Entries from {weekAgo.ToShortDateString()} to {DateTime.Now.ToShortDateString()}");
        Console.WriteLine();

        if (weekEntries.Count == 0)
        {
            Console.WriteLine("No entries this week yet.");
        }
        else
        {
            Console.WriteLine($"You wrote {weekEntries.Count} entries this week.");
            Console.WriteLine();
            foreach (Entry entry in weekEntries)
            {
                entry.Display();
            }
        }

        Console.WriteLine();
        Console.WriteLine("How was your week?");
        Console.Write("> ");
        string response = Console.ReadLine();

        Entry weeklyEntry = new Entry();
        weeklyEntry._date = DateTime.Now.ToShortDateString();
        weeklyEntry._promptText = "Weekly Reflection: How was your week?";
        weeklyEntry._entryText = response;

        _entries.Add(weeklyEntry);
        Console.WriteLine("Weekly reflection saved!");
    }

    public void LoadFromFile(string file)
    {
        if (!File.Exists(file))
        {
            Console.WriteLine($"File '{file}' was not found.");
            return;
        }

        _entries.Clear();
        string[] lines = File.ReadAllLines(file);
        foreach (string line in lines)
        {
            string[] parts = line.Split("~|~");
            if (parts.Length == 3)
            {
                Entry entry = new Entry();
                entry._date = parts[0];
                entry._promptText = parts[1];
                entry._entryText = parts[2];
                _entries.Add(entry);
            }
        }
        Console.WriteLine($"Journal loaded from {file}.");
    }
}
