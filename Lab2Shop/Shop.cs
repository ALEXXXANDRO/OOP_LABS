using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;

namespace Shop
{
    public class Shop
    {
        private static int nextShopID = 1;
        public int ShopID;
        public string Name;
        public string Address;
        public Dictionary<int,ProductInShop>ProductList = new Dictionary<int, ProductInShop>();

        public Shop (string name, string address)
        {
            this.Name = name;
            this.Address = address;
            this.ShopID = nextShopID;
            nextShopID += 1; 
            Manager.manager.ShopList.Add(this);
        }
        
        /// <summary>
        /// Если у товара совпало название и ID - происходит завоз товара.
        /// Если одно и то же название, но разный ID - привезли другой сорт товара (ID ДРУГОЙ)
        /// Если один и тот же ID, но разные названия - произошла ошибка 
        /// </summary>
        public void AddProducts(int productID, string name, int count, int price)
        {
            if (ProductList.ContainsKey(productID) && ProductList[productID].name == name)
            {
                ProductList[productID].Count += count;
                ProductList[productID].Price = price;
            }
            
            else
            {
                try
                {
                    ProductInShop productInShop = new ProductInShop(productID, name, price, count);
                    ProductList.Add(productInShop.ProductID, productInShop);
                }
                catch
                {
                    throw new UnknownProduct("Такого товара в магазине нет");
                }
            }
        }
        
        public string WhatCanYouBuy(int countOfMoney)
        {
            string buyList = $"В магазине {this.Name} \n";
            for(int i = 1; i < ProductList.Count +1; i++)
            {
                int countOfProduct = countOfMoney;
                if (ProductList[i].Price == 0)
                {
                    countOfProduct = ProductList[i].Count;
                }
                else
                {
                    countOfProduct /= ProductList[i].Price;
                }

                if (countOfProduct > ProductList[i].Count)
                {
                    countOfProduct = ProductList[i].Count;
                }
                buyList += $"Вы можете купить {countOfProduct} {ProductList[i].name} \n";
            }
            if (buyList == $"В магазине {this.Name} \n")
            {
                buyList = "Mагазин пуст";
            }
            return buyList;
        }
        
        public int CostEstimate(params int[] lst)
        {
            int resPrice = 0;
            for (int i = 0; i < lst.Length; i +=2 )
            {
                if (!ProductList.ContainsKey(lst[i]) || (lst[i+1] > ProductList[lst[i]].Count))
                {
                    resPrice = Int32.MaxValue;
                }
                else
                {
                    resPrice += ProductList[lst[i]].Price * lst[i + 1];
                }
            }
            return resPrice;
        }
        
        /// <summary>
        /// Использует метод CostEstimate. В случае удачного завершения, удаляет товары из магазина
        /// </summary>
        public int BuyProducts(params int[] lst)
        {
            int resPrice = CostEstimate(lst);
            if (resPrice == Int32.MaxValue) {throw new NotEnoughProducts("В магазине недостаточно продуктов");}
            for (int i = 0; i < lst.Length; i += 2)
            {
                ProductList[lst[i]].Count -= lst[i+1];
            }
            return resPrice;
        }
      
    }
}