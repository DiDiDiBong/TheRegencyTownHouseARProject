using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectShake : MonoBehaviour
{
    public GameObject Obj;
    public Vector3 angle;
    public Vector3 length;

    public int count;

    //private bool ShakeState;
    private Vector3 RotateStep;
    private Vector3 TranslateStep;
    private bool ShakeState;
    private int stepCount;
    // Start is called before the first frame update
    void Start()
    {
        RotateStep = angle/count;
        TranslateStep = length/count;
        ShakeState = true;
        stepCount = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (stepCount == count) ShakeState =false;
        if (stepCount == -count) ShakeState = true;
        if (ShakeState == true)
        {
            Obj.transform.localEulerAngles += RotateStep;
            Obj.transform.localPosition += TranslateStep;
            stepCount++;
        }
        else
        {
            Obj.transform.localEulerAngles -= RotateStep;
            Obj.transform.localPosition -= TranslateStep;
            stepCount--;
        }
        

        
    }
}
