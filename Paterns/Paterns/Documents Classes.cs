using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Paterns;

public class WordDocument : Log, IDisposable, IDocument, IReadDocument
{
    public string name { get; private set; }
    public string info { get; private set; }
    public string path { get; private set; }
    protected static string _TypeFile;
    protected bool _CreateOne;

    public IDocument Create(string name, string info)
    {
        if (_CreateOne) _CreateOne = false;
        else this.Delete();

        try
        {
            this.name = name;
            this.info = info;
            this.path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + @"\" + this.name + _TypeFile;
            System.IO.StreamWriter sw = new System.IO.StreamWriter(path);
            sw.WriteLine(this.info);
            sw.Close();

            Loging("Creating File", $"Created File {this.name}", true);
        }

        catch (Exception ex)
        {
            Loging("Creating File", $"try Creating File {this.name}", false, ex.Message);
        }

        return this;
    }

    public IDocument Delete()
    {
        try
        {
            System.IO.File.Delete(this.path);
            Loging("Deleting File", $"Deleted File {this.name}", true);
        }

        catch (Exception ex)
        {
            Loging("Deleting File", $"try deleting File {this.name}", false, ex.Message);
        }

        return this;
    }

    public IDocument Edit(string name, string info)
    {
        try
        {
            if (!this.name.Equals(name))
            {
                this.Delete();
                this.name = name;
            }

            this.info = info;
            this.path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + @"\" + this.name + _TypeFile;
            System.IO.StreamWriter sw = new System.IO.StreamWriter(path, true);

            sw.WriteLineAsync(info);
            sw.Close();
            Loging("Editing File", $"Edited File {this.name}", true);
        }

        catch (Exception ex)
        {
            Loging("Editing File", $"try Editing File {this.name}", false, ex.Message);
        }

        return this;
    }

    public IDocument Read()
    {
        System.IO.StreamReader sr = new System.IO.StreamReader(this.path);
        Console.WriteLine("-----------------------------------------------------------------");
        sr.ReadLine();
        sr.Close();
        Console.WriteLine("-----------------------------------------------------------------");
        return this;
    }

    public IDocument AboutFile()
    {
        Console.WriteLine("-----------------------------------------------------------------");
        System.IO.FileInfo fileInfo = new System.IO.FileInfo(this.path);
        Console.WriteLine("Full Name File is %s", fileInfo.FullName);
        Console.WriteLine("Name File is %s", fileInfo.Name);
        Console.WriteLine("Full Path Direactory is %s", fileInfo.DirectoryName);
        Console.WriteLine("Created File Time is %s", fileInfo.CreationTimeUtc);
        Console.WriteLine("Last Access Time File is %s", fileInfo.LastAccessTimeUtc);
        Console.WriteLine("Last Write Time File is %s", fileInfo.LastWriteTimeUtc);
        Console.WriteLine("Is Read only File %b", fileInfo.IsReadOnly);
        Console.WriteLine("Size Of Bytes File is %s", fileInfo.Length);
        Console.WriteLine("Extension File is %s", fileInfo.Extension);
        Console.WriteLine("-----------------------------------------------------------------");
        return this;
    }

    public void Dispose()
    {
        this.Delete();
        this.name = null;
        this.info = null;
        this.path = null;
    }

    public WordDocument(string name, string info)
    {
        _CreateOne = true;
        this.Create(name, info);
    }

    ~WordDocument() => this.Dispose();

    static WordDocument() => _TypeFile = ".doc";
}
//тут есть Log!
public class PdfDocument : WordDocument, IDisposable, IDocument, IReadDocument
{
    public PdfDocument(string name, string info) : base(name, info) { }
    ~PdfDocument() => this.Dispose();
    static PdfDocument() => _TypeFile = ".doc";
}