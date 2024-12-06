using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class SnakeGame {
    
    public enum Direction {
        Up,
        Right,
        Left,
        Down
    }
    
    public Vector2Int Position { get; }
    public Vector2Int Size { get; }
    public int Scale { get; private set; }

    public LinkedList<Vector2Int> Snake { get; private set; }
    public Vector2Int Apple { get; private set; }
    
    private Vector2Int _direction;
    private Dictionary<Direction, Vector2Int> _directions = new() {
        { Direction.Up, Vector2Int.up },
        { Direction.Right, Vector2Int.right },
        { Direction.Down, Vector2Int.down },
        { Direction.Left, Vector2Int.left }
    };

    public SnakeGame(Vector2Int position, Vector2Int size, int scale) {
        Position = position;
        Size = size;
        Scale = scale;
    }

    public void Initialize(Vector2Int start, Direction direction, int length) {
        Snake = new();
        Apple = new Vector2Int(5, 5);
        
        _direction = _directions[direction];
        
        for (var i = 0; i < length; i++)
            Snake.AddFirst(start + i * _direction);
    }

    public void Tick() {
        Vector2Int head = Snake.First.Value + _direction;

        if (head.x < 0) head.x += Size.x;
        if (head.y < 0) head.y += Size.y;
        if (head.x >= Size.x) head.x -= Size.x;
        if (head.y >= Size.y) head.y -= Size.y;
        
        Snake.AddFirst(head);
        Snake.RemoveLast();
    }

    public void SetDirection(Direction direction) {
        _direction = _directions[direction];
    }
}
