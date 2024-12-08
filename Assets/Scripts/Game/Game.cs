using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game {

    public event Action OnTick;

    public SnakeGame LeftSnakeGame { get; }
    public SnakeGame RightSnakeGame { get; }
    public PongGame PongGame { get; }

    public Game(Vector2Int pongGamePosition, Vector2Int pongGameSize, Vector2Int pongVelocity,
        Vector2Int leftSnakeGamePosition, Vector2Int rightSnakeGamePosition,
        Vector2Int snakeGameSize, int snakeScale, int snakeLength) {
        PongGame = new PongGame(pongGamePosition, pongGameSize);
        LeftSnakeGame = new SnakeGame(leftSnakeGamePosition, snakeGameSize, snakeScale);
        RightSnakeGame = new SnakeGame(rightSnakeGamePosition, snakeGameSize, snakeScale);
        
        PongGame.Reset(pongVelocity);
        LeftSnakeGame.Reset(Vector2Int.zero, SnakeGame.Direction.Up, snakeLength);
        RightSnakeGame.Reset(snakeGameSize - Vector2Int.one, SnakeGame.Direction.Down, snakeLength);
    }

    public void TickSnakeGames() {
        LeftSnakeGame.Tick();
        RightSnakeGame.Tick();
        
        OnTick?.Invoke();
    }

    public void TickPongGame() {
        PongGame.Tick();
        
        OnTick?.Invoke();
    }
}
