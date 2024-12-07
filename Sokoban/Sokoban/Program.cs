using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Sokoban;
public static class Program
{
    [STAThread]
    static void Main()
    {
        using (var game = new SokobanGame())
            game.Run();
    }
}