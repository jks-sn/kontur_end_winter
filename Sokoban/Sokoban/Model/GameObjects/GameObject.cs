//Sokoban/Model/GameObjects/GameObject.cs

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sokoban.Model.GameObjects;
public abstract class GameObject(GridPosition position)
{
    public GridPosition Position { get; set;} = position;

    public abstract void Draw(SpriteBatch spriteBatch);

    public void Move(int deltaX, int deltaY)
    {
        Position = new GridPosition(Position.X + deltaX, Position.Y + deltaY);
    }
}