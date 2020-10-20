using System;
using System.Collections.Generic;

namespace Shop
{
    public class Shop
    {
        public static int nextID = 1;
        public int ID;
        public string name;
        public string address;
        public Dictionary<int,ProductInShop>ProductList = new Dictionary<int, ProductInShop>();

        public Shop (string name, string address)
        {
            this.name = name;
            this.address = address;
            this.ID = nextID;
            nextID += 1; 
            Manager.manager.ShopList.Add(this);
        }
        
        /// <summary>
        /// Если у товара совпало название и ID - происходит завоз товара.
        /// Если одно и то же название, но разный ID - привезли другой сорт товара (ID ДРУГОЙ)
        /// Если один и тот же ID, но разные названия - произошла ошибка (словарь ее обработает)
        /// </summary>
        public void AddProducts(int id, string name, int count, int price)
        {
            if (ProductList.ContainsKey(id) && ProductList[id].name == name)
            {
                ProductList[id].count += count;
                ProductList[id].price = price;
            }
            
            else
            {
                ProductInShop productInShop = new ProductInShop(id, name, price, count);
                ProductList.Add(productInShop.ID, productInShop);
            }
        }
    }
}