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
        public int ProductID;
        public int Price;
        public int Count;

        public ProductInShop(int ID, string name, int price, int count ) : base(name)
        {
            this.Price = price;
            this.Count = count;
            this.ProductID = ID;
        }
    }
}