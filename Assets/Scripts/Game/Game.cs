using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game {

    public event Action OnTick;

    public SnakeGame LeftSnakeGame { get; }
    public SnakeGame RightSnakeGame { get; }

    public Game(Vector2Int leftSnakeGamePosition, Vector2Int rightSnakeGamePosition, Vector2Int snakeGameSize, int snakeScale) {
        LeftSnakeGame = new SnakeGame(leftSnakeGamePosition, snakeGameSize, snakeScale);
        RightSnakeGame = new SnakeGame(rightSnakeGamePosition, snakeGameSize, snakeScale);
        
        LeftSnakeGame.Initialize(Vector2Int.zero, SnakeGame.Direction.Up, 5);
        RightSnakeGame.Initialize(snakeGameSize - Vector2Int.one, SnakeGame.Direction.Down, 5);
    }

    public void TickSnakeGames() {
        LeftSnakeGame.Tick();
        RightSnakeGame.Tick();
        
        OnTick?.Invoke();
    }
}
