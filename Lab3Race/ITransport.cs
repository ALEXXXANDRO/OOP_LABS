namespace Lab3Race
{
    public interface ITransport
    {
        double finishTime(double distance);
        int Speed { get; set; }
    }
}