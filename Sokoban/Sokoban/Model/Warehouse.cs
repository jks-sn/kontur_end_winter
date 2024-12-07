//Sokoban/Model/_Warehouse.cs

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
    private int _totalBoxes; 
    private int _boxesOnGoal;
    
    public const int CellSize = 32;

    public void SetCell(int x, int y, GridCell cell)
    {
        if (x < 0 || y < 0 || x >= Grid.GetLength(0) || y >= Grid.GetLength(1))
        {
            return;
        }

        var currentCell = Grid[x, y];
        if (currentCell == GridCell.BoxOnGoal)
        {
            _boxesOnGoal--;
        }
        
        Grid[x, y] = cell;
        
        if (cell == GridCell.BoxOnGoal)
        {
            _boxesOnGoal++;
        }
        else if (cell == GridCell.Box)
        {
            _totalBoxes++;
        }
    }
    public GridCell GetCell(int x, int y)
    {
        if (x < 0 || y < 0 || x >= Width || y >= Height)
            throw new ArgumentOutOfRangeException("Координаты выходят за пределы склада");

        return Grid[y, x];
    }
    
    public bool CanMoveTo(int x, int y)
    {
        if (x < 0 || y < 0 || x >= Width || y >= Height)
        {
            return false;
        }

        var cell = Grid[y, x];
        
        return cell is GridCell.Empty or GridCell.Goal;
    }
    
    public bool CheckVictory()
    {
        return _boxesOnGoal == _totalBoxes;
    }
    
    public Box GetBoxAt(int x, int y)
    {
        if (Grid[x, y] == GridCell.Box || Grid[x, y] == GridCell.BoxOnGoal)
        {
            return new Box(new Vector2(x * CellSize, y * CellSize));
        }
        return null;
    }

    // Проверка, есть ли ящик в клетке
    public bool HasBoxAt(int x, int y)
    {
        return _grid[x, y] == GridCell.Box || _grid[x, y] == GridCell.BoxOnGoal;
    }
}