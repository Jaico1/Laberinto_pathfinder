using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentLevel : MonoBehaviour
{
    public Text sizetxt;
    void Start()
    {
        sizetxt.text = "Level: " + PlayerPrefs.GetInt("level");
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
