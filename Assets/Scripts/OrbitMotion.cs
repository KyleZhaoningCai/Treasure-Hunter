using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitMotion : MonoBehaviour {

    public GameObject centerObject;
    public float radius = 10f;
    public float angle;
    public float rotateSpeed = 0.8f;
    public float rightAngle = 2f;
    public float leftAngle = 4f;
    public float speedRotate = 1.0f;
    
    private Vector2 centre;
    private bool clockwise;

    private void Start()
    {
        centre = centerObject.transform.position;
        angle = 2f;
        clockwise = true;
    }

    private void Update()
    {
        if (clockwise)
        {
            angle += rotateSpeed * Time.deltaTime;
            transform.Rotate(new Vector3(0, 0, -1) * speedRotate * Time.deltaTime);

        }
        else
        {
            angle -= rotateSpeed * Time.deltaTime;
            transform.Rotate(Vector3.forward * speedRotate * Time.deltaTime);
        }
        if (angle >= leftAngle)
        {
            clockwise = false;
        }
        if (angle <= rightAngle)
        {
            clockwise = true;
        }

        var offset = new Vector2(Mathf.Sin(angle), Mathf.Cos(angle)) * radius;
        transform.position = centre + offset;
    }
}
