namespace LandManagement.Domain.Model.ValueObjects
{
    public record Price(decimal Amount, string Currency)
    {
        public Price() : this(0, string.Empty)
        {
        }

        public Price(decimal amount) : this(amount, string.Empty)
        {
        }

        public Price(string currency) : this(0, currency)
        {
        }

        public string FullPrice() => $"{Amount} {Currency}";
    }
}
