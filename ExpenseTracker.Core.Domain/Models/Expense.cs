using System;

namespace ExpenseTracker.Core.Domain.Models
{
    public class Expense
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }
        public string Date { get; set; }
        public string Store { get; set; }
        public ExpenseCategory Category { get; set; }

    }
    public enum ExpenseCategory
    {
        Groceries,
        Materialistic,
        Restaurants,
        Transport
    }

}
