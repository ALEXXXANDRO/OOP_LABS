using System;

namespace Shop
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Shop WarriorShop = new Shop("WarriorShop", "Orgrimmar");
            Shop MagicShop = new Shop("MagicShop", "Bracada");
            Shop RogueShop = new Shop("RogueShop","Ratway");
            WarriorShop.AddProducts(1,"apple", 4,15);
            WarriorShop.AddProducts(2,"sword", 2,100);
            WarriorShop.AddProducts(3,"megaapple", 4,150);
            RogueShop.AddProducts(1,"apple",12, 10);
            RogueShop.AddProducts(1,"apple",0,0);
            
            Console.WriteLine(Manager.manager.WhereOneProductCheaper(1));
            Console.WriteLine(RogueShop.WhatCanYouBuy(100));
            Console.WriteLine(WarriorShop.ProductList[1].Count);
            Console.WriteLine(WarriorShop.BuyProducts(1, 4, 2, 2, 3, 1));
            Console.WriteLine(WarriorShop.ProductList[1].Count);
            Console.WriteLine(Manager.manager.WhereConsignmentCheaper(1,2));
        }
    }
}