namespace Lab3Race
{
    public class Centaur : LandTransport
    {
        public Centaur(int speed, int timeToStop, int stopTime)
            : base(speed, timeToStop, stopTime)
        {
            
        }

        public Centaur()
        {
            this.Speed = 15;
            this.TimeToStop = 8;
            this.StopTime = 2;
        }
        
    }
}