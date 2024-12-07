//Sokoban/Model/GameObject/Wall.cs

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sokoban.Model.GameObjects;

public class Wall : GameObject
{
    private readonly Texture2D _texture;

    public Wall(Vector2 position, Texture2D texture)
    {
        Position = position;
        _texture = texture;
    }

    public override void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(_texture, Position, Color.Gray);
    }
}
