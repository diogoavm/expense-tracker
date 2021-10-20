using ExpenseTracker.Core.Data.Repositories;
using ExpenseTracker.Core.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace ExpenseTracker.Core.Data.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RepositoryContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<RepositoryContext>>()))
            {

                if (context.Expenses.Any())
                {
                    return;   
                }

                context.Expenses.AddRange(
                    new Expense
                    {
                        Category = ExpenseCategory.Transport,
                        Date = "18/10/2021",
                        Id = Guid.NewGuid(),
                        Name = "Metro",
                        Store = "Metro",
                        Value = 4
                    },

                    new Expense
                    {
                        Category = ExpenseCategory.Restaurants,
                        Date = "18/10/2021",
                        Id = Guid.NewGuid(),
                        Name = "Restaurante Italiano",
                        Store = "Mario's Pizzaria",
                        Value = 17
                    },

                    new Expense
                    {
                        Category = ExpenseCategory.Groceries,
                        Date = "18/10/2021",
                        Id = Guid.NewGuid(),
                        Name = "Compras da semana",
                        Store = "Albert Heijn",
                        Value = 4
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
