namespace Lab3Race
{
    public class AirTransport
    {
        public int Speed;
        public int DistanceReduseCoeff;

        public AirTransport(int speed, int distanceReduseCoeff)
        {
            this.Speed = speed;
            this.DistanceReduseCoeff = distanceReduseCoeff;
        }
        
        public double finishTime(int distance)
        {
            double redusedDistance = distance - distance*DistanceReduseCoeff/100;
            double time = redusedDistance/Speed;
            return time;
        } 
    }
}