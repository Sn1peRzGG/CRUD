using Spectre.Console;
using System;
using System.Collections.Generic;

class Program
{
    static List<string> records = new List<string>();

    static void Main()
    {
        bool running = true;
        while (running)
        {
            var choice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .Title("Choose an action:")
                .AddChoices("Create", "Read", "Update", "Delete", "Exit"));

            switch (choice)
            {
                case "Create": Create(); break;
                case "Read": Read(); break;
                case "Update": Update(); break;
                case "Delete": Delete(); break;
                case "Exit": running = false; break;
            }
        }
    }

    static void Create()
    {
        string newRecord = AnsiConsole.Ask<string>("Enter new record:");
        records.Add(newRecord);
        AnsiConsole.MarkupLine("[green]Record added.[/]");
    }

    static void Read()
    {
        int index = AnsiConsole.Ask<int>("Enter index to read:");
        if (IsValidIndex(index)) AnsiConsole.MarkupLine($"[yellow]Record: {records[index]}[/]");
    }

    static void Update()
    {
        int index = AnsiConsole.Ask<int>("Enter index to update:");
        if (IsValidIndex(index))
        {
            string updatedRecord = AnsiConsole.Ask<string>("Enter new value:");
            records[index] = updatedRecord;
            AnsiConsole.MarkupLine("[green]Record updated.[/]");
        }
    }

    static void Delete()
    {
        int index = AnsiConsole.Ask<int>("Enter index to delete:");
        if (IsValidIndex(index))
        {
            records.RemoveAt(index);
            AnsiConsole.MarkupLine("[green]Record deleted.[/]");
        }
    }

    static bool IsValidIndex(int index)
    {
        if (index >= 0 && index < records.Count) return true;
        AnsiConsole.MarkupLine("[red]Invalid index.[/]");
        return false;
    }
}
