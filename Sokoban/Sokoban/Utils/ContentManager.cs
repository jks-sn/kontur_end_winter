//Sokoban/Utils/ContentManager.cs

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sokoban.Utils;

public static class ContentManager
{
    private static Microsoft.Xna.Framework.Content.ContentManager _content;

    public static Texture2D WallTexture { get; private set; }
    public static Texture2D PlayerTexture { get; private set; }
    public static Texture2D BoxTexture { get; private set; }
    public static Texture2D GoalTexture { get; private set; }
    
    public static Texture2D BackgroundTexture { get; private set; }

    public static void Initialize(Game game)
    {
        _content = game.Content;
    }

    public static void LoadContent()
    {
        WallTexture = _content.Load<Texture2D>("wall");
        PlayerTexture = _content.Load<Texture2D>("player");
        BoxTexture = _content.Load<Texture2D>("box");
        GoalTexture = _content.Load<Texture2D>("goal");
        BackgroundTexture = _content.Load<Texture2D>("background");
    }

    public static void UnloadContent()
    {
        WallTexture?.Dispose();
        PlayerTexture?.Dispose();
        BoxTexture?.Dispose();
        GoalTexture?.Dispose();
        BackgroundTexture?.Dispose();
    }
}