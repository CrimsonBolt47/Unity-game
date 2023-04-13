using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows;

public class CameraMode : MonoBehaviour
{
    public GameObject lasthit;
    public Vector3 collision = Vector3.zero;
    bool togglecamera;


    [SerializeField] int supersize = 2;

    [SerializeField] GameObject camerascreen;
    [SerializeField] GameObject photoCapture;
    [SerializeField] Text phototext;

    [SerializeField] GameObject content;
    [SerializeField] Button button;
    Image image;
    [SerializeField] GameObject Inventory;
    bool toggleInventory;
    [SerializeField] GameObject photocanvas;
    string tage;

    public bool GetToggleInventory()
    {
        return toggleInventory;
    }
    public bool Gettogglecamera()
    {
        return togglecamera;
    }
    

    void Update()
    {

        OpenCamera();
        OpenInventory();
       
        
    }
    void OpenInventory()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            toggleInventory = !toggleInventory;
        }
        if (toggleInventory && togglecamera==false)
        {
            Inventory.SetActive(true);
        }
        else
        {
            Inventory.SetActive(false);
        }
    }


    void OpenCamera()
    {
        if (Input.GetButtonDown("Fire1"))
            togglecamera = !togglecamera;

        if (togglecamera)   //toggle screenshot
        {
            toggleInventory = false;
            camerascreen.SetActive(true);
            StartCoroutine(ScreenshotCapture());




        }
        else
        {
            camerascreen.SetActive(false);
            photoCapture.SetActive(false);
        }

    }

    public void RayDetect()
    {
        var ray = new Ray(origin: this.transform.position, direction: this.transform.forward);
        RaycastHit hit;

        if ((Physics.Raycast(ray, out hit, maxDistance: 100)))
        {
            lasthit = hit.transform.gameObject;
        }
        else
        {
            lasthit = null;
        }
    }

    void AddInInventory(string tage)
    {
        var photo=Instantiate(button, content.transform) as Button;
        photo.GetComponent<OpenPhoto>().image = photocanvas;
        GetPhoto(tage,photo);
       

    }

    

    public void GetPhoto(string tage,Button photo)
    {
        string url = $"tagis{tage}.png";
        var bytes = File.ReadAllBytes(url);
        Texture2D texture = new Texture2D(2, 2);
        bool imageLoadSuccess = texture.LoadImage(bytes);
        while (!imageLoadSuccess)
        {
            print("image load failed");
            bytes = File.ReadAllBytes(url);
            imageLoadSuccess = texture.LoadImage(bytes);
        }
        print("Image load success: " + imageLoadSuccess);
        photo.GetComponent<Image>().sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0f, 0f), 100f);
        
    }

    IEnumerator ScreenshotCapture()
    {
        RayDetect();

        if(lasthit!=null)
        {
            tage = lasthit.name;
        }
        else
        {
            tage = "nothing";
        }
      
        

        if (Input.GetKeyDown(KeyCode.A))
        {
            togglecamera = !togglecamera;
            camerascreen.SetActive(false);
            phototext.text = tage.ToString();

            yield return new WaitForEndOfFrame();
            photoCapture.SetActive(true);
            ScreenCapture.CaptureScreenshot($"tagis{tage}.png", supersize);
            yield return new WaitForSeconds(1f);
            AddInInventory(tage);
            





        }
    }
}
