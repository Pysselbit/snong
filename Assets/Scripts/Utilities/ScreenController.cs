using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenController : MonoBehaviour {
    
    private Texture2D _texture;

    public int Width => _texture.width;
    public int Height => _texture.height;

    private bool _isDirty;

    private void Awake() {
        var rawImage = GetComponent<RawImage>();
        _texture = Instantiate(rawImage.texture) as Texture2D;
        rawImage.texture = _texture;
    }

    private void LateUpdate() {
        if (_isDirty) {
            _texture.Apply();
            _isDirty = false;
        }
    }

    public void SetPixel(Vector2Int position, bool active) {
        SetPixel(position.x, position.y, active);
    }

    public void SetPixel(int x, int y, bool active) {
        if (x < 0 || x >= Width || y < 0 || y >= Height)
            return;

        var color = active ? Color.black : Color.clear;
        _texture.SetPixel(x, y, color);
        
        _isDirty = true;
    }
}
