using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenPhoto : MonoBehaviour
{
    public GameObject image;

    



    public void OpenimagePhoto()
    {
        image.GetComponent<Image>().sprite = gameObject.GetComponent<Image>().sprite;     
        image.SetActive(true);

    }
    public void ClosingPhoto()
    {
        image.SetActive(false);
    }
}
