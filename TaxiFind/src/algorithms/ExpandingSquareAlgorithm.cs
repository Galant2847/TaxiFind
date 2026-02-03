using TaxiFind.models;

namespace TaxiFind.algorithms;

public class ExpandingSquareAlgorithm
{
    public List<Driver> FindNearestDrivers(Order order, Driver?[,] map, int driversCount)
    {
        var allDrivers = new List<Driver>();
        int rows = map.GetLength(0);
        int columns = map.GetLength(1);

        int radius = 2;
        int maxRadius = Math.Max(rows, columns);

        while (allDrivers.Count < driversCount && radius <= maxRadius)
        {
            allDrivers.Clear();

            int startX = Math.Max(0, order.X - radius);
            int endX = Math.Min(rows - 1, order.X + radius);

            int startY = Math.Max(0, order.Y - radius);
            int endY = Math.Min(columns - 1, order.Y + radius);

            for (int i = startX; i <= endX; i++)
            {
                for (int j = startY; j <= endY; j++)
                {
                    if (map[i, j] != null) allDrivers.Add(map[i, j]!);
                }
            }

            if (allDrivers.Count >= driversCount)
            {
                return allDrivers
                    .OrderBy(d => Math.Abs(d.X - order.X) + Math.Abs(d.Y - order.Y))
                    .Take(driversCount)
                    .ToList();
            }

            radius *= 2;
        }

        return allDrivers;
    }
}