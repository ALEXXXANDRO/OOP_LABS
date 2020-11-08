namespace Lab3Race
{
    public class FastCamel : LandTransport
    {

        public FastCamel()
        {
            this.Speed = 40;
            this.TimeToStop = 10;
            this.StopTime = 8;
        }

        public override double finishTime(double distance)
        {
            double time = base.finishTime(distance);
            
            int countStops = (int)(distance / Speed) / TimeToStop;
            if (countStops > 1)
            {
                time-=4.5;
            }
            else if (countStops == 1)
            {
                time -= 3;
            }
            return time;
        }
    }
}
