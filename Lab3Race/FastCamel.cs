namespace Lab3Race
{
    public class FastCamel : LandTransport
    {
        public FastCamel(int speed, int timeToStop, int stopTime)
            : base(speed, timeToStop, stopTime)
        {

        }

        public FastCamel()
        {
            this.Speed = 40;
            this.TimeToStop = 10;
            this.StopTime = 5;
        }

        public double finishTime(int distance)
        {
            int countStops = (distance / Speed) / TimeToStop;
            if (countStops > 2)
            {
                this.StopTime += 3;
                double time = (countStops - 2 * StopTime) + distance / Speed + 5 + 6.5;
                return time;
            }
            else
            {
                this.StopTime += 3;
                double time = (countStops - 1 * StopTime) + distance / Speed + 5;
                return time;
            }
        }
    }
}
