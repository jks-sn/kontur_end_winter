//Sokoban/GameSokoban.cs

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sokoban.Model;
using Sokoban.Model.GameObjects;
using Sokoban.Utils;

namespace Sokoban;

public class GameSokoban : Microsoft.Xna.Framework.Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private Player _player;
    private Level _level;
    private ContentManager _contentManager;
    
    // private List<LevelData> _levels;
    
    private bool _isMoving = false;
    public GameSokoban()
    {
        _graphics = new GraphicsDeviceManager(this)
        {
            PreferredBackBufferWidth = 800,
            PreferredBackBufferHeight = 600
        };
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        _contentManager.LoadContent();
        
        _level = LevelLoader.LoadFromFile("Content/Levels/Level1.txt");
        _player = new Player(new Vector2(100, 100), _contentManager.PlayerTexture);
    }

    protected override void Update(GameTime gameTime)
    {
        var keyboardState = Keyboard.GetState();
        if (keyboardState.IsKeyDown(Keys.Escape))
        {
            Exit();
        }

        if (!keyboardState.IsKeyDown(Keys.Up) && !keyboardState.IsKeyDown(Keys.Down) && !keyboardState.IsKeyDown(Keys.Left) && !keyboardState.IsKeyDown(Keys.Right))
        {
            _isMoving = false;
        }

        if (!_isMoving)
        {
            if (keyboardState.IsKeyDown(Keys.Up))
            {
                _player.Move(0, -1, _level._Warehouse);
                _isMoving = true;
            }
            else if (keyboardState.IsKeyDown(Keys.Down))
            {
                _player.Move(0, 1, _level._Warehouse);
                _isMoving = true;
            }
            else if (keyboardState.IsKeyDown(Keys.Left))
            {
                _player.Move(-1, 0, _level._Warehouse);
                _isMoving = true;
            }
            else if (keyboardState.IsKeyDown(Keys.Right))
            {
                _player.Move(1, 0, _level._Warehouse);
                _isMoving = true;
            }
        }

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin();
        
        _level.Draw(_spriteBatch);
        _player.Draw(_spriteBatch);

        _spriteBatch.End();

        base.Draw(gameTime);
    }
    
    protected override void UnloadContent()
    {
        _contentManager.WallTexture.Dispose();
        _contentManager.PlayerTexture.Dispose();
        _contentManager.BoxTexture.Dispose();
        _contentManager.GoalTexture.Dispose();

        base.UnloadContent();
    }
}

public class ContentManager
{
    private readonly Microsoft.Xna.Framework.Game _game;
    public Texture2D WallTexture { get; private set; }
    public Texture2D PlayerTexture { get; private set; }
    public Texture2D BoxTexture { get; private set; }
    public Texture2D GoalTexture { get; private set; }

    public ContentManager(Microsoft.Xna.Framework.Game game)
    {
        _game = game;
    }

    public void LoadContent()
    {
        WallTexture = _game.Content.Load<Texture2D>("wall");
        PlayerTexture = _game.Content.Load<Texture2D>("player");
        BoxTexture = _game.Content.Load<Texture2D>("box");
        GoalTexture = _game.Content.Load<Texture2D>("goal");
    }
}