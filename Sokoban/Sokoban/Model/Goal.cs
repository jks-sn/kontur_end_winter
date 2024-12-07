//Sokoban/Model/Goal.cs

namespace Sokoban.Model;

public class Goal(int x, int y)
{
    public int X { get; set; } = x;
    public int Y { get; set; } = y;
}