//Sokoban/Model/GameObjects/Box.cs

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sokoban.Utils;

namespace Sokoban.Model.GameObjects;
public class Box(GridPosition position) : GameObject(position)
{
    
    public override void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(ContentManager.BoxTexture, position.ToRectangle(), Color.Brown);
    }
}
