using ExpenseTracker.Core.Domain.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseTracker.Core.Data.Models
{
    public class Expense
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
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

    internal static class ExpenseExtensions
    {
        internal static Expense ToPersistenceModel(this Domain.Models.Expense expense)
            => new()
            {
                Category = expense.Category,
                Date = expense.Date,
                Id = expense.Id,
                Name = expense.Name,
                Store = expense.Store,
                Value = expense.Value
            };

        internal static Domain.Models.Expense ToDomainModel(this Expense expense)
            => new()
            {
                Category = expense.Category,
                Date = expense.Date,
                Id = expense.Id,
                Name = expense.Name,
                Store = expense.Store,
                Value = expense.Value
            };
    }
}
