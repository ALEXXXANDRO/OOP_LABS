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
        
        public void AddProduct(Product product, int count, int price)
        {
            if (ProductList.ContainsKey(product.ProductID))
            {
                ProductList[product.ProductID].Count += count;
                ProductList[product.ProductID].Price = price;
            }
            
            else
            {
                ProductInShop productInShop = new ProductInShop(product.name,price, count);
                    ProductList.Add(productInShop.ProductID, productInShop);
            }
        }
        
        public Dictionary<Product, int> WhatCanYouBuy(int countOfMoney)
        {
            Dictionary<Product,int>BuyList= new Dictionary<Product, int>();
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
                BuyList.Add(ProductList[i], countOfProduct);
            }
            return BuyList;
        }
        
        public int CostEstimate(params int[] estimateList)
        {
            int resPrice = 0;
            for (int i = 0; i < estimateList.Length; i +=2 )
            {
                if (!ProductList.ContainsKey(estimateList[i]) || (estimateList[i+1] > ProductList[estimateList[i]].Count))
                {
                    resPrice = Int32.MaxValue;
                }
                else
                {
                    resPrice += ProductList[estimateList[i]].Price * estimateList[i + 1];
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