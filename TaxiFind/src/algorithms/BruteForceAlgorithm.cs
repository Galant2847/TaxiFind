using TaxiFind.models;

namespace TaxiFind.algorithms;

public class BruteForceAlgorithm
{
    public List<Driver> FindNearestDrivers(Order order, Driver?[,] map, int driversCount)
    {
        var allDrivers = new List<Driver>();
        int rows = map.GetLength(0);
        int columns = map.GetLength(1);

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                if (map[i, j] != null) allDrivers.Add(map[i, j]!);
            }
        }

        allDrivers.Sort((d1, d2) =>
        {
            int distance1 = Math.Abs(d1.X - order.X) + Math.Abs(d1.Y - order.Y);
            int distance2 = Math.Abs(d2.X - order.X) + Math.Abs(d2.Y - order.Y);
            return distance1.CompareTo(distance2);
        });

        return allDrivers.GetRange(0, Math.Min(allDrivers.Count, driversCount));
    }
}