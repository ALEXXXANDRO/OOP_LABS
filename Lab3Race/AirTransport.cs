namespace Lab3Race
{
    public class AirTransport : ITransport
    {
        public int Speed { get; set; }
        public int DistanceReduseCoeff;
        
        public virtual double finishTime(double distance)
        {
            double redusedDistance = distance - distance*DistanceReduseCoeff/100;
            double time = redusedDistance/Speed;
            return time;
        }
    }
}