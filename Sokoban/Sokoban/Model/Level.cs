//Sokoban/Model/Level.cs

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
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
    
    public bool IsVictory => _boxes.Count == 0;

    
    public void SetPlayer(Player player)
    {
        _player = player;
    }

    public void AddBox(Box box)
    {
        _boxes.Add(box);
    }
    
    public Player GetPlayer() => _player;
    public IEnumerable<Box> GetBoxes() => _boxes;
    
    public bool MovePlayer(int deltaX, int deltaY)
    {
        if (IsVictory)
        {
            return false;
        }
        var moved = TryMoveObject(_player, deltaX, deltaY);
        return moved;
    }
    
    private bool TryMoveObject(GameObject obj, int dx, int dy)
    {
        var currentPosition = obj.Position;
        var newPosition = new GridPosition(currentPosition.X + dx, currentPosition.Y + dy);

        if (!IsMoveAvailable(newPosition))
        {
            return false;
        }
        
        var box = _boxes.Find(b => b.Position.Equals(newPosition));
        if (box != null)
        {
            if (!TryMoveObject(box, dx, dy))
                return false;
        }
        
        obj.Move(dx, dy);
        return true;
    }
    
    private bool IsMoveAvailable(GridPosition position)
    {
        if (position.X < 0 || position.Y < 0 || position.X >= warehouse.Width || position.Y >= warehouse.Height)
            return false;

        var cell = warehouse.GetCell(position);
        return cell is GridCell.Empty or GridCell.Goal;
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
                        spriteBatch.Draw(ContentManager.BackgroundTexture, position.ToRectangle(), Color.White);
                        break;
                    case GridCell.Wall:
                        spriteBatch.Draw(ContentManager.WallTexture, position.ToRectangle(), Color.White);
                        break;
                    case GridCell.Goal:
                        spriteBatch.Draw(ContentManager.GoalTexture, position.ToRectangle(), Color.White);
                        break;
                    default:
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
