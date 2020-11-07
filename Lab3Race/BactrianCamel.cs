namespace Lab3Race
{
    public class BactrianCamel : LandTransport
    {
        public BactrianCamel(int speed, int timeToStop, int stopTime)
            : base(speed, timeToStop, stopTime)
        {
            
        }

        public BactrianCamel()
        {
            this.Speed = 10;
            this.TimeToStop = 30;
            this.StopTime = 5;
        }
        
        public double finishTime(int distance)
        {
            int countStops = (distance/Speed)/TimeToStop;

            if (countStops > 1)
            {
                StopTime += 3;
            }
            double time = (countStops-1 * StopTime) + distance/Speed + 5;
            return time;
        }
    }
}