namespace Lab6Reports.Collections
{
    public class Triad<T, K, M>
    {
        public T First { get; set; }
        public K Second { get; set; }
        
        public M Third { get; set; }

        public Triad(T first, K second, M third)
        {
            First = first;
            Second = second;
            Third = third;
        }
    }
}