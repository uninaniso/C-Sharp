using System;

namespace ConsoleApp.Expenses
{
    public static class History
    {
        private static readonly System.Xml.XmlDocument xml = new();
        private static string path = "History Expense.xml";
        public static string Path { get => path; }

        public static void Add(string name, int sum, TypesCategory category, System.DateTime? date = null)
        {
            System.Xml.XmlElement root;

            if (date is null) date = System.DateTime.UtcNow;
            if (System.IO.File.Exists(path))
            {
                xml.Load(path);
                root = xml.DocumentElement;
            }
            else root = xml.CreateElement("History");

            System.Xml.XmlElement New_History = xml.CreateElement($"Expense_{name}");
            System.Xml.XmlElement New_Content = xml.CreateElement("Content");
            System.Xml.XmlElement New_Date = xml.CreateElement("Date");
            New_Content.InnerText = $"sum: {sum} category: {category} date: {date}";
            New_Date.InnerText = date.ToString();

            New_History.AppendChild(New_Content);
            New_History.AppendChild(New_Date);
            root.AppendChild(New_History);
            if (!System.IO.File.Exists(path)) xml.AppendChild(root);
            xml.Save(path);
        }

        public static string[,] Get()
        {
            if (System.IO.File.Exists(path))
            {
                xml.Load(path);
                System.Xml.XmlElement root = xml.DocumentElement;

                string[,] data = new string[root.ChildNodes.Count - 1, 2];

                System.Xml.XmlNode node;
                for (global::System.Int32 i = 0; i < root.ChildNodes.Count - 1; i++)
                {
                    node = root.ChildNodes[i];
                    data[i, 0] = node.SelectSingleNode("Content").InnerText;
                    data[i, 1] = node.SelectSingleNode("Date").InnerText;
                }

                return data;
            }

            return null;
        }

        public static void Edit(string name, string content)
        {
            if (System.IO.File.Exists(path))
            {
                xml.Load(path);
                System.Xml.XmlElement root = xml.DocumentElement;

                foreach (System.Xml.XmlNode node in root.ChildNodes)
                    if (name == node.Name) node.SelectSingleNode("Content").InnerText = content;

                xml.Save(path);
            }
        }

        public static bool ChangePath(string Path)
        {
            if (System.IO.Directory.Exists(Path))
            {
                if (Path[Path.Length - 1] != Convert.ToChar(@"\"))path = Path + "History Expense.xml";
                else path = Path + @"\History Expense.xml";

                return true;
            }

            return false;
        }
    }
}
