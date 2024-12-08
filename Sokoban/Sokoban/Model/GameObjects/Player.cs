// Sokoban/Model/GameObjects/Player.cs

using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sokoban.Utils;

namespace Sokoban.Model.GameObjects;

public class Player(GridPosition position) : GameObject(position)
{
    public override void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(ContentManager.PlayerTexture, position.ToRectangle(), Color.White);
    }
}