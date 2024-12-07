// //Sokoban/Core/GameLogic.cs
//
// using Sokoban.Model;
// using Sokoban.Model.GameObjects;
//
// namespace Sokoban.Core;
//
// public class GameLogic(_Warehouse warehouse, Player player, List<Box> boxes, List<Goal> goals)
// {
//     public bool CanMovePlayer(int dx, int dy)
//     {
//         int newX = player.X + dx;
//         int newY = player.Y + dy;
//
//         if (IsOutOfBounds(newX, newY))
//         {
//             return false;
//         }
//         
//         if (warehouse.Grid[newY][newX] == GridCell.Wall)
//         {
//             return false;
//         }
//         
//         if (warehouse.Grid[newY][newX] == GridCell.Box)
//         {
//             return CanMoveBox(newX, newY, dx, dy);
//         }
//
//         return true;
//     }
//
//     public void MovePlayer(int dx, int dy)
//     {
//         if (CanMovePlayer(dx, dy))
//         {
//             warehouse.Grid[player.Y][player.X] = GridCell.Empty;
//             player.Move(dx, dy);
//             warehouse.Grid[player.Y][player.X] = GridCell.Player; 
//         }
//     }
//
//     private bool CanMoveBox(int boxX, int boxY, int dx, int dy)
//     {
//         int newBoxX = boxX + dx;
//         int newBoxY = boxY + dy;
//
//         // Check if the box can be moved
//         if (IsOutOfBounds(newBoxX, newBoxY) || warehouse.Grid[newBoxY][newBoxX] == GridCell.Wall || warehouse.Grid[newBoxY][newBoxX] == GridCell.Box)
//         {
//             return false;
//         }
//         
//         Box box = boxes.First(b => b.X == boxX && b.Y == boxY);
//         box.Move(dx, dy);
//         warehouse.Grid[box.Y][box.X] = GridCell.Box; 
//         warehouse.Grid[newBoxY][newBoxX] = GridCell.Box; 
//
//         return true;
//     }
//
//     private bool IsOutOfBounds(int x, int y)
//     {
//         return x < 0 || x >= warehouse.Width || y < 0 || y >= warehouse.Height;
//     }
//
//     public bool IsLevelComplete()
//     {
//         foreach (var box in boxes)
//         {
//             if (!goals.Any(g => g.X == box.X && g.Y == box.Y))
//             {
//                 return false;
//             }
//         }
//         return true;
//     }
// }
