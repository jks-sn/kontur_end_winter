// Sokoban/Model/GameObjects/GridPosition.cs

using System;
using Microsoft.Xna.Framework;

namespace Sokoban.Model.GameObjects;
public class GridPosition(int x, int y)
{
    public int X { get; } = x;
    public int Y { get; } = y;
    
    public static GridPosition FromVector(Vector2 position)
    {
        return new GridPosition((int)(position.X / Warehouse.CellSize), (int)(position.Y / Warehouse.CellSize));
    }
    
    public Vector2 ToVector()
    {
        return new Vector2(X * Warehouse.CellSize, Y * Warehouse.CellSize);
    }

    public override bool Equals(object obj)
    {
        return obj is GridPosition position && X == position.X && Y == position.Y;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y);
    }
    
    // public static implicit operator GridPosition(Vector2 position)
    // {
    //     return FromVector(position);
    // }
    //
    // public static implicit operator Vector2(GridPosition gridPosition)
    // {
    //     return gridPosition.ToVector();
    // }
}