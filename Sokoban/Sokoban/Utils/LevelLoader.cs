//Sokoban/Utils/LevelLoader.cs

using Sokoban.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Xna.Framework.Graphics;
using Sokoban.Model.GameObjects;

namespace Sokoban.Utils;

public static class LevelLoader
{
    public static Level LoadFromFile(string filePath)
    {
        var lines = File.ReadAllLines(filePath);
        var width = lines[0].Length;
        
        if (lines.Any(line => line.Length != width))
        {
            throw new InvalidOperationException("All lines in the level file must have the same length.");
        }
        
        var height = lines.Length;
        var level = new Level(width, height);

        for (var y = 0; y < height; y++)
        {
            for (var x = 0; x < width; x++)
            {
                var cell = lines[y][x];
                var position = new GridPosition(x, y);

                switch (cell)
                {
                    case '#':
                        level.warehouse.SetCell(position, GridCell.Wall);
                        break;
                    case '@':
                        level.SetPlayer(new Player(position));
                        level.warehouse.SetCell(position, GridCell.Empty);
                        break;
                    case '$':
                        level.AddBox(new Box(position));
                        level.warehouse.SetCell(position, GridCell.Empty);
                        break;
                    case '.':
                        level.warehouse.SetCell(position, GridCell.Goal);
                        break;
                    default:
                        level.warehouse.SetCell(position, GridCell.Empty);
                        break;
                }
            }
        }
        return level;
    }
}