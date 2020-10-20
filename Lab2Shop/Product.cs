namespace Shop
{
    public class Product
    {
        public string name;
        
        public Product (string name)
        {
            this.name = name;
        }
    }

    public class ProductInShop: Product
    {
        public int ID;
        public int price;
        public int count;

        public ProductInShop(int ID, string name, int price, int count ) : base(name)
        {
            this.price = price;
            this.count = count;
            this.ID = ID;
        }
    }
}