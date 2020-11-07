namespace Lab3Race
{
    public class Broom : AirTransport
    {
        public Broom(int speed, int distanceReduseCoeff)
            : base(speed, distanceReduseCoeff)
        {
            
        }

        public Broom()
        {
            this.Speed = 10;
            this.DistanceReduseCoeff = 0;
        }
        
        public double finishTime(double distance)
        {
            DistanceReduseCoeff = (int)distance / 1000;
            double redusedDistance = distance - distance*DistanceReduseCoeff/100;
            double time = redusedDistance/Speed;
            return time;
        }
    }
}