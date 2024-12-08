using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour {

    [SerializeField] private Vector2Int _pongGamePosition;
    [SerializeField] private Vector2Int _pongGameSize;
    
    [Space]
    [SerializeField] private Vector2Int _leftSnakeGamePosition;
    [SerializeField] private Vector2Int _rightSnakeGamePosition;
    
    [Space]
    [SerializeField] private Vector2Int _snakeGameSize = Vector2Int.one;
    [SerializeField] private int _snakeGameScale = 1;
    [SerializeField] private int _snakeLength = 4;

    [Space]
    [SerializeField] private float _pongTickDuration = 1f;
    [SerializeField] private float _snakeTickDuration = 1f;

    private float _nextPongTick;
    private float _nextSnakeTick;

    public Game Game { get; private set; }
    
    private void Awake() {
        Game = new Game(_pongGamePosition, _pongGameSize, Vector2Int.one,
            _leftSnakeGamePosition, _rightSnakeGamePosition, _snakeGameSize, _snakeGameScale, _snakeLength);

        _nextPongTick = _pongTickDuration;
        _nextSnakeTick = _snakeTickDuration;
    }

    private void Update() {
        HandleInput();
        
        if (Time.time >= _nextSnakeTick) {
            Game.TickSnakeGames();

            _nextSnakeTick += _snakeTickDuration;
        }
        
        if (Time.time >= _nextPongTick) {
            Game.TickPongGame();

            _nextPongTick += _pongTickDuration;
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
