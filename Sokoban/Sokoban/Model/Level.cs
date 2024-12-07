//Sokoban/Model/Level.cs

using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sokoban.Model.GameObjects;

namespace Sokoban.Model;
public class Level(LevelData data)
{
    public LevelData Data { get;  private set; } = data ?? throw new ArgumentNullException(nameof(data));

    public Warehouse _Warehouse { get; private set; } = new(data.Width, data.Height);
    
    public void LoadFromLayout(string[] layout)
    {
        for (var y = 0; y < layout.Length; y++)
        {
            for (var x = 0; x < layout[y].Length; x++)
            {
                var cell = layout[y][x];
                switch (cell)
                {
                    case '#':
                        _Warehouse.SetCell(x, y, GridCell.Wall);
                        break;
                    case '.':
                        _Warehouse.SetCell(x, y, GridCell.Goal);
                        break;
                    case '@':
                        _Warehouse.SetCell(x, y, GridCell.Player);
                        break;
                    case '$':
                        _Warehouse.SetCell(x, y, GridCell.Box);
                        break;
                    case ' ':
                        _Warehouse.SetCell(x, y, GridCell.Empty);
                        break;
                    default:
                        throw new ArgumentException($"Неизвестный символ '{cell}' в уровне.");
                }
            }
        }
    }
    public void Draw(SpriteBatch spriteBatch, Texture2D wallTexture, Texture2D goalTexture, Texture2D boxTexture, Texture2D playerTexture)
    {
        const int cellSize = 32;

        for (var y = 0; y < _Warehouse.Height; y++)
        {
            for (var x = 0; x < _Warehouse.Width; x++)
            {
                var cell = _Warehouse.GetCell(x, y);
                var position = new Vector2(x * cellSize, y * cellSize);

                switch (cell)
                {
                    case GridCell.Wall:
                        spriteBatch.Draw(wallTexture, position, Color.White);
                        break;
                    case GridCell.Goal:
                        spriteBatch.Draw(goalTexture, position, Color.White);
                        break;
                    case GridCell.Box:
                        spriteBatch.Draw(boxTexture, position, Color.White);
                        break;
                    case GridCell.Player:
                        spriteBatch.Draw(playerTexture, position, Color.White);
                        break;
                    case GridCell.Empty:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
    }

}
