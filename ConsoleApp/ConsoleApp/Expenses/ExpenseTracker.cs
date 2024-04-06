using System;
using System.Collections.Generic;

namespace ConsoleApp.Expenses
{
    public class ExpenseTracker
    {
        private (List<Expense>, List<string>) expensesList = (new(), new());
        public (List<Expense>, List<string>) ExpensesList { get => expensesList; }

        public void Add(int sum, TypesCategory category, System.DateTime? date = null, string name = null)
        {
            static string rand()
            {
                Random random = new Random();

                string code = "";

                for (global::System.Int32 i = 0; i < 10; i++)
                    code += random.Next(0, 9).ToString();

                return code;
            }

            if (date is null) date = DateTime.UtcNow;
            ExpensesList.Item1.Add(new Expense(sum, category, (DateTime)date));
            expensesList.Item2.Add(rand());
            History.Add(ExpensesList.Item2[ExpensesList.Item2.Count - 1],sum, category, (DateTime)date);
        }

        public void Edit(int index, int sum, TypesCategory category)
        {
            ExpensesList.Item1[index].Sum = sum;
            ExpensesList.Item1[index].Category = category;
            History.Edit($"Expense_{ExpensesList.Item2[index]}", 
                $"sum: {sum} category: {ExpensesList.Item1[index].Category} date: {ExpensesList.Item1[index].Date}");
        }

        public void Remove(int index)
        {
            ExpensesList.Item1.Remove(ExpensesList.Item1[index]);
            ExpensesList.Item2.Remove(ExpensesList.Item2[index]);
        }
    }
}
