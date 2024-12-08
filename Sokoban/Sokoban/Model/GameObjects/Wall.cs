//Sokoban/Model/GameObject/Wall.cs

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sokoban.Utils;

namespace Sokoban.Model.GameObjects;

public class Wall(GridPosition position) : GameObject(position)
{
    public override void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(ContentManager.WallTexture, GetPixelPosition(), Color.Gray);
    }
    
    public void Move(int deltaX, int deltaY)
    {
        Position = new GridPosition(Position.X + deltaX, Position.Y + deltaY);
    }
}
