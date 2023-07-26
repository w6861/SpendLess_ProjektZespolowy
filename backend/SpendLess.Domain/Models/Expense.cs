using System;

namespace SpendLess.Domain.Models
{
    public class Expense
    {
        public Guid ExpenseId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Amount { get; set; }
        public DateTimeOffset CreationDate { get; set; }
        public DateTimeOffset ExpenseDate { get; set; }
        public Category? Category { get; set; }
    }
}

