using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomControl : MonoBehaviour
{
    [SerializeField] private float zoomChange;
    [SerializeField] private float smoothChange;
    [SerializeField] private float minSize, maxSize;

    private Camera cam;

    private void Start()
    {
        cam = GetComponent<Camera>();
    }

    private void Update()
    {
        if(Input.mouseScrollDelta.y > 0)
        {
            cam.orthographicSize -= zoomChange * Time.deltaTime * smoothChange;
        }
        if(Input.mouseScrollDelta.y < 0)
        {
            cam.orthographicSize += zoomChange * Time.deltaTime * smoothChange;
        }

        cam.orthographicSize = Mathf.Clamp(cam.orthographicSize, minSize, maxSize);
    }
}
