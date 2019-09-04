using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeGlobalVar : MonoBehaviour
{
    public float Var = 4f;// = 2f;
    // Start is called before the first frame update
    private bool state;
    void Start()
    {
        state = false;
    }

    // Update is called once per frame
    void Update()
    {
        //GlobalVar.OutlineWidth = Var;
    }

    void SwitchState()
    {
        if(state == false)
        {
            GlobalVar.OutlineWidth = Var;
            state = true;
        }
        else
        {
            GlobalVar.OutlineWidth = 0f;
            state = false;
        }
    }
}
