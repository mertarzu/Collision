using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorController : MonoBehaviour
{ 
    [SerializeField] SpriteRenderer _spriteRenderer;
    public void UpdateColor(Color color)
    {
        _spriteRenderer.color = color;
    }

}
