using  System;
using System.Collections.Generic;

namespace Lab3Race
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Race<LandTransport> landRace = new Race<LandTransport>(40);
            Centaur Bob = new Centaur();
            MegaBoots Sam = new MegaBoots();

            landRace.AddRider(Bob);
            landRace.AddRider(Sam);
            Console.WriteLine(landRace.GetWinner().Speed);

            
            Race<AirTransport> airRace = new Race<AirTransport>(9999);
            Mortar Morgana = new Mortar();
            MagicCarpet Bill = new MagicCarpet();
            
            airRace.AddRider(Morgana);
            airRace.AddRider(Bill);
            Console.WriteLine(airRace.GetWinner().Speed);

            Race<ITransport> allRace = new Race<ITransport>(9999);
            allRace.AddRider(Sam);
            allRace.AddRider(Bill);
            
            Console.WriteLine(allRace.GetWinner().Speed);
        }
    }
}