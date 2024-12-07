// Sokoban/Model/GameObjects/Player.cs

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

    public void Move(int deltaX, int deltaY)
    {
        Position = new Vector2(Position.X + deltaX, Position.Y + deltaY);
    }
}