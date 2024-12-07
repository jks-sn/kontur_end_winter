using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sokoban.Model.GameObjects;

public class Goal : GameObject
{
    private readonly Texture2D _texture;

    public Goal(Vector2 position, Texture2D texture)
    {
        Position = position;
        _texture = texture;
    }

    public override void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(_texture, Position, Color.Green);
    }
}