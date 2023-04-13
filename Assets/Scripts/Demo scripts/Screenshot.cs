using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screenshot : MonoBehaviour
{
    [SerializeField] int supersize=2;

    

    private void Update()
    {
        ScreenshotCapture();

    }

    private void ScreenshotCapture()
    {
        //var tage = FindObjectOfType<Redbox>().GetTag();

       // if (Input.GetKeyDown(KeyCode.A))
        {
         //   ScreenCapture.CaptureScreenshot($"tagis{tage}.png", supersize);
        }
    }
}
