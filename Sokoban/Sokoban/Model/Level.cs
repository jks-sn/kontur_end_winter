//Sokoban/Model/Level.cs

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sokoban.Model.GameObjects;

namespace Sokoban.Model;
public class Level
{
    public LevelData Data { get;  private set; }
    public IReadOnlyList<GameObject> Objects => _objects;
    
    private readonly List<GameObject> _objects = [];

    public Level(LevelData data)
    {
        Data = data ?? throw new ArgumentNullException(nameof(data));
    }
    
    public Level(string levelName, Texture2D wallTexture, Texture2D playerTexture, Texture2D boxTexture, Texture2D goalTexture)
    {
        Data = LoadLevelData(levelName); 
        LoadObjects(wallTexture, playerTexture, boxTexture, goalTexture);
    }
    
    private static LevelData LoadLevelData(string levelName)
    {
        if (levelName == "Level 1")
        {
            return new LevelData
            {
                Name = "Level 1",
                Width = 5,
                Height = 5,
                LevelLayout = "#####@" +
                              "#####$" +
                              "$###.#" +
                              ".#####" +
                              "######"
            };
        }

        throw new ArgumentException($"Level {levelName} not found.");
    }
    
    public void LoadObjects(Texture2D wallTexture, Texture2D playerTexture, Texture2D boxTexture, Texture2D goalTexture)
    {
        Reset();
        
        for (var y = 0; y < Data.Height; y++)
        {
            for (var x = 0; x < Data.Width; x++)
            {
                var character = Data.LevelLayout[y * Data.Width + x];
                var position = new Vector2(x * 32, y * 32);

                switch (character)
                {
                    case '#':
                        _objects.Add(new Wall(position, wallTexture));
                        break;
                    case '@':
                        _objects.Add(new Player(position, playerTexture));
                        break;
                    case '$':
                        _objects.Add(new Box(position, boxTexture));
                        break;
                    case '.':
                        _objects.Add(new Goal(position, goalTexture));
                        break;
                    default:
                        break;
                }
            }
        }
    }
    
    public void Draw(SpriteBatch spriteBatch)
    {
        foreach (var gameObject in _objects)
        {
            gameObject.Draw(spriteBatch);
        }
    }

    public void Reset()
    {
        _objects.Clear();
    }
}
