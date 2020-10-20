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
            MagicShop.AddProducts(1,"apple",12, 10);
            RogueShop.AddProducts(1,"apple",0,0);
            
            Console.WriteLine(Manager.manager.FindCheaperShop(1));
        }
    }
}