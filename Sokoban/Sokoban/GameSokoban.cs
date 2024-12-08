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
    private Level _level;
    
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
        ContentManager.Initialize(this);
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        ContentManager.LoadContent();
        
        _level = LevelLoader.LoadFromFile("Content/Levels/Level1.txt");
        
        _graphics.PreferredBackBufferWidth = _level.warehouse.Width * Warehouse.CellSize;
        _graphics.PreferredBackBufferHeight = _level.warehouse.Height * Warehouse.CellSize;
        _graphics.ApplyChanges();
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
                 _level.MovePlayer(0, -1);
                _isMoving = true;
            }
            else if (keyboardState.IsKeyDown(Keys.Down))
            {
                _level.MovePlayer(0, 1);
                _isMoving = true;
            }
            else if (keyboardState.IsKeyDown(Keys.Left))
            {
                _level.MovePlayer(-1, 0);
                _isMoving = true;
            }
            else if (keyboardState.IsKeyDown(Keys.Right))
            {
                _level.MovePlayer(1, 0);
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

        _spriteBatch.End();

        base.Draw(gameTime);
    }
    
    protected override void UnloadContent()
    {
        ContentManager.UnloadContent();

        base.UnloadContent();
    }
}
