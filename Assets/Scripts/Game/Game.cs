using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game {

    public event Action OnTick;

    public SnakeGame LeftSnakeGame { get; }
    public SnakeGame RightSnakeGame { get; }

    public Game(Vector2Int leftSnakeGamePosition, Vector2Int rightSnakeGamePosition, Vector2Int snakeGameSize, int snakeScale, int snakeLength) {
        LeftSnakeGame = new SnakeGame(leftSnakeGamePosition, snakeGameSize, snakeScale);
        RightSnakeGame = new SnakeGame(rightSnakeGamePosition, snakeGameSize, snakeScale);
        
        LeftSnakeGame.Reset(Vector2Int.zero, SnakeGame.Direction.Up, snakeLength);
        RightSnakeGame.Reset(snakeGameSize - Vector2Int.one, SnakeGame.Direction.Down, snakeLength);
    }

    public void TickSnakeGames() {
        LeftSnakeGame.Tick();
        RightSnakeGame.Tick();
        
        OnTick?.Invoke();
    }
}
