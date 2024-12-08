using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongGame {
    
    public Vector2Int GamePosition { get; }
    public Vector2Int GameSize { get; }
    
    public Vector2Int Position;
    
    private Vector2Int _velocity;
    
    public PongGame(Vector2Int gamePosition, Vector2Int gameSize) {
        GamePosition = gamePosition;
        GameSize = gameSize;
    }
    
    public void Reset(Vector2Int velocity) {
        _velocity = velocity;
    }
    
    public void Tick() {
        if (Position.x + _velocity.x < 0 || Position.x >= GameSize.x)
            _velocity.x *= -1;
        if (Position.y + _velocity.y < 0 || Position.y >= GameSize.y)
            _velocity.y *= -1;

        Position += _velocity;
    }
}
