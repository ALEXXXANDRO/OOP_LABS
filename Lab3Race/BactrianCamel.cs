namespace Lab3Race
{
    public class BactrianCamel : LandTransport
    {
        
        public BactrianCamel()
        {
            this.Speed = 10;
            this.TimeToStop = 30;
            this.StopTime = 8;
        }
        
         public override double finishTime(double distance)
         {
             double time =  base.finishTime(distance);
             if ((int) (distance / Speed) / TimeToStop > 1)
             {
                 time -= 3;
             };
            return time;
        }
    }
}