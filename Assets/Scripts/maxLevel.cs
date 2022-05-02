using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class maxLevel : MonoBehaviour
{
    public Text sizetxt;
    void Start()
    {
        sizetxt.text = "Max Level: " + PlayerPrefs.GetInt("level");
    }

    
    void Update()
    {
        
    }
}
