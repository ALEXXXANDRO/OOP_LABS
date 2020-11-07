namespace Lab3Race
{
    public class AirTransport : ITransport
    {
        public int Speed;
        public int DistanceReduseCoeff;
        public string TransportType;

        public AirTransport(int speed, int distanceReduseCoeff)
        {
            this.Speed = speed;
            this.DistanceReduseCoeff = distanceReduseCoeff;
            this.TransportType = "Air";
        }

        public AirTransport()
        {
            this.TransportType = "Air";
        }
        
        public double finishTime(double distance)
        {
            double redusedDistance = distance - distance*DistanceReduseCoeff/100;
            double time = redusedDistance/Speed;
            return time;
        }

        public string GetTransportType()
        {
            return this.TransportType;
        }
    }
}