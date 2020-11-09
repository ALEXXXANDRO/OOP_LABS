namespace Lab3Race
{
    public class MegaBoots : LandTransport
    {
        public MegaBoots()
        {
            this.Speed = 6;
            this.TimeToStop = 60;
            this.StopTime = 5;
        }
        public override double finishTime(double distance)
        {
            double time =  base.finishTime(distance);
            if ((int) (distance / Speed) / TimeToStop > 0)
            {
                time += 5;
            };
            return time;
        }
        
    }
}