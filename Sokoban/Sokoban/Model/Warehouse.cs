//Sokoban/Model/Warehouse.cs

using Sokoban.Model.GameObjects;

namespace Sokoban.Model;

public class Warehouse
{
    public int Width { get; set; }
    public int Height { get; set; }
    public List<List<GridCell>> Grid { get; set; }

    public Warehouse(int width, int height)
    {
        Width = width;
        Height = height;
        Grid = new List<List<GridCell>>(height);

        for (int i = 0; i < height; i++)
        {
            Grid.Add(new List<GridCell>(width));
            for (int j = 0; j < width; j++)
            {
                Grid[i].Add(GridCell.Empty);
            }
        }
    }
}