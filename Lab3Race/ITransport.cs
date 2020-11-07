namespace Lab3Race
{
    public interface ITransport
    {
        string GetTransportType();
        
        double finishTime(double distance);
    }
}