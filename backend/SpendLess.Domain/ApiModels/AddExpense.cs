namespace SpendLess.Domain.ApiModels
{
    public class AddExpense
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Amount { get; set; }
        public DateTimeOffset ExpenseDate { get; set; }
        public Guid? CategoryId { get; set; }
    }
}
