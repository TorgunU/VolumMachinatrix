using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class WeaponSprite : MonoBehaviour
{
    protected SpriteRenderer SpriteRenderer;

    private void Awake()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetSprite(Sprite sprite)
    {
        if (sprite == null)
            Debug.LogError("Sprite is null");

        SpriteRenderer.sprite = sprite;
    }
}
