using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour
{
    [SerializeField] float scrollspeed = 2f;
    [SerializeField] float camMin = 10f;
    [SerializeField] float camMax = 20f;
    [SerializeField] float camDis = 20f;

    private Camera zoomcamera;

    // Start is called before the first frame update
    void Start()
    {
        zoomcamera = Camera.main;
        
    }

    // Update is called once per frame
    void Update()
    {
        zoomcamera.fieldOfView -= Input.GetAxis("Mouse ScrollWheel") * scrollspeed;
        zoomcamera.fieldOfView = Mathf.Clamp(zoomcamera.fieldOfView, camMin, camMax);
               
    }
}
