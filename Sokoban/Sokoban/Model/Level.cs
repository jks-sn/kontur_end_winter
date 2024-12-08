//Sokoban/Model/Level.cs

using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sokoban.Model.GameObjects;
using Sokoban.Utils;

namespace Sokoban.Model;
public class Level(int width, int height)
{
    public string Name { get; set; }
    public string LevelLayout { get; set; }
    public Warehouse warehouse { get; } = new(width, height);
    
    private Player _player;
    private readonly List<Box> _boxes = [];          
    
    public void SetPlayer(Player player)
    {
        _player = player;
        warehouse.SetCell(_player.Position, GridCell.Player);
    }

    public void AddBox(Box box)
    {
        _boxes.Add(box);
        warehouse.SetCell(box.Position, GridCell.Box);
    }
    
    public Player GetPlayer() => _player;
    public IEnumerable<Box> GetBoxes() => _boxes;
    
    public bool MovePlayer(int deltaX, int deltaY)
    {
        var currentPosition = _player.Position;
        var newPosition = new GridPosition(currentPosition.X + deltaX, currentPosition.Y + deltaY);
        
        if (warehouse.GetCell(newPosition) == GridCell.Wall)
        {
            return false;
        }
        
        var box = _boxes.Find(b => b.Position.Equals(newPosition));
        if (box != null)
        {
            var newBoxPosition = new GridPosition(newPosition.X + deltaX, newPosition.Y + deltaY);
            
            if (warehouse.GetCell(newBoxPosition) != GridCell.Empty || _boxes.Exists(b => b.Position.Equals(newBoxPosition)))
            {
                return false;
            }
            
            warehouse.SetCell(box.Position, GridCell.Empty);
            box.Move(deltaX, deltaY);
            warehouse.SetCell(box.Position, GridCell.Box);
        }
        
        if (warehouse.GetCell(newPosition) != GridCell.Empty && warehouse.GetCell(newPosition) != GridCell.Goal)
        {
            return false;
        }
        
        warehouse.SetCell(_player.Position, GridCell.Empty);
        _player.Move(deltaX, deltaY);
        warehouse.SetCell(_player.Position, GridCell.Player);

        return true;
    }
    public void Draw(SpriteBatch spriteBatch)
    {
        for (var y = 0; y < warehouse.Height; y++)
        {
            for (var x = 0; x < warehouse.Width; x++)
            {
                var position = new GridPosition(x, y);
                var cell = warehouse.GetCell(position);

                switch (cell)
                {
                    case GridCell.Empty:
                        spriteBatch.Draw(ContentManager.BackgroundTexture, position.ToVector(), Color.White);
                        break;
                    case GridCell.Wall:
                        spriteBatch.Draw(ContentManager.WallTexture, position.ToVector(), Color.White);
                        break;
                    case GridCell.Goal:
                        spriteBatch.Draw(ContentManager.GoalTexture, position.ToVector(), Color.White);
                        break;
                }
            }
        }
        
        foreach (var box in _boxes)
        {
            box.Draw(spriteBatch);
        }
        
        _player?.Draw(spriteBatch);
    }
}
