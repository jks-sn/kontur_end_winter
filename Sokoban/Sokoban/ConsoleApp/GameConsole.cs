// //Sokoban/ConsoleApp/GameConsole.cs
//
// using Sokoban.Model;
// using Sokoban.Core;
// using Sokoban.Utils;
// using System;
// using Sokoban.Model.GameObjects;
//
// namespace Sokoban.ConsoleApp;
//
// public static class GameConsole
// {
//     public static void RunGame(Level level)
//     {
//         var gameLogic = new GameLogic(level.Warehouse, level.Player, level.Boxes, level.Goals);
//         bool isGameOver = false;
//
//         while (!isGameOver)
//         {
//             Console.Clear();
//             DrawLevel(level);
//             var keyInfo = Console.ReadKey(true);
//             int dx = 0, dy = 0;
//             
//             switch (keyInfo.Key)
//             {
//                 case ConsoleKey.UpArrow:
//                     dy = -1;
//                     break;
//                 case ConsoleKey.DownArrow:
//                     dy = 1;
//                     break;
//                 case ConsoleKey.LeftArrow:
//                     dx = -1;
//                     break;
//                 case ConsoleKey.RightArrow:
//                     dx = 1;
//                     break;
//                 default:
//                     break;
//             }
//             
//             gameLogic.MovePlayer(dx, dy);
//             
//             if (gameLogic.IsLevelComplete())
//             {
//                 isGameOver = true;
//                 Console.Clear();
//                 DrawLevel(level);
//                 Console.WriteLine("Level Complete!");
//             }
//         }
//     }
//
//     private static void DrawLevel(Level level)
//     {
//         for (int y = 0; y < level.Warehouse.Height; y++)
//         {
//             for (int x = 0; x < level.Warehouse.Width; x++)
//             {
//                 var cell = level.Warehouse.Grid[y][x];
//                 switch (cell)
//                 {
//                     case GridCell.Wall:
//                         Console.Write('#');
//                         break;
//                     case GridCell.Box:
//                         Console.Write('$');
//                         break;
//                     case GridCell.Goal:
//                         Console.Write('.');
//                         break;
//                     case GridCell.Player:
//                         Console.Write('@');
//                         break;
//                     case GridCell.Empty:
//                         Console.Write(' ');
//                         break;
//                 }
//             }
//
//             Console.WriteLine();
//         }
//     }
// }