using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class WeaponSprite : MonoBehaviour
{
    [SerializeField] private float _angleRotationModifier;

    protected SpriteRenderer SpriteRenderer;

    public float AngleRotationModifier { get => _angleRotationModifier; set => _angleRotationModifier = value; }

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
