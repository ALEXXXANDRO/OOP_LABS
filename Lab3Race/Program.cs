using  System;
using System.Collections.Generic;

namespace Lab3Race
{
    public class Program
    {
        public static void Main(string[] args)
        {
            LandTransport myTransport = new LandTransport(4, 10000, 5);
            AirTransport myAirTransport = new AirTransport(5,12);
            
            Race<LandTransport> landRace = new Race<LandTransport>(40, "Land");
            Centaur Bob = new Centaur();
            MegaBoots Sam = new MegaBoots();

            landRace.AddRider(Bob);
            landRace.AddRider(Sam);
            Console.WriteLine(landRace.GetWinner().Speed);

            
            Race<AirTransport> airRace = new Race<AirTransport>(9999,"Air");
            Mortar Morgana = new Mortar();
            MagicCarpet Bill = new MagicCarpet();
            
            airRace.AddRider(Morgana);
            airRace.AddRider(Bill);
            Console.WriteLine(airRace.GetWinner().Speed);

        }
    }
}