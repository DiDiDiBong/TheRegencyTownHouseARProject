using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireplace : MonoBehaviour
{
    public GameObject fireplace;
    public GameObject fire;
    public bool isOn;
    // Start is called before the first frame update
    void Start()
    {
        isOn = false;
        fire.SetActive(false);
    }

    public void fire_place()
    {
        if (isOn == false) 
        {
            fire.SetActive(true);
            isOn = true;
        }
        else 
        {
            fire.SetActive(false);
            isOn = false;
        }
    }
}
