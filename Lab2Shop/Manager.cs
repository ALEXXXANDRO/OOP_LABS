using System;
using System.Collections.Generic;

namespace Shop
{
    public class Manager
    {
        public static Manager manager = new Manager();
        public List<Shop> ShopList = new List<Shop>();

        /// <summary>
        /// Происходит обращение к списку магазинов, в каждом из которых обращаемся к списку товаров в этом магазине
        /// </summary>
        public string FindCheaperShop(int ID)
        {
            Shop result = null;
            int minPrice = Int32.MaxValue;
            for (int i = 0; i < ShopList.Count; i++)
            {
                if (ShopList[i].ProductList.ContainsKey(ID))
                {
                    if (minPrice > ShopList[i].ProductList[ID].price)
                    {
                        minPrice = ShopList[i].ProductList[ID].price;
                        result = ShopList[i];
                    }
                }
            }

            if (result == null) {return "OOPS";}
            return result.name;
        }
    }
}