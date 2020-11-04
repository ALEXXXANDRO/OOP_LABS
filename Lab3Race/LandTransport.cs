namespace Lab3Race
{
    public class LandTransport
    {
        public int Speed;
        public int TimeToStop;
        public int StopTime;

        public LandTransport(int speed, int timeToStop, int stopTime)
        {
            this.Speed = speed;
            this.TimeToStop = timeToStop;
            this.StopTime = stopTime;
        }

        public double finishTime(int distance)
        {
            int countStops = (distance/Speed)/TimeToStop;
            double time = (countStops * StopTime) + distance/Speed;
            return time;
        } 
    }
}