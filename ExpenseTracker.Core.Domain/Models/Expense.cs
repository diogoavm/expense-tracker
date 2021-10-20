using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseTracker.Core.Domain.Models
{
    [Table("Expense")]
    public class Expense
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Value is required")]
        public int Value { get; set; }

        [Required(ErrorMessage = "Date is required")]
        public string Date { get; set; }

        public string Store { get; set; }

        [Required(ErrorMessage = "Category is required")]
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
