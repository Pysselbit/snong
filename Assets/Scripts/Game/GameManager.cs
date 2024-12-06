using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour {
    
    [SerializeField] private Vector2Int _leftSnakeGamePosition;
    [SerializeField] private Vector2Int _rightSnakeGamePosition;
    
    [Space]
    [SerializeField] private Vector2Int _snakeGameSize = Vector2Int.one;
    [SerializeField] private int _snakeGameScale = 1;

    [Space]
    [SerializeField] private float _snakeTickDuration = 1f;

    private float _nextSnakeTick;

    public Game Game { get; private set; }
    
    private void Awake() {
        Game = new Game(_leftSnakeGamePosition, _rightSnakeGamePosition, _snakeGameSize, _snakeGameScale);

        _nextSnakeTick = _snakeTickDuration;
    }

    private void Update() {
        HandleInput();
        
        if (Time.time >= _nextSnakeTick) {
            Game.TickSnakeGames();

            _nextSnakeTick += _snakeTickDuration;
        }
    }

    private void HandleInput() {
        if (Input.GetKeyDown(KeyCode.W))
            Game.LeftSnakeGame.SetDirection(SnakeGame.Direction.Up);
        if (Input.GetKeyDown(KeyCode.D))
            Game.LeftSnakeGame.SetDirection(SnakeGame.Direction.Right);
        if (Input.GetKeyDown(KeyCode.S))
            Game.LeftSnakeGame.SetDirection(SnakeGame.Direction.Down);
        if (Input.GetKeyDown(KeyCode.A))
            Game.LeftSnakeGame.SetDirection(SnakeGame.Direction.Left);
        
        if (Input.GetKeyDown(KeyCode.UpArrow))
            Game.RightSnakeGame.SetDirection(SnakeGame.Direction.Up);
        if (Input.GetKeyDown(KeyCode.RightArrow))
            Game.RightSnakeGame.SetDirection(SnakeGame.Direction.Right);
        if (Input.GetKeyDown(KeyCode.DownArrow))
            Game.RightSnakeGame.SetDirection(SnakeGame.Direction.Down);
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            Game.RightSnakeGame.SetDirection(SnakeGame.Direction.Left);
    }
}
