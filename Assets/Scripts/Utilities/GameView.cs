using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameView : MonoBehaviour {

    [SerializeField] private GameManager _gameManager;
    [SerializeField] private ScreenController _screenController;

    [Space]
    [SerializeField] private RectInt _screenArea;
    [SerializeField] private RectInt _separatorArea;

    private Game _game;

    private void Start() {
        _game = _gameManager.Game;
        
        UpdateScreen();
        
        _game.OnTick += UpdateScreen;
    }

    private void UpdateScreen() {
        ClearScreen();
        DrawSeparator();
        
        DrawSnakeGame(_game.LeftSnakeGame);
        DrawSnakeGame(_game.RightSnakeGame);
    }

    private void ClearScreen() {
        for (var x = _screenArea.min.x; x < _screenArea.max.x; x++) {
            for (var y = _screenArea.min.y; y < _screenArea.max.y; y++) {
                _screenController.SetPixel(x, y, false);
            }
        }
    }

    private void DrawSeparator() {
        for (var x = _separatorArea.xMin; x < _separatorArea.xMax; x++) {
            for (var y = _separatorArea.yMin; y < _separatorArea.yMax; y++) {
                _screenController.SetPixel(x, y, true);
            }
        }
    }

    private void DrawSnakeGame(SnakeGame snakeGame) {
        var position = snakeGame.Position;
        var scale = snakeGame.Scale;
        var snake = snakeGame.Snake;
        
        foreach (var link in snake) {
            for (var x = scale * link.x; x < scale * (link.x + 1); x++) {
                for (var y = scale * link.y; y < scale * (link.y + 1); y++) {
                    _screenController.SetPixel(position.x + x, position.y + y, true);
                }
            }
        }

        var head = snake.First.Value;
        for (var x = scale * head.x + 1; x < scale * (head.x + 1) - 1; x++) {
            for (var y = scale * head.y + 1; y < scale * (head.y + 1) - 1; y++) {
                _screenController.SetPixel(position.x + x, position.y + y, false);
            }
        }

        var apple = snakeGame.Apple;
        for (var x = scale * apple.x + 1; x < scale * (apple.x + 1) - 1; x++) {
            for (var y = scale * apple.y + 1; y < scale * (apple.y + 1) - 1; y++) {
                _screenController.SetPixel(position.x + x, position.y + y, true);
            }
        }
    }
}
