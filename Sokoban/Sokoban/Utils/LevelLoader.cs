//Sokoban/Utils/LevelLoader.cs

using Sokoban.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Xna.Framework.Graphics;
using Sokoban.Model.GameObjects;

namespace Sokoban.Utils;

public static class LevelLoader
{
    public static Level LoadFromFile(string filePath)
    {
        // Читаем текстовый файл в строки
        var layout = ReadLevelFromFile(filePath);

        // Предполагаем, что ширина и высота уровня известны
        var height = layout.Length;
        var width = layout[0].Length;
        
        // Создаем уровень
        var level = new Level(new LevelData { Name = "Loaded Level", Width = width, Height = height });
        level.LoadFromLayout(layout);

        return level;
    }
    
    private static string[] ReadLevelFromFile(string filePath)
    {
        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException($"Файл {filePath} не найден.");
        }
        
        var lines = File.ReadAllLines(filePath);
        
        var width = lines[0].Length;
        if (lines.Any(line => line.Length != width))
        {
            throw new InvalidOperationException("Все строки в уровне должны быть одинаковой длины.");
        }

        return lines;
    }
}