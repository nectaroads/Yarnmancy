using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Controller : MonoBehaviour
{
    Transform target;
    Camera cam;

    float zoom;
    float zoomVelocity;
    Vector3 targetOffset;
    Vector3 movementVelocity;

    void Start()
    {
        target = GameObject.Find("/Entities/Kratiste/Body/Soul").GetComponent<Transform>();
        cam = GetComponent<Camera>();

        zoom = cam.orthographicSize;
    }

    void FixedUpdate()
    {
        if(cam.orthographicSize != zoom)
            cam.orthographicSize = Mathf.SmoothDamp(cam.orthographicSize, zoom, ref zoomVelocity, 0.2f);

        targetOffset = target.position + new Vector3(0, 0.25f, -10);
        if (transform.position != targetOffset) 
            transform.position = Vector3.SmoothDamp(transform.position, targetOffset, ref movementVelocity, 0.2f);
    }

    void Update()
    {
        if(Input.mouseScrollDelta.y != 0.0f)
        {
            zoom -= Input.mouseScrollDelta.normalized.y;
            zoom = Mathf.Clamp(zoom, 4.0f, 16.0f);
        }
    }
}
