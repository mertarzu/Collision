using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereController : MonoBehaviour
{
    [SerializeField] InputController _inputController;
    [SerializeField] CircleCircleCollision _circleCircleCollision;
    [SerializeField] bool _isCollisionAllowedToMove;
    public Vector3 Output => _inputController.Output;

    [SerializeField] List<SphereMover> _sphereMovers = new List<SphereMover>();
    Vector2 _deltaPosition;
    bool _isActive;
    bool _isCollision;
    public void Initialize()
    {
        _circleCircleCollision.OnCollisionStart += OnCollisionStart;
        _circleCircleCollision.OnCollisionEnd += OnCollisionEnd;
    }

    public void StartGame()
    {
        _isActive = true;
    }

    void FixedUpdate()
    {
        if (!_isActive) return;
        _inputController.InputUpdate();

        if (_isCollisionAllowedToMove && _isCollision)
        {
            foreach (SphereMover sphereMover in _sphereMovers)
            {
                if (sphereMover.IsMovable)
                {
                    sphereMover.CollisionMoveUpdate(_deltaPosition);
                }
                else
                {
                    sphereMover.CollisionRestMoveUpdate(_deltaPosition);
                }
            }
            _circleCircleCollision.CollisionUpdate(true);
        }
        else if (Mathf.Abs(Vector3.Magnitude(Output)) > Mathf.Epsilon )
        {
            foreach (SphereMover sphereMover in _sphereMovers)
            {
                if (sphereMover.IsMovable)
                {
                    sphereMover.MovementUpdate(Output);
                    _circleCircleCollision.CollisionUpdate(true);
                }
            }
        }
        else
        {
            _circleCircleCollision.CollisionUpdate(false);         
        }
    }

    void OnCollisionStart(Vector2 deltaPosition)
    {
        _isCollision = true;
        _deltaPosition = deltaPosition;
    }
    void OnCollisionEnd()
    {
        _isCollision = false;
        _circleCircleCollision.CollisionUpdate(false);
    }

   

}
