//Sokoban/Model/GameObjects/GameObject.cs

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sokoban.Model.GameObjects;
public abstract class GameObject
{
    public Vector2 Position { get; set; }
    public abstract void Draw(SpriteBatch spriteBatch, Texture2D texture);
}