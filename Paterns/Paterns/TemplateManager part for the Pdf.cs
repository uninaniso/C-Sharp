using System;

namespace Paterns;

public sealed partial class TemplateManager
{
#pragma warning disable CS8500
    unsafe public void CreatePdf()
    {
        if (!HasPdfDocumentFactory) PdfDocumentFactory = new PdfDocumentFactory();
        Console.Write("Enter name for the File of Pdf - ");
        Console.ForegroundColor = ConsoleColor.Cyan;
        string name = Console.ReadLine();
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("Enter info for the File of Pdf - ");
        Console.ForegroundColor = ConsoleColor.Cyan;
        string info = Console.ReadLine();
        Console.ForegroundColor = ConsoleColor.White;
        CreateDocument(&name, &info, PdfDocumentFactory);
    }



    unsafe public void EditPdf()
    {
        if (!HasWordDocumentFactory) PdfDocumentFactory = new PdfDocumentFactory();
        Console.Write("Enter name for the File of Word - ");
        Console.ForegroundColor = ConsoleColor.Cyan;
        string name = Console.ReadLine();
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("Enter info for the File of Word - ");
        Console.ForegroundColor = ConsoleColor.Cyan;
        string info = Console.ReadLine();
        Console.ForegroundColor = ConsoleColor.White;
        EditDocument(&name, &info, PdfDocumentFactory);
    }


    unsafe public void DeletePdf()
    {
        if (!HasPdfDocumentFactory) PdfDocumentFactory = new PdfDocumentFactory();
        Console.Write("Enter name for the File of Word - ");
        Console.ForegroundColor = ConsoleColor.Cyan;
        string name = Console.ReadLine();
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("Enter info for the File of Word - ");
        DeleteDocument(&name, PdfDocumentFactory);
    }
}