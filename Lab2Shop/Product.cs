namespace Shop
{
    public class Product
    {
        private static int nextProductID = 1;
        public string name;
        public int ProductID;
        
        public Product (string name)
        {
            this.name = name;
            this.ProductID = nextProductID;
            nextProductID += 1; 
        }
    }

    public class ProductInShop: Product
    {
        public int Price;
        public int Count;

        public ProductInShop(string name, int price, int count ) 
            : base(name) 
        {
            this.Price = price;
            this.Count = count;
        }
    }
}