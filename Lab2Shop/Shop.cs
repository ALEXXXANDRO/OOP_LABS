using System;
using System.Collections.Generic;

namespace Shop
{
    public class Shop
    {
        private static int nextID = 1;
        public int ID;
        public string name;
        Dictionary<string,int>ProductList = new Dictionary<string, int>();

        public Shop (string name)
        {
            this.name = name;
            this.ID = nextID;
            nextID += 1;
        }

        public void AddProducts(string name, int count, int price)
        { 
            ProductInShop productInShop = new ProductInShop(name,price);
            ProductList.Add(productInShop.name, count);
        }
    }
}