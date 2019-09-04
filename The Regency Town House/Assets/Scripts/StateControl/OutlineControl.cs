using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineControl : MonoBehaviour
{
    private bool Mode = false;
    public float Var = 4f;
    public UnityEngine.Events.UnityEvent On_Actions;
    public UnityEngine.Events.UnityEvent Off_Actions;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void switchMode()
    {
        if(Mode == false)
        {
            //switch to mini model
            //MiniState();
            GlobalVar.OutlineWidth = Var;
            On_Actions.Invoke();
            Mode = true;
        }
        else
        {
            //switch to Immer model
            //ImmerState();
            GlobalVar.OutlineWidth = 0f;
            Off_Actions.Invoke();
            Mode = false;
        }

    }
}
