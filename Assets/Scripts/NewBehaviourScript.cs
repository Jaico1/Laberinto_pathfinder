using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    public Text sizetxt;
    public Text mtxt;


    void Start()
    {
        PlayerPrefs.SetInt("Size", 10);
        PlayerPrefs.SetInt("M", 20);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setSize(float size)
    {
        PlayerPrefs.SetInt("Size", (int)size);
    }

    public void setText(float size)
    {
        sizetxt.text = "Grid Size: " + size + " x " + size;

    }

    public void SetM(float M)
    {
        PlayerPrefs.SetInt("M", (int)M);
    }

    public void setTextM(float size)
    {
        mtxt.text = "Obstaculos: " + size ;

    }
}    
