using System;

namespace Shop
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Shop firstShop = new Shop("firstShop");
            firstShop.AddProducts("apple",800,42);
            firstShop.AddProducts("apple",800,42);
        }
    }
}