using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast : MonoBehaviour
{
    public GameObject lasthit;
    public Vector3 collision = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RayDetect();

    }

    private void RayDetect()
    {
        var ray = new Ray(origin: this.transform.position, direction: this.transform.forward);
        RaycastHit hit;

        if ((Physics.Raycast(ray, out hit, maxDistance: 100)) && hit.transform.gameObject.tag == "super")
        {
            lasthit = hit.transform.gameObject;
            Debug.Log("Hit");
        }
        else
        {
            Debug.Log("not hit");
        }
    }
}
