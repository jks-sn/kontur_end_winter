//Sokoban/Model/GameObjects/GameObject.cs

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sokoban.Model.GameObjects;
public abstract class GameObject(GridPosition position)
{
    public GridPosition Position { get; set;} = position;

    public abstract void Draw(SpriteBatch spriteBatch);
    
    public Vector2 GetPixelPosition()
    {
        return Position.ToVector();
    }
}