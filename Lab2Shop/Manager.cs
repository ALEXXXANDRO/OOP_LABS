using System;
using System.Collections.Generic;

namespace Shop
{
    public class Manager
    {
        public static Manager manager = new Manager();
        public List<Shop> ShopList = new List<Shop>();

        /// <summary>
        /// Такой же метод, что и снизу, только в кол-во товаров передается 1
        /// </summary>
        public string WhereOneProductCheaper(int ID)
        {
            Shop result = null;
            int minPrice = Int32.MaxValue;
            for (int i = 0; i < ShopList.Count; i++)
            {
               if (minPrice > ShopList[i].CostEstimate(ID, 1))
                {
                    minPrice = ShopList[i].CostEstimate(ID,1); 
                    result = ShopList[i];
                }
            }

            if (result == null) {return "OOPS";}
            return result.Name;
        }

        /// <summary>
        /// С помощью метода CostEstimate считает сумму товаров для каждого магазина из списка.
        /// </summary>
        public string WhereConsignmentCheaper(params int[] lst)
        {
            Shop result = null;
            int minPrice = Int32.MaxValue;
            for (int i = 0; i < ShopList.Count; i++)
            {
                if (minPrice > ShopList[i].CostEstimate(lst))
                {
                    minPrice = ShopList[i].CostEstimate(lst); 
                    result = ShopList[i];
                }

            }
            return result.Name;
        }
       
    }
}