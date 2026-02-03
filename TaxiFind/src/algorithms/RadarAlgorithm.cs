using TaxiFind.models;

namespace TaxiFind.algorithms;

public class RadarAlgorithm
{
    public List<Driver> FindNearestDrivers(Order order, Driver?[,] map, int driversCount)
    {
        int rows = map.GetLength(0);
        int columns = map.GetLength(1);

        var drivers = new List<Driver>();
        
        CheckCell(order.X, order.Y);

        for (int radius = 1; radius <= Math.Max(rows, columns) && drivers.Count < driversCount; radius++)
        {
            for (int dx = -radius; dx <= radius && drivers.Count < driversCount; dx++)
            {
                CheckCell(order.X + dx, order.Y - radius); // верх
                CheckCell(order.X + dx, order.Y + radius); // низ
            }
            
            for (int dy = -radius + 1; dy < radius && drivers.Count < driversCount; dy++)
            {
                CheckCell(order.X - radius, order.Y + dy); // лево
                CheckCell(order.X + radius, order.Y + dy); // право
            }
        }

        return drivers;

        void CheckCell(int x, int y)
        {
            if (x < 0 || x >= rows || y < 0 || y >= columns) return;
            
            var driver = map[x, y];
            if (driver != null && !drivers.Contains(driver))
                drivers.Add(driver);
        }
    }
}