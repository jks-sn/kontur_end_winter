// Sokoban/Model/GameObjects/Player.cs

using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sokoban.Model.GameObjects;

public class Player : GameObject
{
    private readonly Texture2D _texture;

    public Player(Vector2 position, Texture2D texture)
    {
        Position = position;
        _texture = texture;
    }

    public override void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(_texture, Position, Color.White);
    }

    public void Move(int deltaX, int deltaY, Warehouse warehouse, List<Box>boxes)
    {
        var currentX = (int)Position.X / Warehouse.CellSize;
        var currentY = (int)Position.Y / Warehouse.CellSize;

        var newX = currentX + deltaX;
        var newY = currentY + deltaY;

        var box = warehouse.GetBoxAt(newX, newY);
        if (box != null)
        {
            var boxNewX = newX + deltaX;
            var boxNewY = newY + deltaY;

            if (!warehouse.CanMoveTo(boxNewX, boxNewY) || warehouse.HasBoxAt(boxNewX, boxNewY))
            {
                return;
            }

            box.Move(deltaX, deltaY);
        }
        else if (!warehouse.CanMoveTo(newX, newY))
        {
            return;
        }
        
        warehouse.SetCell(currentX, currentY, GridCell.Empty);
        warehouse.SetCell(newX, newY, GridCell.Player);
        
        Position = new Vector2(newX * Warehouse.CellSize, newY * Warehouse.CellSize);
    }
}