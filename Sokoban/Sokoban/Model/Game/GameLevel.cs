using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Sokoban.Model;

namespace Sokoban.Game;

public class GameLevel
{
    public Level CurrentLevel { get; set; }
    public int LevelIndex { get; set; }

    public void LoadLevel(LevelData levelData, Texture2D wallTexture, Texture2D playerTexture, Texture2D boxTexture, Texture2D goalTexture)
    {
        CurrentLevel = new Level(levelData);
        CurrentLevel.LoadObjects(wallTexture, playerTexture, boxTexture, goalTexture);
    }

    public void LoadNextLevel(List<LevelData> levels, Texture2D wallTexture, Texture2D playerTexture, Texture2D boxTexture, Texture2D goalTexture)
    {
        LevelIndex++;
        if (LevelIndex >= levels.Count) LevelIndex = 0; // Если нет следующих уровней, начинаем сначала
        LoadLevel(levels[LevelIndex], wallTexture, playerTexture, boxTexture, goalTexture);
    }

    public void ResetLevel(Texture2D wallTexture, Texture2D playerTexture, Texture2D boxTexture, Texture2D goalTexture)
    {
        LoadLevel(CurrentLevel.Data, wallTexture, playerTexture, boxTexture, goalTexture);
    }
}