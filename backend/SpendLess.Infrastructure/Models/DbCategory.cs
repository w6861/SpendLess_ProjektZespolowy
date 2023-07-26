using System;
using System.ComponentModel.DataAnnotations;

namespace SpendLess.Infrastructure.Models
{
    public class DbCategory
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; }

        public ICollection<DbExpense> Expenses { get; set; }
    }
}

