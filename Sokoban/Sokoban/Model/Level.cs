//Sokoban/Model/Level.cs

using System.Collections.Generic;

namespace Sokoban.Model;

public class Level(string name, Warehouse warehouse, List<Box> boxes, List<Goal> goals, Player player)
{
    public string Name { get; set; } = name;
    public Warehouse Warehouse { get; set; } = warehouse;
    public List<Box> Boxes { get; set; } = boxes;
    public List<Goal> Goals { get; set; } = goals;
    public Player Player { get; set; } = player;
}