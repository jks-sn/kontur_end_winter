//Sokoban/Model/Warehouse.cs

using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Sokoban.Model.GameObjects;

namespace Sokoban.Model;

public class Warehouse(int width, int height)
{
    private GridCell[,] Grid { get; } = new GridCell[height, width];
    public int Width { get; private set; } = width;
    public int Height { get; private set; } = height;
    // private int _totalBoxes; 
    // private int _boxesOnGoal;
    
    public const int CellSize = 32;

    public void SetCell(GridPosition position, GridCell cell)
    {
        if (position.X < 0 || position.Y < 0 || position.X >= Width || position.Y >= Height)
        {
            throw new ArgumentOutOfRangeException("Координаты выходят за пределы склада");
        }
        
        Grid[position.Y, position.X] = cell;
    }
    public GridCell GetCell(GridPosition position)
    {
        if (position.X < 0 || position.Y < 0 || position.X >= Width || position.Y >= Height)
        {
            throw new ArgumentOutOfRangeException("Координаты выходят за пределы склада");
        }

        return Grid[position.Y, position.X];
    }
    
    public bool CanMoveTo(GridPosition position)
    {
        if (position.X < 0 || position.Y < 0 || position.X >= Width || position.Y >= Height)
        {
            return false;
        }

        var cell = Grid[position.Y, position.X];
        return cell is GridCell.Empty or GridCell.Goal;
    }
    
    // public bool CheckVictory()
    // {
    //     return _boxesOnGoal == _totalBoxes;
    // }
    //
    // public Box GetBoxAt(GridPosition position)
    // {
    //     return _boxes.FirstOrDefault(b => b.Position.Equals(position));
    // }
    //
    // public bool HasBoxAt(int x, int y)
    // {
    //     return _grid[x, y] == GridCell.Box || _grid[x, y] == GridCell.BoxOnGoal;
    // }
}