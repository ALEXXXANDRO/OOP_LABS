namespace Lab3Race
{
    public class LandTransport : ITransport
    {
        public int Speed;
        public int TimeToStop;
        public int StopTime;
        public string TransportType;

        public LandTransport(int speed, int timeToStop, int stopTime)
        {
            this.Speed = speed;
            this.TimeToStop = timeToStop;
            this.StopTime = stopTime;
            this.TransportType = "Land";
        }

        public LandTransport()
        {
            this.TransportType = "Land";
        }

        public double finishTime(double distance)
        {
            int countStops = (int)(distance/Speed)/TimeToStop;
            double time = (countStops * StopTime) + distance/Speed;
            return time;
        }
        
        public string GetTransportType()
        {
            return this.TransportType;
        }
    }
}