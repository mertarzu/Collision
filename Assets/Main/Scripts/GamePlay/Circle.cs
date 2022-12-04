using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour
{
    CircleInfo _circleInfo;
    public CircleInfo CircleInfo => _circleInfo;
    [SerializeField] CircleCollider2D _circleCollider;
    [SerializeField] ColorController _colorController;

    private void Awake()
    {
        CircleInfoSetup();
    }

    void CircleInfoSetup()
    {
        _circleInfo.Radius = _circleCollider.radius * transform.localScale.x; // circle
        _circleInfo.Position = new Vector2(transform.position.x, transform.position.y);
    }

    public void UpdatePosition()
    {
        _circleInfo.Position = new Vector2(transform.position.x, transform.position.y);      
    }
   
    public void UpdateColor(Color color)
    {
        _colorController.UpdateColor(color);
    }
    public void UpdateIsCollided(bool value)
    {
        _circleInfo.isCollided = value;
    }

}
public struct CircleInfo
{
    public float Radius;
    public Vector2 Position;
    public bool isCollided;
}
