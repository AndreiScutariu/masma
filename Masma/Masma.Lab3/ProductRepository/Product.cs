namespace Masma.Lab3.ProductRepository
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Price { get; set; }

        public override string ToString() => $"Id: {Id}, Name: {Name}, Price: {Price}";
    }
}