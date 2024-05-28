using System;

namespace Paterns;

public abstract class Log
{
    public virtual string Log_Last_Name_Operation { get; private set; }
    public virtual string Log_Last_Info { get; private set; }
    public virtual bool Log_Last_Operation_True_Or_False { get; private set; }
    public virtual string Log_Full_Last_Info { get; private set; }
    public virtual string Log_Last_Cause { get; private set; }

    protected void SaveToFile()
    {
        string name = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + @"\Loging.log";
        Console.WriteLine(this.Log_Full_Last_Info);
        System.IO.StreamWriter sw = new System.IO.StreamWriter(name, true);
        sw.WriteLine(this.Log_Full_Last_Info);
        sw.Close();
    }

    protected virtual void Loging(string name, string info, bool Operation_True_Or_False, string cause = "NOTHING")
    {
        this.Log_Last_Name_Operation = name;
        this.Log_Last_Info = info;
        this.Log_Last_Operation_True_Or_False = Operation_True_Or_False;
        this.Log_Last_Cause = cause;
        this.Log_Full_Last_Info = $"[{this.Log_Last_Name_Operation}]::[{this.Log_Last_Info = info}][{this.Log_Last_Cause}][{this.Log_Last_Operation_True_Or_False}]//[{DateTime.UtcNow}]";
        System.Threading.Tasks.Task.Run(() => SaveToFile());
    }
}
