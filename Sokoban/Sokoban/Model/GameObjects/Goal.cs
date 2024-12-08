// //Sokoban/Model/GameObjects/Goal.cs
//
// using Microsoft.Xna.Framework;
// using Microsoft.Xna.Framework.Graphics;
// using Sokoban.Utils;
//
// namespace Sokoban.Model.GameObjects;
//
// public class Goal(GridPosition position) : GameObject(position)
// {
//     public override void Draw(SpriteBatch spriteBatch)
//     {
//         spriteBatch.Draw(ContentManager.GoalTexture, new Rectangle(position.X, position.Y, Warehouse.CellSize, Warehouse.CellSize), Color.Green);
//     }
// }