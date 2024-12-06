using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenController : MonoBehaviour {
    
    private Texture2D _texture;

    private int _width;
    private int _height;

    private bool _isDirty;

    private void Awake() {
        var rawImage = GetComponent<RawImage>();
        _texture = Instantiate(rawImage.texture) as Texture2D;
        rawImage.texture = _texture;
        
        _width = _texture.width;
        _height = _texture.height;
    }

    private void LateUpdate() {
        if (_isDirty) {
            _texture.Apply();
            _isDirty = false;
        }
    }

    public void SetPixel(int x, int y, bool active) {
        if (x < 0 || x >= _width || y < 0 || y >= _height)
            return;

        var color = active ? Color.black : Color.clear;
        _texture.SetPixel(x, y, color);
        
        _isDirty = true;
    }
}
