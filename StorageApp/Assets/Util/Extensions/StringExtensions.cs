using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StringExtensions 
{
    public static Sprite GetSpriteFromBase64(this string base64)
    {
        byte[] imageBytes = Convert.FromBase64String(base64);
        Texture2D tex = new Texture2D(2, 2);
        tex.LoadImage(imageBytes);
        return Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100.0f);
    }
}
