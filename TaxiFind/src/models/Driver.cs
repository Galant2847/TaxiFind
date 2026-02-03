namespace Taxi.models;

public class Driver
{
    public int ID { get; }
    public int X { get; }
    public int Y { get; }

    public Driver(int id, int x, int y)
    {
        ID = id;
        X = x;
        Y = y;
    }
}