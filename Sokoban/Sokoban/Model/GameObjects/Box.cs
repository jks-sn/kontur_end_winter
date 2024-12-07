//Sokoban/Model/GameObjects/Box.cs

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sokoban.Model.GameObjects;
public class Box : GameObject
{
    private readonly Texture2D _texture;

    public Box(Vector2 position)
    {
        Position = position;
    }

    public override void Draw(SpriteBatch spriteBatch, Texture2D texture)
    {
        spriteBatch.Draw(_texture, Position, Color.Brown);
    }
    
    public void Move(int deltaX, int deltaY)
    {
        var newX = (int)Position.X / 32 + deltaX;
        var newY = (int)Position.Y / 32 + deltaY;
        Position += new Vector2(newX * 32, newY * 32);
    }
}
