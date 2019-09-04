using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchActive : MonoBehaviour
{
    public GameObject Obj;
    private bool isOn;

    void start()
    {
        if(Obj.activeSelf) isOn = true;
        else isOn = false;
    }
    public void SwitchState()
    {
        if(isOn == false)
        {
            Obj.SetActive(true);
            isOn = true;
        }
        else
        {
            Obj.SetActive(false);
            isOn = false;
        }

    }

}
