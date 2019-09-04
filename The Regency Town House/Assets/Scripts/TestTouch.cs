using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestTouch : MonoBehaviour
{
    public Text label;
    // Start is called before the first frame update
    void Start()
    {
        label.text = "not select";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TouchHeld()
    {
        label.text = "selected!";

    }
}
