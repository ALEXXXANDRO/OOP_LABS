namespace Lab3Race
{
    public class MagicCarpet : AirTransport
    {
        public MagicCarpet()
        {
            this.Speed = 10;
            this.DistanceReduseCoeff = 0;
        }
        
        public double finishTime(double distance)
        {
            if (distance > 10000) { this.DistanceReduseCoeff += 5; }
            if (distance > 1000 && distance < 5000) { this.DistanceReduseCoeff += 3; }
            if (distance > 5000 && distance < 10000) { this.DistanceReduseCoeff += 10; }
            double time =  base.finishTime(distance);
            return time;
        }
    }
}