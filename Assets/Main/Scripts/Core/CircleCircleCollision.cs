using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleCircleCollision : MonoBehaviour
{
    public Action OnDepthChange;
    public Action<Vector2> OnCollisionStart;
    public Action OnCollisionEnd;
    [SerializeField] List<Circle> _circles = new List<Circle>();
    List<int> collidedIndex = new List<int>();
    bool _isActive;

    private void FixedUpdate()
    {
        if (!_isActive) return;
        for(int i = 0; i < _circles.Count; i++)
        {
            for (int j = i+1; j < _circles.Count; j++)
            {                    
                Vector2 deltaPosition = _circles[j].CircleInfo.Position - _circles[i].CircleInfo.Position;
                float sqrLen = deltaPosition.sqrMagnitude;
                float radius = _circles[j].CircleInfo.Radius + _circles[i].CircleInfo.Radius;
                float sqrRadius = radius * radius;

                if (sqrLen <= sqrRadius)
                {
                    if (OnCollisionStart != null)
                        OnCollisionStart(deltaPosition);

                    if (!_circles[i].CircleInfo.isCollided)
                    {
                        UpdateCollisionInfo(i, true, Color.red);
                        collidedIndex.Add(i);
                    }
                    if (!_circles[j].CircleInfo.isCollided)
                    {
                        UpdateCollisionInfo(j, true, Color.red);
                        collidedIndex.Add(j);
                    }
                
                    float depth = _circles[j].CircleInfo.Radius + _circles[i].CircleInfo.Radius - deltaPosition.magnitude;
                    PlayerHelper.UpdateDepthAmount(depth);
                    if (OnDepthChange != null)
                        OnDepthChange();
                    print("Penetration Depth: " + depth);

                  
                }
                else
                {
                    if (collidedIndex.Contains(i) && collidedIndex.Contains(j))
                    {
                        if (OnCollisionEnd != null)
                            OnCollisionEnd();
                        PlayerHelper.UpdateDepthAmount(0);
                        if (OnDepthChange != null)
                            OnDepthChange();
                        UpdateCollisionInfo(i, false, Color.white);
                        UpdateCollisionInfo(j, false, Color.white);
                        collidedIndex.Remove(i);
                        collidedIndex.Remove(j);
                    }                 
                }              
            }
        }
    }

    void UpdateCollisionInfo(int index, bool value, Color color)
    {
        _circles[index].UpdateIsCollided(value);
        _circles[index].UpdateColor(color);
    }

    public void CollisionUpdate(bool value)
    {
        _isActive = value;       
    }
}
