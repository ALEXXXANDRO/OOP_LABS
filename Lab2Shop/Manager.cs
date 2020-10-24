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
            if (ShopList.Count == 0) {throw new NoShop("В городе нет ни одного магазина");}
            
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

            if (result == null) {throw new UnknownProduct("Такого товара нет ни в одном магазине");}
            return result.Name;
        }

        /// <summary>
        /// С помощью метода CostEstimate считает сумму товаров для каждого магазина из списка.
        /// </summary>
        public string WhereConsignmentCheaper(params int[] lst)
        {
            if (ShopList.Count == 0) {throw new NoShop("В городе нет ни одного магазина");}
            
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
            if (result == null) {throw new UnknownProduct("Такого товара нет ни в одном магазине");}
            return result.Name;
        }
       
    }
    
    
}