using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShiftMat : MonoBehaviour
{
    public GameObject[] WaitingObjs;
    public Material[] TargetMats;
    public List<Material> OriginalMat = new List<Material>();

    public bool isShifted = false;

    void Start()
    {
        for (int i = 0; i < WaitingObjs.Length; i++)
        {
            OriginalMat.Add(WaitingObjs[i].GetComponent<Renderer>().material);
        }
    }

    public void Shift_Mat()
    {   
        // If the material is original
        if (isShifted == false)
        {
            for (int i = 0; i < WaitingObjs.Length; i++)
            {
                if (WaitingObjs[i] != null)
                {
                    if (TargetMats[i] != null)
                    {
                        WaitingObjs[i].GetComponent<Renderer>().material = TargetMats[i];
                    }    
                }
                            
            }
            isShifted = true;
        }
        // If the material is shifted, shift back
        else
        {
            for (int i = 0; i < WaitingObjs.Length; i++)
            {
                if (WaitingObjs[i] != null)
                {
                    WaitingObjs[i].GetComponent<Renderer>().material = OriginalMat[i];   
                }
                    
            }
            isShifted = false;
            
        }
    }
}
