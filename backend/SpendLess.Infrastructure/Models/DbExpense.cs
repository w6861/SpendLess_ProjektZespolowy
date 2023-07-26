using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpendLess.Infrastructure.Models
{
    public class DbExpense
    {
        public Guid ExpenseId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Amount { get; set; }
        public DateTimeOffset CreationDate { get; set; }
        public DateTimeOffset ExpenseDate { get; set; }

        public Guid? CategoryId { get; set; }
        public virtual DbCategory? Category { get; set; }
    }
}