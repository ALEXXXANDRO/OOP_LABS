using System;

namespace Shop
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Product apple = new Product("apple");
            Product megaapple = new Product("megaapple");
            Product sword = new Product("sword");
            Shop WarriorShop = new Shop("WarriorShop", "Orgrimmar");
            Shop MagicShop = new Shop("MagicShop", "Bracada");
            Shop RogueShop = new Shop("RogueShop","Ratway");
            
            
            WarriorShop.AddProduct(apple, 4,15);
            WarriorShop.AddProduct(sword,2,100);
            WarriorShop.AddProduct(megaapple, 4,150);
            RogueShop.AddProduct(apple,12, 10);
            RogueShop.AddProduct(apple,0,0);
            
            Console.WriteLine(Manager.manager.WhereOneProductCheaper(1));
            Console.WriteLine(RogueShop.WhatCanYouBuy(100));
            Console.WriteLine(WarriorShop.ProductList[1].Count);
            Console.WriteLine(WarriorShop.BuyProducts(1, 4, 2, 2, 3, 1));
            Console.WriteLine(WarriorShop.ProductList[1].Count);
            Console.WriteLine(Manager.manager.WhereConsignmentCheaper(12,2));
        }
    }
}