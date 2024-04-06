namespace ConsoleApp.Expenses
{
    public class Expense
    {
        private int sum;
        private TypesCategory category;
        private System.DateTime date;
        public int Sum { set { sum = value; } get => sum; }
        public TypesCategory Category { set { category = value; } get => category; }
        public System.DateTime Date { set { date = value; } get => date; }

        public Expense(int sum, TypesCategory category, System.DateTime date)
        {
            this.Sum = sum;
            this.Category = category;
            this.Date = date;
        }
    }
}
