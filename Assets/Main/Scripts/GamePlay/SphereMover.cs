using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereMover : MonoBehaviour
{
    [SerializeField] Circle _circle;
    [SerializeField] bool _isMovable;
    [SerializeField] float _speed = .5f;
    const float Min = -5f;
    const float Max = 5f;
    public bool IsMovable => _isMovable;
    public void MovementUpdate(Vector3 output)
    {
        transform.position = Vector3.MoveTowards(transform.position, output, _speed * Time.fixedDeltaTime);
        transform.position = CheckBoundary(transform.position);
        _circle.UpdatePosition();
    }
    public void CollisionMoveUpdate(Vector2 deltaPosition)
    {
        Vector3 tangent = new Vector3(-deltaPosition.y, deltaPosition.x, 0);
        Vector3 direction = tangent.normalized;
        Vector3 target = _speed * direction;
        transform.Translate(target);     
        transform.position = CheckBoundary(transform.position);
        _circle.UpdatePosition();
    }

    public void CollisionRestMoveUpdate(Vector2 deltaPosition)
    {
        Vector3 normal = new Vector3(deltaPosition.x, deltaPosition.y, 0);
        Vector3 direction = normal.normalized;
        Vector3 target = _speed * direction;
        transform.Translate(target);
        transform.position = CheckBoundary(transform.position);
        _circle.UpdatePosition();
    }

    public Vector3 CheckBoundary(Vector3 checkPos)
    {
        Vector3 pos = checkPos;
        pos.x = Mathf.Clamp(checkPos.x, Min, Max);
        pos.y = Mathf.Clamp(checkPos.y, Min, Max);
        checkPos = pos;
        return checkPos;
    }
}
