// // Sokoban/Utils/InputHandler.cs
//
// using Microsoft.Xna.Framework;
// using Microsoft.Xna.Framework.Input;
// using Sokoban.Model;
// using Sokoban.Model.GameObjects;
//
// namespace Sokoban.Utils;
//
// public  static class InputHandler
// {
//     public static void HandleInput(GameTime gameTime, Player player, Level level)
//     {
//         var keyboardState = Keyboard.GetState();
//         
//         if (keyboardState.IsKeyDown(Keys.Up))
//         {
//             player.Move(0, -1, level.Wa); 
//         }
//         else if (keyboardState.IsKeyDown(Keys.Down))
//         {
//             player.Move(0, 1); 
//         }
//         else if (keyboardState.IsKeyDown(Keys.Left))
//         {
//             player.Move(-1, 0); 
//         }
//         else if (keyboardState.IsKeyDown(Keys.Right))
//         {
//             player.Move(1, 0);
//         }
//     }
// }