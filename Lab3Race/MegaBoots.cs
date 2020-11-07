namespace Lab3Race
{
    public class MegaBoots : LandTransport
    {
        public MegaBoots(int speed, int timeToStop, int stopTime)
            : base(speed, timeToStop, stopTime)
        {
            
        }

        public MegaBoots()
        {
            this.Speed = 6;
            this.TimeToStop = 60;
            this.StopTime = 10;
        }
        public double finishTime(int distance)
        {
            int countStops = (distance/Speed)/TimeToStop;

            if (countStops > 1)
            {
                this.StopTime -= 5;
            }
            double time = (countStops-1 * StopTime) + distance/Speed + 10;
            return time;
        }
        
    }
}