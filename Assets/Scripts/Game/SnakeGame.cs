using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SnakeGame {
    
    public enum Direction {
        Up,
        Right,
        Left,
        Down
    }
    
    public Vector2Int GamePosition { get; }
    public Vector2Int GameSize { get; }
    public int GameScale { get; private set; }

    public LinkedList<Vector2Int> Snake { get; private set; }
    public Vector2Int Apple { get; private set; }
    
    private Vector2Int _direction;
    private Dictionary<Direction, Vector2Int> _directions = new() {
        { Direction.Up, Vector2Int.up },
        { Direction.Right, Vector2Int.right },
        { Direction.Down, Vector2Int.down },
        { Direction.Left, Vector2Int.left }
    };

    public SnakeGame(Vector2Int gamePosition, Vector2Int gameSize, int gameScale) {
        GamePosition = gamePosition;
        GameSize = gameSize;
        GameScale = gameScale;
    }

    public void Reset(Vector2Int position, Direction direction, int length) {
        _direction = _directions[direction];
        
        Snake = new();
        for (var i = 0; i < length; i++)
            Snake.AddFirst(position + i * _direction);
        
        PlaceApple();
    }

    public void Tick() {
        Vector2Int head = Snake.First.Value + _direction;

        if (head.x < 0)
            head.x += GameSize.x;
        if (head.y < 0)
            head.y += GameSize.y;
        if (head.x >= GameSize.x)
            head.x -= GameSize.x;
        if (head.y >= GameSize.y)
            head.y -= GameSize.y;
        
        Snake.AddFirst(head);

        if (Snake.First.Value == Apple)
            PlaceApple();
        else
            Snake.RemoveLast();
    }

    public void SetDirection(Direction direction) {
        _direction = _directions[direction];
    }

    private void PlaceApple() {
        var apple = -Vector2Int.one;

        while (apple.x < 0) {
            apple = new Vector2Int(Random.Range(0, GameSize.x), Random.Range(0, GameSize.y));

            foreach (var link in Snake) {
                if (apple == link) {
                    apple = -Vector2Int.one;
                    break;
                }
            }
        }

        Apple = apple;
    }
}
