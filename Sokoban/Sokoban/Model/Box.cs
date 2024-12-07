//Sokoban/Model/Box.cs

namespace Sokoban.Model;

public class Box(int x, int y)
{
    public int X { get; set; } = x;
    public int Y { get; set; } = y;

    public void Move(int dx, int dy)
    {
        X += dx;
        Y += dy;
    }
}