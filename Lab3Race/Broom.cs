namespace Lab3Race
{
    public class Broom : AirTransport
    {
        public Broom()
        {
            this.Speed = 10;
            this.DistanceReduseCoeff = 0;
        }
        
        public override double finishTime(double distance)
        {
            this.DistanceReduseCoeff = (int)distance / 1000;
            double time =  base.finishTime(distance);
            return time;
        }
    }
}