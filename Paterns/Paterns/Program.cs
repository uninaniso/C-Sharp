using System;
using System.Threading;
using System.Threading.Tasks;

namespace Paterns;

public sealed partial class TemplateManager
{
    private static Mutex Mutex = new Mutex(false, null);
    private WordDocumentFactory WordDocumentFactory;
    private PdfDocumentFactory PdfDocumentFactory;
    private bool HasWordDocumentFactory = false;
    private bool HasPdfDocumentFactory = false;
    private static byte? _instance;

    static TemplateManager() =>_instance = 200;

    public TemplateManager()
    {
        if (_instance.HasValue) _instance = null;
        else throw new Exception("SingleTon");
    }

#pragma warning disable CS8500
    unsafe private void CreateDocument(string* name, string* info, IDocumentFactory Factory)
    {
        
        Mutex.WaitOne();
        Task.Run(() => Factory.Create(*name, *info));
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Done!");
        Console.ForegroundColor = ConsoleColor.White;
        Mutex.ReleaseMutex();
    }

    unsafe private void EditDocument(string* name, string* info, IDocumentFactory Factory)
    {
        Mutex.WaitOne();
        Task.Run(() => Factory.Edit(*name, *info));
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Done!");
        Console.ForegroundColor = ConsoleColor.White;
        Mutex.ReleaseMutex();
    }

    unsafe private void DeleteDocument(string* name, IDocumentFactory Factory)
    {
        Mutex.WaitOne();
        Task.Run(() => Factory.Delete(*name));
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Done!");
        Console.ForegroundColor = ConsoleColor.White;
        Mutex.ReleaseMutex();
    }
}

internal class Program
{
    static void Main(string[] args)
    {
        TemplateManager manger = new TemplateManager();
        Console.WriteLine("Program is Started");
        string input = "";

        do
        {
            Console.WriteLine("1.1 - to create word file, 1.2 - to edit word file, 1.3 - to delete word file\n" +
                "2.1 - to create pdf file, 2.2 - to edit pdf file, 2.3 - to delete pdf file\n" +
                "4 - exit");
            Console.Write($"\n$ {Environment.UserName} enter command: ");
            input = Console.ReadLine();

            switch (input)
            {
                case "1.1":
                    manger.CreateWord();
                    break;
                case "1.2":
                    manger.EditWord();
                    break;
                case "1.3":
                    manger.DeleteWord();
                    break;
                case "2.1":
                    manger.CreatePdf();
                    break;
                case "2.2":
                    manger.EditPdf();
                    break;
                case "2.3":
                    manger.DeletePdf();
                    break;
            }
        }

        while (!input.Equals("4"));
    }
}
