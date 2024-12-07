//Sokoban/SokobanGame.cs

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sokoban.Game;
using Sokoban.Model;
using Sokoban.Model.GameObjects;
using Sokoban.Utils;

namespace Sokoban;

public class SokobanGame : Microsoft.Xna.Framework.Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    
    private Player _player;
    private List<LevelData> _levels;
    private Level _level;
    private Texture2D _wallTexture, _playerTexture, _boxTexture, _goalTexture;

    public SokobanGame()
    {
        _graphics = new GraphicsDeviceManager(this)
        {
            PreferredBackBufferWidth = 800,
            PreferredBackBufferHeight = 600
        };
        Content.RootDirectory = "Content";
    }

    protected override void Initialize()
    {
        base.Initialize();
    }
    
    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        // Загрузка текстур
        _wallTexture = Content.Load<Texture2D>("wall");
        _playerTexture = Content.Load<Texture2D>("player");
        _boxTexture = Content.Load<Texture2D>("box");
        _goalTexture = Content.Load<Texture2D>("goal");

        // Инициализация уровня
        _level = new Level("Level 1", _wallTexture, _playerTexture, _boxTexture, _goalTexture);
        
        _player = _level.Objects.OfType<Player>().FirstOrDefault();
        if (_player == null)
        {
            throw new InvalidOperationException("Level does not contain a Player object.");
        }
    }
    
    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            Keyboard.GetState().IsKeyDown(Keys.Escape))
        {
            Exit();
        }
        
        InputHandler.HandleInput(gameTime, _player);

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
        _wallTexture.Dispose();
        _playerTexture.Dispose();
        _boxTexture.Dispose();
        _goalTexture.Dispose();

        base.UnloadContent();
    }
}