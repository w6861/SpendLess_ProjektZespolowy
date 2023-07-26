using SpendLess.Domain.Enums;

namespace SpendLess.Api
{
    public class GetRaport
    {
        public DateTimeOffset? From { get; set; }
        public DateTimeOffset? To { get; set; }
    }
}

