using System;
using System.Collections.Generic;

namespace Lab3Race
{
    public class Race<T> where T : ITransport

    {
    public string RaceType;
    public int Distance;
    public List<T> RidersList = new List<T>();



    public Race(int distance)
    {
        this.Distance = distance;
    }

    public void AddRider(T rider)
    {

        RidersList.Add(rider);
    }

    public T GetWinner()
    {
        if (RidersList.Count == 0)
        {
            throw new NoRiders("На гонку не зарегистрировано ни одного участника");
        }

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