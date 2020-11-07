namespace Lab3Race
{
    public class Mortar : AirTransport
    {
        public Mortar(int speed, int distanceReduseCoeff)
            : base(speed, distanceReduseCoeff)
        {
            
        }

        public Mortar()
        {
            this.Speed = 10;
            this.DistanceReduseCoeff = 6;
        }
    }
}