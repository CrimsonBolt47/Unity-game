using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddLevel : MonoBehaviour
{
    public GameObject parentcontent;
    public GameObject prefablevel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(prefablevel, parentcontent.transform);

        }
        
    }
}
