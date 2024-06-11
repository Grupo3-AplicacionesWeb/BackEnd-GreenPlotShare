namespace agro_shop.Shopping.Domain.Model.Aggregate;

public class Product
{
    public long Id { get;}

    public string Name { get; private set; }

    public int Stock { get; private set; }
}