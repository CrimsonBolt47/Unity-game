using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Madechoice : MonoBehaviour
{
    DialogueManager dm;
    static int i = 0;
    public int k;
    private void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(()=>MakeChoice());
        k = i;
        i++;
        dm = FindObjectOfType<DialogueManager>();
    }
    public void  MakeChoice()
    {
        dm.MakeChoice(k);
        i = 0;
    }
    private void Update()
    {
        if(dm.GetMadeChoice())
        {
            Destroy(gameObject);
        }
    }
}
