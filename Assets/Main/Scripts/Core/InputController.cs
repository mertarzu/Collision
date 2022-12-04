using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    Vector3 _output;
    public Vector3 Output => _output;
    [SerializeField] Camera _mainCamera;
    Plane _plane = new Plane(Vector3.forward, 0);

    public void InputUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            float distance;
            Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

            if (_plane.Raycast(ray, out distance))
            {              
                Vector3 output = ray.GetPoint(distance);
                _output = new Vector3(output.x, output.y, 0);
            }

        }
        if (Input.GetMouseButtonUp(0))
        {
            _output = Vector3.zero;
        }

    }
}
