using System;
using System.Collections.Generic;

namespace Paterns;

public class WordDocumentFactory : Log, IDocumentFactory
{
   private Dictionary<string, WordDocument> _Documents;

    public IDocumentFactory Create(string name, string info)
    {
        try
        {
            _Documents.Add(name, new WordDocument(name, info));
            Loging("Request", $"try to Request to Create a File {name}", true);
        }

        catch(Exception ex)
        {
            Loging("Request", $"try to Request to Create a File {name}", false, ex.Message);
        }

        return this;
    }

    public IDocumentFactory Delete(string name)
    {
        try
        {
            if (_Documents.ContainsKey(name)) _Documents.Remove(name);
            else throw new Exception("No Found File");

            Loging("Request", $"try to Request to Delete a File {name}", true);
        }

        catch(Exception ex)
        {
            Loging("Request", $"try to Request to Delete a File {name}", false, ex.Message);
        }

        return this;
    }

    public IDocumentFactory Edit(string name, string info)
    {
        try
        {
            if (_Documents.ContainsKey(name)) _Documents[name].Edit(name, info);
            else throw new Exception("No Found File");

            Loging("Request", $"try to Request to Edit a File {name}", true);
        }

        catch (Exception ex)
        {
            Loging("Request", $"try to Request to Edit a File {name}", false, ex.Message);
        }

        return this;
    }

    public WordDocumentFactory() => _Documents = new Dictionary<string, WordDocument>();
}

public class PdfDocumentFactory : WordDocumentFactory, IDocumentFactory
{
    private Dictionary<string, PdfDocument> _Documents;

    public PdfDocumentFactory() => _Documents = new Dictionary<string, PdfDocument>();
}
