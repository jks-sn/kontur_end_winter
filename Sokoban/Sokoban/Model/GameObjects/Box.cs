//Sokoban/Model/GameObjects/Box.cs

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sokoban.Utils;

namespace Sokoban.Model.GameObjects;
public class Box(GridPosition position) : GameObject(position)
{
    
    public override void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(ContentManager.BoxTexture, GetPixelPosition(), Color.Brown);
    }
    
    public void Move(int deltaX, int deltaY)
    {
        Position = new GridPosition(Position.X + deltaX, Position.Y + deltaY);
    }
}
