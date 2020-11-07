using System;
using System.Collections.Generic;

namespace Lab3Race
{
    public class Race<T> where T : ITransport

    {
    public string RaceType;
    public int Distance;
    public List<T> RidersList = new List<T>();

    
    
    public Race(int distance, string raceType)
    {
        if (raceType != "Land" && raceType != "Air" && raceType != "Any")
        {
            throw new InvalidRaceType("Тип гонки может быть только Land, Air, Any");
        }

        this.Distance = distance;
        this.RaceType = raceType;
    }
    public void AddRider(T rider)
    {
        
        if (this.RaceType!= rider.GetTransportType() && this.RaceType != "Any")
        {
            throw new InvalidTransportType("Тип гонки не подходит этому персонажу");
        }
        RidersList.Add(rider);
    }

    public T GetWinner()
    {
        if (RidersList.Count == 0) {throw new NoRiders("На гонку не зарегистрировано ни одного участника");}
        T winner = RidersList[0];
        double winnerTime = Double.MaxValue;
        foreach (T rider in RidersList)
        {
            double time = rider.finishTime(this.Distance);
            if (time < winnerTime)
            {
                winnerTime = time;
                winner = rider;
            }
        }
        return winner;
    }

    }
}