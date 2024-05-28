using System;

namespace Paterns;

public sealed partial class TemplateManager
{
#pragma warning disable CS8500
    unsafe public void CreateWord()
    {
        if (!HasWordDocumentFactory) WordDocumentFactory = new WordDocumentFactory();
        Console.Write("Enter name for the File of Word - ");
        Console.ForegroundColor = ConsoleColor.Cyan;
        string name = Console.ReadLine();
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("Enter info for the File of Word - ");
        Console.ForegroundColor = ConsoleColor.Cyan;
        string info = Console.ReadLine();
        Console.ForegroundColor = ConsoleColor.White;
        CreateDocument(&name, &info, WordDocumentFactory);
    }

    unsafe public void EditWord()
    {
        if (!HasWordDocumentFactory) WordDocumentFactory = new WordDocumentFactory();
        Console.Write("Enter name for the File of Word - ");
        Console.ForegroundColor = ConsoleColor.Cyan;
        string name = Console.ReadLine();
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("Enter info for the File of Word - ");
        Console.ForegroundColor = ConsoleColor.Cyan;
        string info = Console.ReadLine();
        Console.ForegroundColor = ConsoleColor.White;
        EditDocument(&name, &info, WordDocumentFactory);
    }

    unsafe public void DeleteWord()
    {
        if (!HasWordDocumentFactory) WordDocumentFactory = new WordDocumentFactory();
        Console.Write("Enter name for the File of Word - ");
        Console.ForegroundColor = ConsoleColor.Cyan;
        string name = Console.ReadLine();
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("Enter info for the File of Word - ");
        DeleteDocument(&name, WordDocumentFactory);
    }
}