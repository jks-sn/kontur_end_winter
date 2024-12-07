//Sokoban/Program.cs

using Sokoban.ConsoleApp;
using Sokoban.Utils;

namespace Sokoban;

class Program
{
    static void Main(string[] args)
    {
        const string levelData = "#######\n" +
                                 "#     #\n" +
                                 "# $ @ #\n" +
                                 "#  .  #\n" +
                                 "#######\n";
        
        var level = LevelLoader.LoadLevel(levelData);
        
        GameConsole.RunGame(level);
    }
}
