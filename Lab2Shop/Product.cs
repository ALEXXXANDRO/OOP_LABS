namespace Shop
{
    public class Product
    {
        private static int nextID = 1;
        public int ID;
        public string name;
        
        public Product (string name)
        {
            this.name = name;
            this.ID = nextID;
            nextID += 1;
        }
    }

    public class ProductInShop: Product
    {
        public int price;

        public ProductInShop(string name, int price) : base(name)
        {
            this.price = price;
        }
    }
}