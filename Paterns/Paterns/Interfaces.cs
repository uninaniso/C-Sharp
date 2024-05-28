namespace Paterns;

public interface IDocumentFactory
{
    public IDocumentFactory Create(string name, string info);
    public IDocumentFactory Edit(string name, string info);
    public IDocumentFactory Delete(string name);
}

public interface IDocument
{
    public IDocument Create(string name, string info);
    public IDocument Edit(string name, string info);
    public IDocument Delete();
}

public interface IReadDocument
{
    public IDocument Read();
    public IDocument AboutFile();
}
