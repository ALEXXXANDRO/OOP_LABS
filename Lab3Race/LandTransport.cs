namespace Lab3Race
{ 
    public class LandTransport : ITransport
    {
        public int Speed { get; set; }
        public int TimeToStop;
        public int StopTime;

        public virtual double finishTime(double distance)
        {
            int countStops = (int)(distance/Speed)/TimeToStop;
            double time = (countStops * StopTime) + distance/Speed;
            return time;
        }
    }
}