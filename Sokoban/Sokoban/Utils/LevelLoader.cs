//Sokoban/Utils/LevelLoader.cs

using Sokoban.Model;
using System;
using System.Collections.Generic;

namespace Sokoban.Utils;

public static class LevelLoader
{
    public static Level LoadLevel(string levelData)
    {
        var lines = levelData.Split("\n", StringSplitOptions.RemoveEmptyEntries);
        int width = lines[0].Length;
        int height = lines.Length;

        var warehouse = new Warehouse(width, height);
        var boxes = new List<Box>();
        var goals = new List<Goal>();
        Player player = null;

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                char tile = lines[y][x];
                switch (tile)
                {
                    case '#':
                        warehouse.Grid[y][x] = GridCell.Wall;
                        break;
                    case '$': 
                        warehouse.Grid[y][x] = GridCell.Box;
                        boxes.Add(new Box(x, y));
                        break;
                    case '.': 
                        warehouse.Grid[y][x] = GridCell.Goal;
                        goals.Add(new Goal(x, y));
                        break;
                    case '@':
                        warehouse.Grid[y][x] = GridCell.Player;
                        player = new Player(x, y);
                        break;
                    case ' ':
                        warehouse.Grid[y][x] = GridCell.Empty;
                        break;
                }
            }
        }

        return new Level("Sample Level", warehouse, boxes, goals, player);
    }
}