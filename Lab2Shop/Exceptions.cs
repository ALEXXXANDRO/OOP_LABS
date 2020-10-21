using System;

namespace Shop
{
    public class NotEnoughProducts : Exception
    {
        public NotEnoughProducts(string message) : base(message)
        {
        }
    }
    public class UnknownProduct : Exception
    {
        public UnknownProduct(string message) : base(message)
        {
        }
    }
    
}